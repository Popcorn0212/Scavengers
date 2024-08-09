using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class CombineMesh : MonoBehaviour
{
    public GameObject[] go;


    void Start()
    {
        MeshFilter[] meshFilter = new MeshFilter[go.Length];
        CombineInstance[] combine = new CombineInstance[meshFilter.Length];

        for(int i = 0; i < meshFilter.Length; i++)
        {
            meshFilter[i] = go[i].GetComponent<MeshFilter>();
            combine[i].mesh = meshFilter[i].mesh;
            combine[i].transform = meshFilter[i].transform.localToWorldMatrix;
        }

        Mesh mesh = this.transform.GetComponent<MeshFilter>().mesh;

        mesh.Clear();
        mesh.CombineMeshes(combine);

        this.gameObject.AddComponent<MeshCollider>();

#if UNITY_EDITOR
        { // Mesh ¿˙¿Â
            string path = "Assets/MyMesh.asset";
            AssetDatabase.CreateAsset(transform.GetComponent<MeshFilter>().mesh, AssetDatabase.GenerateUniqueAssetPath(path));
            AssetDatabase.SaveAssets();
        }
#endif
    }
}

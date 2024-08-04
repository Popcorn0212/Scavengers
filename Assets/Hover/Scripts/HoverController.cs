using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverController : MonoBehaviour
{
    // 호버 조종

    public float moveSpeed = 7.0f;
    public float hoverSpeed = 5.0f;
    CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        WASD();        
        Hover();
        
    }

    void WASD()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, -v);
        dir.Normalize();

        cc.Move(dir * moveSpeed * Time.deltaTime);
    }

    void Hover()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            cc.Move(transform.up * hoverSpeed * Time.deltaTime);
        }
    }
}

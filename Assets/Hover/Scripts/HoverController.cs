using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
        float currentX = transform.eulerAngles.x;
        if (currentX > 180) currentX -= 360;

        float clampedX = Mathf.Clamp(currentX, -10, 10);
        transform.eulerAngles = new Vector3(clampedX, transform.eulerAngles.y, transform.eulerAngles.z);

        if (Input.GetKey(KeyCode.Space))
        {
            cc.Move(Vector3.up * hoverSpeed * Time.deltaTime);
            transform.eulerAngles += new Vector3(1, 0, 0);
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            cc.Move(Vector3.down * hoverSpeed * Time.deltaTime);
            transform.eulerAngles += new Vector3(-1, 0, 0);
        }
        else
        {
            Vector3 flatEulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, flatEulerAngles, 0.1f);
        }

        currentX = transform.eulerAngles.x;
        if (currentX > 180) currentX -= 360;
        clampedX = Mathf.Clamp(currentX, -10, 10);
        transform.eulerAngles = new Vector3(clampedX, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}

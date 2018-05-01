using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;

    public float jumpHeight = 15f;

    private Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }
    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigid.AddForce(Vector3.forward * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rigid.AddForce(Vector3.back * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigid.AddForce(Vector3.left * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rigid.AddForce(Vector3.right * speed);
        }
    }

    
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }
}
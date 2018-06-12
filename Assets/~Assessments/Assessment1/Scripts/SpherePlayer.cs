using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SpherePlayer : MonoBehaviour
{
    public float speed = 6f;

    public float jumpHeight = 3f;

    public Text countText;
    public Text winText;

    private Rigidbody rigid;
    private int count;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }
    void Move()
    // Movement Script (WASD)
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
    // Jump Script (Space)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }
    // Item & Hazard Script
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText ();
        }
        if (other.gameObject.CompareTag("Hazard"))
        {
            other.gameObject.SetActive(false);
            Vector3 jump = new Vector3(0.0f, 30, 0.0f);
            rigid.AddForce(jump * speed * Time.deltaTime);
        }
    }
    // Text Script
    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 4)
        {
            winText.text = "You Win!";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 5f;

    private Vector3 move;
    private bool button1;
    private bool button2;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb is null)
        {
            Debug.LogError("Rigidbody component not found on this GameObject.");
        }
    }

    //separated the reading of inputs and its actions to help mitigate the effects of button mashing
    void Update()
    {
        move = Vector3.zero;
        button1 = false;
        button2 = false;

        if(Input.GetKey("up"))
        {
            move += Vector3.forward;
        }
        if (Input.GetKey("down"))
        {
            move += Vector3.back;
        }
        if (Input.GetKey("left"))
        {
            move += Vector3.left;
        }
        if (Input.GetKey("right"))
        {
            move += Vector3.right;
        }
        if (Input.GetKey("."))
        {
            button1 = true;
        }
        if (Input.GetKey("/"))
        {
           button2 = true;
        }
    }

    private void FixedUpdate()
    {
        if (button1)
        {
            // Pressed the "." button
            Debug.Log("\".\" button pressed!");
        }
        if (button2)
        {
            // Pressed the "/" button
            Debug.Log("\"/\" button pressed!");
        }


        rb.MovePosition(transform.position + move * speed * Time.fixedDeltaTime);
    }
}

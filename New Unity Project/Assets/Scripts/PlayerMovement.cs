using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float HorizontalAxis;
    float VerticalAxis;

    public float MaxSpeed = 5f;

    public float MoveSpeed;

    Vector3 PlayerInput;
    Vector3 DefaultPos;

    public Rigidbody rb { get; private set; }

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        DefaultPos = rb.position;
    }
	
	void Update ()
    {
           
        //print(rb.velocity.magnitude);
	}
    
    void FixedUpdate ()
    {
        PlayerInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        ForceAdding();

        if (rb.position.y < -10)
        {
            Reset();
        }


        
        print(rb.velocity.magnitude);
    }

    void ForceAdding()
    {
        if (rb.velocity.magnitude < MaxSpeed && rb.position.y == 0.5)
        {
            rb.AddForce(PlayerInput * MoveSpeed);
        }
    }

    void Reset()
    {
        rb.position = DefaultPos;    
    }
}

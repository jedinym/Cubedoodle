//using System.Collections;
//using System.Collections.Generic;
//using System;
//using UnityEngine;

//public class PlayerMovement : MonoBehaviour
//{
//    Vector3 JumpForce = new Vector3(0, 200, 0);
//    //float HorizontalAxis;
//    //float VerticalAxis;

//    public float MaxSpeed;
//    public float MoveSpeed;

//    Vector3 PlayerInput;
//    Vector3 DefaultPos;

//    public Rigidbody rb { get; private set; }

//	void Start ()
//    {
//        rb = GetComponent<Rigidbody>();
//        DefaultPos = rb.position;
//    }

//	void Update ()
//    {

//        //print(rb.velocity.magnitude);
//	}

//    void FixedUpdate ()
//    {
//        PlayerInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
//        //print(rb.position.y);

//        if (Input.GetKeyDown(KeyCode.U) && rb.position.y < 0.8)
//        {
//            Jump();
//        }

//        ForceAdding();

//        if (rb.position.y < -10)
//        {
//            Reset();
//        }


//        //print(rb.velocity.y);
//        //print(rb.velocity.magnitude);
//        print(rb.velocity);
//    }

//    void ForceAdding()
//    {
//        if (Mathf.Abs(rb.velocity.x) < MaxSpeed && Mathf.Abs(rb.velocity.z) < MaxSpeed)
//        {
//            rb.AddForce(PlayerInput * MoveSpeed);
//        }
//    }

//    void Jump()
//    {
//        rb.AddForce(JumpForce);
//    }

//    void Reset()
//    {
//        rb.position = DefaultPos;
//        rb.velocity = Vector3.zero;
//    }
//}









//using System.Collections;
//using System.Collections.Generic;
//using System;
//using UnityEngine;

//public class PlayerMovement : MonoBehaviour
//{
//    float ImpactVelocity;
//    Vector3 JumpForce = new Vector3(0, 200, 0);
//    //float HorizontalAxis;
//    //float VerticalAxis;

//    public float MaxSpeed;
//    public float MoveSpeed;

//    Vector3 PlayerInput;
//    Vector3 DefaultPos;

//    public Rigidbody rb { get; private set; }

//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//        DefaultPos = rb.position;
//    }

//    void Update()
//    {

//        //print(rb.velocity.magnitude);
//    }

//    void FixedUpdate()
//    {
//        PlayerInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
//        //print(rb.position.y);

//        if (Input.GetKeyDown(KeyCode.U) && rb.position.y < 0.8)
//        {
//            Jump();
//        }

//        ForceAdding();

//        if (rb.position.y < -10)
//        {
//            Reset();
//        }


//        //print(rb.velocity.y);
//        //print(rb.velocity.magnitude);
//        //print(rb.velocity);
//    }

//    void ForceAdding()
//    {
//        if (Mathf.Abs(rb.velocity.x) < MaxSpeed && Mathf.Abs(rb.velocity.z) < MaxSpeed)
//        {
//            rb.AddForce(PlayerInput * MoveSpeed);
//        }
//    }

//    void Jump()
//    {
//        rb.AddForce(JumpForce);
//    }

//    void Reset()
//    {
//        rb.position = DefaultPos;
//        rb.velocity = Vector3.zero;
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        ImpactVelocity = Mathf.Abs(rb.velocity.y);
//        print(ImpactVelocity);
//    }
//}

//using System.Collections;
//using System.Collections.Generic;
//using System;
//using UnityEngine;

//public class PlayerMovement : MonoBehaviour
//{
//    RaycastHit RCH = new RaycastHit();
//    float ImpactVelocity;
//    Vector3 JumpForce = new Vector3(0, 500, 0);
//    bool CanJump;
//    public float MaxSpeed;
//    public float MoveSpeed;

//    Vector3 PlayerInput;
//    Vector3 DefaultPos;

//    public Rigidbody rb { get; private set; }

//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//        DefaultPos = rb.position;
//    }

//    void Update()
//    {
//        RaycastHit disToGroundRay;

//        PlayerInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

//        Physics.Raycast(rb.position, Vector3.down, out disToGroundRay);

//        if (disToGroundRay.distance <= 2)
//        {
//            ImpactVelocity = rb.velocity.y;
//            ImpactVelocity = Mathf.Abs(ImpactVelocity);
//        }

//        print(ImpactVelocity);

//        CanJump = Physics.Raycast(rb.position, Vector3.down, out RCH, 0.9f);
//    }

//    void FixedUpdate()
//    {
//        if (Input.GetKeyDown(KeyCode.U) && CanJump)
//        {
//            Jump();
//        }

//        ForceAdding();

//        if (rb.position.y < -10)
//        {
//            Reset();
//        }
//    }

//    void ForceAdding()
//    {
//        if (Mathf.Abs(rb.velocity.x) < MaxSpeed && Mathf.Abs(rb.velocity.z) < MaxSpeed)
//        {
//            rb.AddForce(PlayerInput * MoveSpeed);
//        }
//    }

//    void Jump()
//    {
//        Vector3 jump = JumpForce;
//        jump.y += ImpactVelocity * 100;
//        rb.AddForce(jump);
//    }

//    void Reset()
//    {
//        rb.position = DefaultPos;
//        rb.velocity = Vector3.zero;
//    }
//}

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class PlayerMovement : MonoBehaviour
{
    bool IsInAir;
    bool CanJump;

    public Rigidbody rb;

    public float MaxSpeed;
    public float MoveSpeed;
    public Vector3 JumpForce = new Vector3(0, 15, 0);
    public float JumpBoost; // boost applied while boostjumping
    public float TimeDiffMs;

    Stopwatch sw = new Stopwatch();

    Vector3 PlayerInput;
    Vector3 DefaultPos;

    void Start()
    {
        IsInAir = false; //start is on the ground
        CanJump = true; 
        rb = GetComponent<Rigidbody>();
        DefaultPos = rb.position;
    }

    void Update()
    {
        PlayerInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (rb.position.y < -5) //if the player falls -> Reset()
        {
            Reset();
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (CanJump) //initial jump
            {
                sw.Start();
                Jump();
            }
            else if (IsInAir && CastRaysToSides()/*rch.distance <= 2 && rch.distance >= 0.25*/ && sw.ElapsedMilliseconds > TimeDiffMs) //for consecutive jumping
            {
                print("boost");
                sw = new Stopwatch();
                Jump(JumpBoost);
            }
        }

        if (Input.GetButtonDown("Reset"))
        {
            Reset();
        }
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(rb.velocity.x) < MaxSpeed && Mathf.Abs(rb.velocity.z) < MaxSpeed)
        {
            rb.AddForce(PlayerInput * MoveSpeed);
        }

        RaycastHit rch;
        Physics.Raycast(rb.position, Vector3.down, out rch);
        //print(sw.ElapsedMilliseconds);

        //if (Input.GetButtonDown("Jump"))
        //{
        //    if (CanJump) //initial jump
        //    {
        //        sw.Start();
        //        Jump();
        //    }
        //    else if(IsInAir && CastRaysToSides()/*rch.distance <= 2 && rch.distance >= 0.25*/ && sw.ElapsedMilliseconds > TimeDiffMs) //for consecutive jumping
        //    {
        //        print("boost");
        //        sw = new Stopwatch();
        //        Jump(JumpBoost);
        //    }
        //}
    }

    private void Reset()
    {
        rb.position = DefaultPos;
        rb.velocity = Vector3.zero;
    }

    private void Jump(float _boost = 0)
    {
        if (_boost == 0)
        {
            rb.AddForce(JumpForce, ForceMode.Impulse);
            IsInAir = true;
            CanJump = false;
        }
        else
        {
            Vector3 BoostedJumpForce = JumpForce;
            BoostedJumpForce.y += _boost;

            rb.AddForce(BoostedJumpForce, ForceMode.Impulse);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "Ground")
        {
            IsInAir = false;
            CanJump = true;
            sw = new Stopwatch();
        }
        else if (col.transform.tag == "Platform")
        {
            IsInAir = false;
            CanJump = true;
            sw = new Stopwatch();
        }
        else if (col.transform.tag == "DeathPlatform")
        {
            Reset();
        }
        else if (col.transform.tag == "FallPlatform")
        {
            IsInAir = false;
            CanJump = true;
            sw = new Stopwatch();
        }
        //if (col.transform.tag == "Goal")
        //{
            
        //}
    }

    private bool CastRaysToSides()
    {
        RaycastHit[] rays = new RaycastHit[5];

        Physics.Raycast(transform.position, Vector3.forward, out rays[0]);
        Physics.Raycast(transform.position, Vector3.back, out rays[1]);
        Physics.Raycast(transform.position, Vector3.left, out rays[2]);
        Physics.Raycast(transform.position, Vector3.right, out rays[3]);
        Physics.Raycast(transform.position, Vector3.down, out rays[4]);

        List<bool> close = new List<bool>();

        for (int i = 0; i < 5; ++i)
        {
            if (i == 4)
            {
                if (rays[i].distance <= 2 && rays[i].distance >= 0.25)
                {
                    close.Add(true);
                }
                else
                {
                    close.Add(false);
                }
            }

            if (rays[i].distance < 2 && rays[i].distance >= 0.25)
            {
                close.Add(true);
            }
            else
            {
                close.Add(false);
            }
        }

        return close.Contains(true);
    }
}
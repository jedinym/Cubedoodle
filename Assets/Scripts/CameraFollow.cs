using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class CameraFollow : MonoBehaviour
//{
//    public PlayerMovement PMov;

//    Rigidbody crb;

//    Vector3 CamPos; //camera position


//	// Use this for initialization
//	void Start ()
//    {
//        crb = GetComponent<Rigidbody>(); //Inicializujem CRB
//    }
    
//	// Update is called once per frame
//	void Update ()
//    {
        
//    }
//    void LateUpdate ()
//    {
//        if (PMov.rb.position.y > -2)
//        {
//            CamPos.x = PMov.rb.position.x;
//            CamPos.z = PMov.rb.position.z - 10;
//            crb.position = CamPos;
//        }
//    }
//    void FixedUpdate()
//    {
        
//    }
//}

public class CameraFollow : MonoBehaviour
{
    public Transform Target;

    public float SmoothSpeed;
    public Vector3 Offset;
    float YPos;
    Vector3 LookAtPointOffset = new Vector3(0, 0, 5);

    void Start()
    {
        YPos = (Target.position + Offset).y;
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = Target.position + Offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed * Time.deltaTime);
        smoothedPosition.y = YPos;

        transform.position = smoothedPosition;
        transform.LookAt(Target.transform.position + LookAtPointOffset);
    }
}
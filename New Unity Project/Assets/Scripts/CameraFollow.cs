using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public PlayerMovement PMov;
    public Rigidbody CRB; //Camera Rigidbody
    //GameObject Player;
    //PlayerMovement PMov; //PlayerMovement script

    Vector3 CamPos; //camera position


	// Use this for initialization
	void Start ()
    {
        //Rigidbody rb = GetComponent<Rigidbody>();
        //GameObject Player = GameObject.Find("Player");
        //PlayerMovement pMov = Player.GetComponent<PlayerMovement>();
        //CRB.position = PMov.rb.position;

        CRB = GetComponent<Rigidbody>(); //Inicializujem CRB
        //GameObject Player = GameObject.Find("Player"); //Hladam GameObject "Player"
        //PMov = Player.GetComponent<PlayerMovement>(); //Z Player "vytrhnem" rigidbody (asi....)
        
    }
    
	// Update is called once per frame
	void Update ()
    {
        
    }
    void LateUpdate ()
    {
        
    }
    void FixedUpdate()
    {
        if (PMov.rb.position.y > -2)
        {
            CamPos.x = PMov.rb.position.x;
            CamPos.z = PMov.rb.position.z - 10;
            CRB.position = CamPos;
        }
    }
}

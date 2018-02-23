using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlatforms : MonoBehaviour
{
    public float TimeToDeactivate;
    public float TimeToActivate;
    public GameObject Particles;
    GameObject ThisObject;


    //private void FixedUpdate()
    //{
    //    if (Deactivated)
    //    {
    //        Invoke("ActivatePlatform", TimeToActivate);
    //    }
    //}

    private void Start()
    {
        ThisObject = this.gameObject;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Invoke("DeactivatePlatform", TimeToDeactivate);
        }
    }

    private void DeactivatePlatform()
    {
        this.gameObject.SetActive(false);
        Instantiate(Particles, transform.position, transform.rotation, null);

        Invoke("ActivatePlatform", TimeToActivate);
    }

    private void ActivatePlatform()
    {
        ThisObject.SetActive(true);
    }
}

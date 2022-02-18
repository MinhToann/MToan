using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    //public Transform Spw;
    Vector3 force = new Vector3(100f, 0f, 0f);
    void Start()
    {
        
    }

    
    void Update()
    {
        ButtonFire();
    }
    public void ButtonFire()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject bullet1 = Instantiate(bullet.gameObject, hit.point, Quaternion.identity);
                gameObject.tag = "bul";
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                hit.rigidbody.AddForce(Vector3.forward * 100f);
            }


        }
    }


}

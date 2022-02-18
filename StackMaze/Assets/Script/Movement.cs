using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 Direction = Vector3.zero;
    float Speed = 10.0f;
    bool mMove = true;
    public Camera cam;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
                mMove = true;
                Direction = Vector3.left;        
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {          
                mMove = true;
                Direction = Vector3.right;            
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {    
                mMove = true;
                Direction = Vector3.forward;           
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {    
                mMove = true;
                Direction = Vector3.back;          
        }
        if (mMove == true)
        {
            Move();
            //UpdateOrientation();
        }
    }
    void Move()
    {
        transform.localPosition += (Direction * Speed) * Time.deltaTime; 
    }

 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "walls")
        {
            mMove = false;
            //Speed = 0f;
        }
        if(other.gameObject.tag == "gun")
        {
            mMove = false;
            //cam.transform.position = new Vector3(3f, 6.5f, 60f);
           
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "player")
        {
            Debug.Log("touch");
            mMove = false;
        }
    }
}

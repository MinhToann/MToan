using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 Direction = Vector3.zero;
    float Speed = 20.0f;
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Direction = Vector3.left;
        }
       else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Direction = Vector3.right;
        }
       else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Direction = Vector3.up;
        }
       else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Direction = Vector3.down;
        }
        Move();
        UpdateOrientation();
    }
    void Move()
    {
        transform.localPosition += (Direction * Speed) * Time.deltaTime;
    }
    void UpdateOrientation()
    {
        if (Direction == Vector3.left)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Direction == Vector3.right)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Direction == Vector3.up)
        {

        }
        else if (Direction == Vector3.down)
        {

        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public GameObject Player;
    Vector3 vt3;
    void Start()
    {
        vt3 = new Vector3(6.05f, 9.618f, -8.5641f);
        //Cursor.lockState = CursorLockMode.Locked;
        
    }

    
    void Update()
    {
        transform.position = Player.transform.position + vt3;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject SpawnObj;
    public GameObject GroundSpw;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "gunground")
        {
            GameObject SpwObj = Instantiate(SpawnObj, GroundSpw.transform.position, Quaternion.identity);
        }
    }
}

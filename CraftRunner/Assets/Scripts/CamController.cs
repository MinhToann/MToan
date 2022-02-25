using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform player;
    Vector3 distance;
    void Start()
    {
        distance = transform.position - player.transform.position;
    }

    
    void Update()
    {
        transform.position = player.transform.position + distance;
    }
}

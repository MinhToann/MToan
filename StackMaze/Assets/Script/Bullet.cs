using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 Target;
    [SerializeField] float Force = 1000;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void FireBullet(Vector3 Point)
    {
        float Dis = Vector3.Distance(Point, transform.position);
        Target = new Vector3(Point.x, Point.y, Point.z);
        gameObject.AddComponent<Rigidbody>().AddForce((Target - transform.position).normalized * Force);
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject != gameObject)
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatUp1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Eat")
        {
            other.gameObject.tag = "normal";
            PlayerController.Instance.PickDash2(other.gameObject);
            PlayerController.Instance.PrevDash2.GetComponent<SphereCollider>().isTrigger = false;
            other.gameObject.AddComponent<Rigidbody>();
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;

            other.gameObject.AddComponent<EatUp1>();
            //Destroy(this);
        }
    }
}

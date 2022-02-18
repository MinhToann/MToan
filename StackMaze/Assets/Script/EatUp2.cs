using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatUp2 : MonoBehaviour
{
    //public GameObject Cube;
    Vector3 After = new Vector3(0f, 0.1205354f, 0f);
    GameObject Temp;
    int i = 0;
    Vector3 Pos;
    public static EatUp2 Instance1;
    private void Awake()
    {
        if (Instance1 == null)
        {
            Instance1 = this;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Eat")
        {
            other.gameObject.tag = "normal";
            PlayerController.Instance.PickDash(other.gameObject);
            PlayerController.Instance.PrevDash.GetComponent<BoxCollider>().isTrigger = false;
            other.gameObject.AddComponent<Rigidbody>();
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;

            other.gameObject.AddComponent<EatUp2>();
            //Destroy(this);
        }
        if (other.gameObject.tag == "bridge")
        {
            for (i = 0; i <= 6; i++)
            {
                Pos = new Vector3(-0.05f, 4.2f, PlayerController.Instance.DashParent.transform.localPosition.z + i - 7.5f);
                Temp = Instantiate(PlayerController.Instance.Cube, Pos, Quaternion.identity);
            }
            this.gameObject.SetActive(false);
            PlayerController.Instance.DashParent.transform.localPosition -= After;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}

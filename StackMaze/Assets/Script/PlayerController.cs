using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    private Vector3 Speed;
    private CharacterController Char;
   
    //public Camera MyCam;
    //private float Spd = 10f;
    //private float SpeedY = 0f;
    //private float Gravity = -9.81f;
    Rigidbody rb;
    //public GameObject Player;
    bool isEat;
    Vector3 Up;
    float speed = 200f;
    public static PlayerController Instance;
    public GameObject DashParent;
    public GameObject PrevDash;
    private Vector3 characterpos;
    private Vector3 Pos;
    public GameObject Cube;
    private Vector3 Pos2;
    public GameObject PrevDash2;
    Vector3 characterpos2;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        //Char = gameObject.GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();

    }


    void Update()
    {
     
    }

    public void PickDash(GameObject DashObj)
    {
        DashObj.transform.SetParent(DashParent.transform);

        Pos = PrevDash.transform.localPosition;
        Pos.y -= 0.1205354f;
        DashObj.transform.localPosition = Pos;
        characterpos = DashParent.transform.localPosition;
        characterpos.y += 0.1205354f;
        DashParent.transform.localPosition = characterpos;
        PrevDash = DashObj;
        
    }
    //public void PickDash2(GameObject DashObj)
    //{
    //    DashObj.transform.SetParent(DashParent.transform);

    //    Pos2 = PrevDash2.transform.localPosition;
    //    Pos2.y -= 0.5f;
    //    DashObj.transform.localPosition = Pos2;
    //    characterpos2 = DashParent.transform.localPosition;
    //    characterpos2.y += 0.5f;
    //    DashParent.transform.localPosition = characterpos2;
    //    PrevDash2 = DashObj;
    //}
    public void PickDash2(GameObject DashObj)
    {
        DashObj.transform.SetParent(DashParent.transform);       
        Pos2 = PrevDash2.transform.localPosition;
        Pos2.x += 0.2f;       
        Pos2.y += 0.5f;
        DashObj.transform.localPosition = Pos2;
        PrevDash2 = DashObj;
    }
}

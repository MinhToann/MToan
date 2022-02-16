using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    private Vector3 Speed;
    private CharacterController Char;
   
    public Camera MyCam;
    private float Spd = 10f;
    private float SpeedY = 0f;
    private float Gravity = -9.81f;
    Rigidbody rb;
    public GameObject Player;
    bool isEat;
    Vector3 Up;
    float speed = 200f;
    public static PlayerController Instance;
    public GameObject DashParent;
    public GameObject PrevDash;
    private Vector3 characterpos;
    private Vector3 Pos;
    public GameObject Cube;
    //public bool Move = false;
    //Vector3 vt3player = new Vector3(0f, 0.1205354f, 0f);
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        Char = gameObject.GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();

    }


    //void Update()
    //{
    //    float x = Input.GetAxis("Horizontal");
    //    float z = Input.GetAxis("Vertical");

    //    Speed = new Vector3(x, 0, z);
    //    if (!Char.isGrounded)
    //    {
    //        SpeedY += Gravity * Time.deltaTime;
    //    }
    //    else
    //    {
    //        SpeedY = 0;
    //    }
    //    Vector3 Movement = Vector3.up * SpeedY * Time.deltaTime;
    //    Vector3 RotateMovement = Quaternion.Euler(0, MyCam.transform.rotation.eulerAngles.y, 0) * Speed;
    //    Char.Move(RotateMovement * Spd * Time.deltaTime);
    //    if (RotateMovement.magnitude > 0)
    //    {
    //        float AngleofMovement = Mathf.Atan2(RotateMovement.x, RotateMovement.z) * Mathf.Rad2Deg;
    //        transform.rotation = Quaternion.Euler(0, AngleofMovement, 0);
    //    }
    //    Char.Move((Movement +( RotateMovement * Time.deltaTime)));
    //    Move = true;
    //}
 
    public void PickDash(GameObject DashObj)
    {
        DashObj.transform.SetParent(DashParent.transform);

        Pos = PrevDash.transform.localPosition;
        Pos.y -= 0.1205354f;
        DashObj.transform.localPosition = Pos;

        //characterpos = Player.transform.localPosition;
        //characterpos.y += 0.1205354f;
        characterpos = DashParent.transform.localPosition;
        characterpos.y += 0.1205354f;
        DashParent.transform.localPosition = characterpos;
        PrevDash = DashObj;
        PrevDash.GetComponent<BoxCollider>().isTrigger = false;
    }
}

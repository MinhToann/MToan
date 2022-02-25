using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Running : MonoBehaviour
{
    public float Speed = 5.0f;
    public Rigidbody rb;
    float SideMove;
    public GameObject BarGui;
    public GameObject HandGui;
    bool isMove;
    bool Show;
    public Animator Anim1;
    public Animator Anim2;
    public Animator Anim;
    public static Running Instance;
    public float SideSpeed = 3.0f;
    public float SpeedSide = 5.0f;
    bool isBoost;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        BeForePlay();
        Anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        
        SideMove = Input.GetAxis("Horizontal");      
        if(SideMove != 0)
        {
            isMove = true;
        }
     
        if (isMove == true)
        {
            Play();
            Show = false;
        }
        if (Show == false)
        {
            Vector3 move_ment = new Vector3(SideMove, 0f, 0f).normalized;
            Anim.SetBool("isRun", true);
            Vector3 Movement = transform.forward * Speed * Time.deltaTime;           
            Vector3 SideMovement = move_ment * SpeedSide * Time.deltaTime; 
            rb.MovePosition(rb.position + Movement + SideMovement);
            if (isBoost == true)
            {
                Anim.SetBool("isFly", true);
            }
        }
    }
    //void Run()
    //{
    //    if (Show == false)
    //    {
            
    //        Anim.SetBool("isRun", true);
    //        Vector3 Movement = transform.forward * Speed * Time.deltaTime;
    //        Vector3 SideMovement = transform.right * SideMove * SpeedSide * Time.deltaTime * SideSpeed;
    //        rb.MovePosition(rb.position + Movement + SideMovement);
    //    }
    //}
    void ShowGui(bool isShow)
    {
        if (BarGui)
        {
            BarGui.SetActive(isShow);
        }
        if (HandGui)
        {
            HandGui.SetActive(isShow);
        }
    }
    void BeForePlay()
    {
        ShowGui(true);
        Show = true;
        Anim.SetBool("isIdle", true);
    }
    void Play()
    {
        ShowGui(false);
    }
    void LoadScene()
    {
        StartCoroutine("LoseGame");
    }
    IEnumerator LoseGame()
    {
        yield return new WaitForSeconds(1f);
        this.enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Gate")
        {
            LoadScene();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "RedButton")
        {
            this.enabled = false;
            LoadScene();
        }
        if (other.gameObject.tag == "GreenButton")
        {
            Anim1.SetBool("isOpen", true);
            Anim2.SetBool("opened", true);
        }
        if(other.gameObject.tag == "Trap")
        {
            this.enabled = false;
            LoadScene();
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Boost")
        {
            isBoost = true;
            
            Debug.Log("Ok");
        }
    }
}

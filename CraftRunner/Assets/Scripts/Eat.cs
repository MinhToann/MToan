using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Eat : MonoBehaviour
{
    public Text GoldScore;
    float GScore;
    bool isEat;
    public Animator Anim;   
    
    void Start()
    {
        GScore = 0;
        Anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        if(isEat == true)
        {
            GoldScore.text = GScore.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Gold")
        {
            other.gameObject.SetActive(false);
            GScore += 1;
            isEat = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.tag == "Tree")
        {
            Anim.SetBool("isAttack", true);
           // Anim.SetBool("isIdle", true);
            Running.Instance.Speed = 0f;
        }
        else
        {
            Anim.SetBool("isRun", true);
            Anim.SetBool("isAttack", false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Axe : MonoBehaviour
{
    public Text WoodScore;
    float WScore;
    bool isWood;
    public GameObject Wood;
    Vector3 Body = new Vector3(0f, 1.5f, 0f);
    public GameObject BackBoard;
    public Transform obj;
    private Vector3 Pos2;
    public GameObject PrevDash2;
    Vector3 characterpos2;
    public GameObject DashParent;
    void Start()
    {
        WScore = 0;
    }

    
    void Update()
    {
        if (isWood == true)
        {
            WoodScore.text = WScore.ToString();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tree")
        {
            WScore += 1;
            isWood = true;
            // Destroy(other.gameObject);
            Running.Instance.Speed = 5.0f;
            other.gameObject.SetActive(false);
            GameObject EatWood = Instantiate(Wood, obj.position, Quaternion.identity);
            PickDash2(other.gameObject);
        }
    }
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

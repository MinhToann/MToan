using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{   
    [System.Serializable]
    public class CamSetting
    {
        public float moveSpeed = 1f;
        public float MouseSensitive = 0.0000001f;
        public float min = -10;
        public float max = 60;
        public float RotateSpeed = 0.0000001f;
    }
    [SerializeField]
    CamSetting camsetting;

    [System.Serializable]
    public class CameraSetting
    {
        public string MouseXAxis = "Mouse X";
        public string MouseYAxis = "Mouse Y";
    }
    [SerializeField]
    CameraSetting cam;

    Camera maincam;
    Transform center;
    Transform target;
    float CamXRotate = 0f;
    float CamYRotate = 0f;
    void Start()
    {
        maincam = Camera.main;
        center = transform.GetChild(0);
        
    }
   
    void Update()
    {
        if(!target)
        {
            return;
        }
        Rotate();
    }
    private void LateUpdate()
    {
        if(target)
        {
            CamFollow();
        }
        else
        {
            FindPlayer();
        }
    }
    void CamFollow()
    {
        Vector3 MoveSpeed = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * camsetting.moveSpeed);
        transform.position = MoveSpeed;
    }
    void FindPlayer()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Rotate()
    {
        CamXRotate += Input.GetAxis(cam.MouseYAxis) * camsetting.MouseSensitive;
        CamYRotate += Input.GetAxis(cam.MouseXAxis) * camsetting.MouseSensitive;

        CamXRotate = Mathf.Clamp(CamXRotate, camsetting.min, camsetting.max);
        CamYRotate = Mathf.Repeat(CamYRotate, 360);
        Vector3 RotatingAngle = new Vector3(CamXRotate, CamYRotate, 0);
        Quaternion rotate = Quaternion.Slerp(center.transform.localRotation, Quaternion.Euler(RotatingAngle), camsetting.RotateSpeed * Time.deltaTime);
        center.transform.localRotation = rotate;
    }
}

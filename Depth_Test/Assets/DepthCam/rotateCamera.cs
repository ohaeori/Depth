using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCamera : MonoBehaviour
{
    public float rotateSpeed = 10.0f;
    
    private Camera Cam;
    // Start is called before the first frame update
    void Start()
    {
        Cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0, -20f, 0) * Time.deltaTime); 
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(new Vector3(0, 20f, 0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Rotate(new Vector3(-20f, 0, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.Rotate(new Vector3(20f, 0, 0) * Time.deltaTime); 
        }
        
        if (Input.GetKey(KeyCode.R))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
        }

        //if (Input.GetMouseButton(1))
        //{
        //    Vector3 rot = transform.rotation.eulerAngles; // 현재 카메라의 각도를 Vector3로 반환
        //    if (Input.GetKey(KeyCode.LeftShift))
        //    {
        //        rot.x += -1 * Input.GetAxis("Mouse Y") * rotateSpeed; // 마우스 Y 위치 * 회전 스피드
        //        rot.y += Input.GetAxis("Mouse X") * rotateSpeed; // 마우스 X 위치 * 회전 스피드
        //    }
        //    else
        //        rot.y += Input.GetAxis("Mouse X") * rotateSpeed; // 마우스 X 위치 * 회전 스피드
        //    Quaternion q = Quaternion.Euler(rot); // Quaternion으로 변환
        //    q.z = 0;
        //    transform.rotation = Quaternion.Slerp(transform.rotation, q, 2f); // 자연스럽게 회전
        //}
    }
}

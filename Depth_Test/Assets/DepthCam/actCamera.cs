using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class actCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject PointLight;
    [SerializeField]
    private Camera mainCamera;

    private Vector3 targetPos;
    private float yAxis = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //click event
    private void Update()
    {
        //// 마우스 입력을 받았 을 때
        //if (Input.GetMouseButtonUp(0))
        //{
        //    // 마우스로 찍은 위치의 좌표 값을 가져온다
        //    Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit, 10000f))
        //    {
        //        targetPos = hit.point;
        //        //move Camera
        //        transform.position = new Vector3(hit.point.x, yAxis, hit.point.z);
        //        transform.rotation = new Quaternion(0f, 0f, 0f, 0);
        //        //move Light
        //        PointLight.transform.position = new Vector3(hit.point.x, yAxis + 0.5f, hit.point.z);
        //    }
        //}
        // 키보드 입력을 받았 을 때
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0, 0.05f, 0));
            PointLight.transform.Translate(new Vector3(0, 0.05f, 0));
            yAxis += 0.05f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, -0.05f, 0));
            PointLight.transform.Translate(new Vector3(0, -0.05f, 0));
            yAxis -= 0.05f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 0, 0.05f));
            //PointLight.transform.Translate(new Vector3(0, 0, -0.01f));
            PointLight.transform.position = transform.position;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-0.05f, 0, 0));
            //PointLight.transform.Translate(new Vector3(0.01f, 0, 0));
            PointLight.transform.position = transform.position;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, -0.05f));
            //PointLight.transform.Translate(new Vector3(0, 0, 0.01f));
            PointLight.transform.position = transform.position;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(0.05f, 0, 0));
            //PointLight.transform.Translate(new Vector3(-0.01f, 0, 0));
            PointLight.transform.position = transform.position;
        }
    }
}

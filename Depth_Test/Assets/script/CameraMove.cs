using System;
using UnityEngine;
using UnityEngine.AI;

public class CameraMove : MonoBehaviour
{
    NavMeshAgent agent;
    private float moveLen = 0.5f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.baseOffset = 1;
    }

    void Update()
    {
        Vector3 pos = Input.mousePosition;

        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.destination = hit.point;
            }
        }

        // 키보드 입력을 받았 을 때
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0, moveLen, 0));
            //PointLight.transform.Translate(new Vector3(0, moveLen, 0));
            agent.baseOffset += moveLen;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, -moveLen, 0));
            //PointLight.transform.Translate(new Vector3(0, -moveLen, 0));
            agent.baseOffset -= moveLen;
        }
    }
}
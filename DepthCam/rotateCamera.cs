using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Rotate(new Vector3(0, -20f, 0) * Time.deltaTime);
            }
            else
            {
                transform.Rotate(new Vector3(0, 20f, 0) * Time.deltaTime);
            }
            
        }
        if (Input.GetKey(KeyCode.E))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Rotate(new Vector3(-20f, 0, 0) * Time.deltaTime); ;
            }
            else
            {
                transform.Rotate(new Vector3(20f, 0, 0) * Time.deltaTime);
            }
            
        }
        if (Input.GetKey(KeyCode.R))
        {

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);



        }


    }
    
}

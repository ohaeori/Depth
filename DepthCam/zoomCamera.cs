using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomCamera : MonoBehaviour
{
    [SerializeField]
    public float zoomSpeed = 10.0f;
    private Camera Cam;
    // Start is called before the first frame update
    void Start()
    {
        Cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Zoom();
    }
    private void Zoom()
    {
        float distance = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        if (distance != 0)
        {
            //Cam.fieldOfView += distance;
            Cam.farClipPlane += distance;
        }
    }
}

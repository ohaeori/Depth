using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TrackingCam : MonoBehaviour
{
    [SerializeField]
    private Camera RealCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(RealCam.transform.position.x, RealCam.transform.position.y, RealCam.transform.position.z);
        transform.rotation = new Quaternion(RealCam.transform.rotation.x, RealCam.transform.rotation.y, RealCam.transform.rotation.z, RealCam.transform.rotation.w);

        Camera cam = GetComponent<Camera>();
        if (cam != null)
        {
            cam.fieldOfView = RealCam.fieldOfView;
            cam.farClipPlane = RealCam.farClipPlane;
        }
    }
}

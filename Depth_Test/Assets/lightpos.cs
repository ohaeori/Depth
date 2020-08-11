using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class lightpos : MonoBehaviour
{
    [SerializeField]
    private Camera OriginCam;

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
        transform.position = new Vector3(OriginCam.transform.position.x, OriginCam.transform.position.y, OriginCam.transform.position.z);
        transform.rotation = new Quaternion(OriginCam.transform.rotation.x, OriginCam.transform.rotation.y, OriginCam.transform.rotation.z, OriginCam.transform.rotation.w);
    }
}

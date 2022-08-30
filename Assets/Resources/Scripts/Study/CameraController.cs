using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera mainCamera;
    
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    
    void Update()
    {
        MoveCamera();
        RotateCamera();
        ZoomCamera();
    }

    void MoveCamera()
    {
        if(Input.GetMouseButton(0))
        {
            transform.Translate(Input.GetAxisRaw("Mouse X") / 10f,
                                Input.GetAxisRaw("Mouse Y") / 10f,
                                0f );
        }
    }

    void RotateCamera()
    {
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(-Input.GetAxisRaw("Mouse Y"),
                                Input.GetAxisRaw("Mouse X"),
                                0.0f);
            //Vector3 newVec = new Vector3(transform.localRotation.x, transform.localRotation.y, 0.0f);
            //transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0.0f, transform.rotation.w);
        }
    }

    void ZoomCamera()
    {
        mainCamera.fieldOfView -= (20 * Input.GetAxis("Mouse ScrollWheel"));

        if (mainCamera.fieldOfView < 10)    
            mainCamera.fieldOfView = 10;
        else if (mainCamera.fieldOfView > 150)
            mainCamera.fieldOfView = 150;
            
    }
}

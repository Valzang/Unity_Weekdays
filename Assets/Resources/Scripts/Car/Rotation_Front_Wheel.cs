using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Front_Wheel : MonoBehaviour
{
    public GameObject OtherAxis = null;
    float moveSpeed = 150.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rot = moveSpeed * Time.deltaTime;
        Vector3 UpTarget = OtherAxis.transform.position;        
        UpTarget.y += 2;
        Vector3 dirToTarget = UpTarget - OtherAxis.transform.position;
        dirToTarget = dirToTarget.normalized;
        
        float Y_Angle = OtherAxis.transform.localRotation.eulerAngles.y;
        Y_Angle += (Y_Angle > 180 ? -360 : 0);
        

        if (Input.GetKey(KeyCode.A) && Y_Angle > -30.0f)
        {
            OtherAxis.transform.Rotate(dirToTarget, -rot, Space.Self);          
        }
        else if (Input.GetKey(KeyCode.D) && Y_Angle < 30.0f)
        {
            OtherAxis.transform.Rotate(dirToTarget, rot, Space.Self);
        }
        else
        {
            float ToZero = Y_Angle > 0 ? -rot : rot;
            OtherAxis.transform.Rotate(dirToTarget, ToZero, Space.Self);
        }
    }
}

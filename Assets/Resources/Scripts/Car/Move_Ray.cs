using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Ray : MonoBehaviour
{
    [SerializeField]
    [Range(0,10)]
    public float moveSpeed = 10.0f;

    [Range(0, 100)]
    public float distance = 100.0f;

    public GameObject LeftSensor = null;
    public GameObject RightSensor = null;
    public GameObject Wheel_Left = null;
    public GameObject Wheel_Right = null;
    public GameObject Wheel_BLeft = null;
    public GameObject Wheel_BRight = null;

    public GameObject OtherAxis = null;
    //public GameObject OtherAxis_R = null;

    private Ray ray_L;
    private Ray ray_R;


    private RaycastHit rayHit_L;
    private RaycastHit rayHit_R;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Input_Move();
    }
    
    void Ray_Move()
    {
        float moveDelta = moveSpeed * Time.deltaTime;
        transform.Translate(Vector3.forward * moveDelta);

        float rot = 150.0f * Time.deltaTime * 5;
        Wheel_Left.transform.Rotate(0, rot, 0, Space.Self);
        Wheel_Right.transform.Rotate(0, rot, 0, Space.Self);
        Wheel_BLeft.transform.Rotate(0, rot, 0, Space.Self);
        Wheel_BRight.transform.Rotate(0, rot, 0, Space.Self);

        Vector3 UpTarget = OtherAxis.transform.position;
        UpTarget.y += 2;
        Vector3 dirToTarget = UpTarget - OtherAxis.transform.position;
        dirToTarget = dirToTarget.normalized;

        float Y_Angle = OtherAxis.transform.localRotation.eulerAngles.y;
        Y_Angle += (Y_Angle > 180 ? -360 : 0);

        ray_L = new Ray(LeftSensor.transform.position, LeftSensor.transform.forward);
        ray_R = new Ray(RightSensor.transform.position, RightSensor.transform.forward);
        Physics.Raycast(ray_L, out rayHit_L, distance);
        Physics.Raycast(ray_R, out rayHit_R, distance);

        if(rayHit_L.distance < rayHit_R.distance)
        {
            transform.Rotate(new Vector3(0, -5 * moveDelta, 0));
            if ( Y_Angle > -30.0f)
             OtherAxis.transform.Rotate(dirToTarget, -rot, Space.Self);
        }
        else if (rayHit_L.distance > rayHit_R.distance)
        {
            transform.Rotate(new Vector3(0, 5 * moveDelta, 0));
            if (Y_Angle < 30.0f)
                OtherAxis.transform.Rotate(dirToTarget, rot, Space.Self);
        }
        else
        {
            float ToZero = Y_Angle > 0 ? -rot : rot;
            OtherAxis.transform.Rotate(dirToTarget, ToZero, Space.Self);
        }
    }

}

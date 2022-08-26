using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Ray6 : MonoBehaviour
{
    [SerializeField]
    [Range(0,100)]
    public float moveSpeed = 10.0f;

    [Range(0, 200)]
    public float Sensor_Distance = 200.0f;

    [Range(0, 20)]
    public float FB_Sensor_Distance = 20.0f;

    public GameObject F_LeftSensor = null;
    public GameObject F_RightSensor = null;
    public GameObject FrontSensor = null;

    public GameObject BackSensor = null;
    public GameObject B_LeftSensor = null;
    public GameObject B_RightSensor = null;


    public GameObject Wheel_Left = null;
    public GameObject Wheel_Right = null;
    public GameObject Wheel_BLeft = null;
    public GameObject Wheel_BRight = null;

    public GameObject OtherAxis_L = null;
    public GameObject OtherAxis_R = null;

    private Ray ray_F_L;
    private Ray ray_F_R;
    private Ray ray_F;
    private Ray ray_B;
    private Ray ray_B_L;
    private Ray ray_B_R;

    private RaycastHit rayHit_F_L;
    private RaycastHit rayHit_F_R;
    private RaycastHit rayHit_F;
    private RaycastHit rayHit_B;
    private RaycastHit rayHit_B_L;
    private RaycastHit rayHit_B_R;

    private enum Solution { F_L, F_R, B_L, B_R, Nothing };

    private int FallBack = (int)Solution.Nothing;

    // Update is called once per frame
    void Update()
    {
        Ray_Move();
    }
    
    void Ray_Move()
    {
        float moveDelta = moveSpeed * Time.deltaTime;
        float rot = 150.0f * Time.deltaTime * 5;

       
        // 바퀴를 돌리기 위한 축====================================
        Vector3 UpTarget_L = OtherAxis_L.transform.position;
        Vector3 UpTarget_R = OtherAxis_R.transform.position;
        UpTarget_L.y += 2;
        UpTarget_R.y += 2;

        Vector3 dirToTarget_L = UpTarget_L - OtherAxis_L.transform.position;
        dirToTarget_L = dirToTarget_L.normalized;

        Vector3 dirToTarget_R = UpTarget_R - OtherAxis_R.transform.position;
        dirToTarget_R = dirToTarget_R.normalized;

         float Y_Angle = OtherAxis_L.transform.localRotation.eulerAngles.y;
        Y_Angle += (Y_Angle > 180 ? -360 : 0);

        // ======================================================



        ray_F_L = new Ray(F_LeftSensor.transform.position, F_LeftSensor.transform.forward);
        ray_F_R = new Ray(F_RightSensor.transform.position, F_RightSensor.transform.forward);
        ray_F = new Ray(FrontSensor.transform.position, FrontSensor.transform.forward);
        ray_B = new Ray(BackSensor.transform.position, BackSensor.transform.forward);
        ray_B_L = new Ray(B_LeftSensor.transform.position, B_LeftSensor.transform.forward);
        ray_B_R = new Ray(B_RightSensor.transform.position, B_RightSensor.transform.forward);
        Physics.Raycast(ray_F_L, out rayHit_F_L, Sensor_Distance);
        Physics.Raycast(ray_F_R, out rayHit_F_R, Sensor_Distance);
        Physics.Raycast(ray_F, out rayHit_F, Sensor_Distance);
        Physics.Raycast(ray_B, out rayHit_B, Sensor_Distance);
        Physics.Raycast(ray_B_L, out rayHit_B_L, Sensor_Distance);
        Physics.Raycast(ray_B_R, out rayHit_B_R, Sensor_Distance);

        //print("좌측 센서 감지된 거리 : " + rayHit_F_L.distance + "\n" + "우측 센서 감지된 거리 : " + rayHit_F_R.distance);
                

        switch(FallBack)
        {
            case (int)Solution.Nothing:
                {
                    // 앞 좌우 판정 =======================================================

                    if (rayHit_F_L.distance < rayHit_F_R.distance)
                    {
                        //우회전
                        transform.Rotate(new Vector3(0, 5 * moveDelta, 0));
                        if (Y_Angle < 30.0f)
                        {
                            OtherAxis_L.transform.Rotate(dirToTarget_L, rot, Space.Self);
                            OtherAxis_R.transform.Rotate(dirToTarget_R, rot, Space.Self);
                        }

                    }
                    else if (rayHit_F_L.distance > rayHit_F_R.distance)
                    {
                        //좌회전
                        transform.Rotate(new Vector3(0, -5 * moveDelta, 0));
                        if (Y_Angle > -30.0f)
                        {
                            OtherAxis_L.transform.Rotate(dirToTarget_L, -rot, Space.Self);
                            OtherAxis_R.transform.Rotate(dirToTarget_R, -rot, Space.Self);
                        }
                    }
                    else
                    {
                        float ToZero = Y_Angle > 0 ? -rot : rot;
                        OtherAxis_L.transform.Rotate(dirToTarget_L, ToZero, Space.Self);
                        OtherAxis_R.transform.Rotate(dirToTarget_R, ToZero, Space.Self);
                    }

                    // 정면으로 쏜 센서가 특정 거리 미만일 때 ===========================================
                    if (rayHit_F.distance < FB_Sensor_Distance)
                    {
                        // 후진
                        transform.Translate(Vector3.back * moveDelta * 2);

                        // 바퀴들 후진
                        Wheel_Left.transform.Rotate(0, -rot, 0, Space.Self);
                        Wheel_Right.transform.Rotate(0, -rot, 0, Space.Self);
                        Wheel_BLeft.transform.Rotate(0, -rot, 0, Space.Self);
                        Wheel_BRight.transform.Rotate(0, -rot, 0, Space.Self);

                        if (rayHit_B_L.distance < rayHit_B_R.distance)
                        {
                            FallBack = (int)Solution.B_L;
                            break;
                        }
                        else if (rayHit_B_L.distance > rayHit_B_R.distance)
                        {
                            FallBack = (int)Solution.B_R;
                            break;
                            //transform.Rotate(new Vector3(0, -5 * moveDelta * 2, 0));
                            //if (Y_Angle < 30.0f)
                            //{
                            //    OtherAxis_L.transform.Rotate(dirToTarget_L, rot, Space.Self);
                            //    OtherAxis_R.transform.Rotate(dirToTarget_R, rot, Space.Self);
                            //}
                        }

                    }
                    else
                    {
                        // 앞으로 전진
                        transform.Translate(Vector3.forward * moveDelta);

                        // 바퀴들 전진
                        Wheel_Left.transform.Rotate(0, rot, 0, Space.Self);
                        Wheel_Right.transform.Rotate(0, rot, 0, Space.Self);
                        Wheel_BLeft.transform.Rotate(0, rot, 0, Space.Self);
                        Wheel_BRight.transform.Rotate(0, rot, 0, Space.Self);
                    }
                }
                break;

            case (int)Solution.B_L:
                // 후진
                transform.Translate(Vector3.back * moveDelta);

                // 바퀴들 후진
                Wheel_Left.transform.Rotate(0, -rot, 0, Space.Self);
                Wheel_Right.transform.Rotate(0, -rot, 0, Space.Self);
                Wheel_BLeft.transform.Rotate(0, -rot, 0, Space.Self);
                Wheel_BRight.transform.Rotate(0, -rot, 0, Space.Self);

                transform.Rotate(new Vector3(0, 7 * moveDelta, 0));
                if (Y_Angle < 30.0f)
                {
                    OtherAxis_L.transform.Rotate(dirToTarget_L, rot, Space.Self);
                    OtherAxis_R.transform.Rotate(dirToTarget_R, rot, Space.Self);
                }

                

                if (rayHit_B.distance <= FB_Sensor_Distance)
                    FallBack = (int)Solution.Nothing;

                break;
            case (int)Solution.B_R:
                // 후진
                transform.Translate(Vector3.back * moveDelta);

                // 바퀴들 후진
                Wheel_Left.transform.Rotate(0, -rot, 0, Space.Self);
                Wheel_Right.transform.Rotate(0, -rot, 0, Space.Self);
                Wheel_BLeft.transform.Rotate(0, -rot, 0, Space.Self);
                Wheel_BRight.transform.Rotate(0, -rot, 0, Space.Self);

                transform.Rotate(new Vector3(0, -7 * moveDelta, 0));
                if (Y_Angle > -30.0f)
                {
                    OtherAxis_L.transform.Rotate(dirToTarget_L, -rot, Space.Self);
                    OtherAxis_R.transform.Rotate(dirToTarget_R, -rot, Space.Self);
                }

                if (rayHit_B.distance <= FB_Sensor_Distance)
                    FallBack = (int)Solution.Nothing;
                break;
            case (int)Solution.F_L:
                break;
            case (int)Solution.F_R:
                break;
        }

        if (FallBack == (int)Solution.Nothing)
        {
            
        }
        
        
    }

}

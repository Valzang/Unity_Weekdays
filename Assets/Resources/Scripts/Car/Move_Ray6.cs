using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Move_Ray6 : MonoBehaviour
{
    [SerializeField]
    [Range(0,100)]
    public float moveSpeed = 20.0f;

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

    private int FallBack;


    void Start()
    {
        FallBack = (int)Solution.Nothing;
        ray_F_L = new Ray(F_LeftSensor.transform.position, F_LeftSensor.transform.forward);
        ray_F_R = new Ray(F_RightSensor.transform.position, F_RightSensor.transform.forward);
        ray_F = new Ray(FrontSensor.transform.position, FrontSensor.transform.forward);
        ray_B = new Ray(BackSensor.transform.position, BackSensor.transform.forward);
        ray_B_L = new Ray(B_LeftSensor.transform.position, B_LeftSensor.transform.forward);
        ray_B_R = new Ray(B_RightSensor.transform.position, B_RightSensor.transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        SetRay(ref ray_F_L, F_LeftSensor);
        SetRay(ref ray_F_R, F_RightSensor);
        SetRay(ref ray_F, FrontSensor);
        SetRay(ref ray_B, BackSensor);
        SetRay(ref ray_B_L, B_LeftSensor);
        SetRay(ref ray_B_R, B_RightSensor);

        rayHit_F_L = Physics.RaycastAll(ray_F_L, Sensor_Distance).OrderBy(h => h.distance).Where(h => h.transform.tag == "Obstacle").FirstOrDefault();
        //rayHit_F_L = Physics.RaycastAll(ray_F_L, Sensor_Distance);
        rayHit_F_R = Physics.RaycastAll(ray_F_R, Sensor_Distance).OrderBy(h => h.distance).Where(h => h.transform.tag == "Obstacle").FirstOrDefault();
        rayHit_F = Physics.RaycastAll(ray_F, FB_Sensor_Distance).OrderBy(h => h.distance).Where(h => h.transform.tag == "Obstacle").FirstOrDefault();
        rayHit_B = Physics.RaycastAll(ray_B, FB_Sensor_Distance).OrderBy(h => h.distance).Where(h => h.transform.tag == "Obstacle").FirstOrDefault();
        rayHit_B_L = Physics.RaycastAll(ray_B_L, Sensor_Distance).OrderBy(h => h.distance).Where(h => h.transform.tag == "Obstacle").FirstOrDefault();
        rayHit_B_R = Physics.RaycastAll(ray_B_R, Sensor_Distance).OrderBy(h => h.distance).Where(h => h.transform.tag == "Obstacle").FirstOrDefault();
        Ray_Move();
    }       

    void Ray_Move()
    {
        float moveDelta = moveSpeed * Time.deltaTime;
        float rot = 150.0f * Time.deltaTime * 5;

       
        // ������ ������ ���� ��====================================
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

        switch (FallBack)
        {
            case (int)Solution.Nothing:
                {
                    // �� �¿� ���� =======================================================

                    //print("���� ���� ���� :" + rayHit_F_L.distance);
                    //print("���� ���� ���� :" + rayHit_F_R.distance);
                    if (rayHit_F_L.distance < rayHit_F_R.distance)
                    {
                        //��ȸ��
                        transform.Rotate(new Vector3(0, 5 * moveDelta, 0));
                        if (Y_Angle < 30.0f)
                        {
                            OtherAxis_L.transform.Rotate(dirToTarget_L, rot, Space.Self);
                            OtherAxis_R.transform.Rotate(dirToTarget_R, rot, Space.Self);
                        }

                    }
                    else if (rayHit_F_L.distance > rayHit_F_R.distance)
                    {
                        //��ȸ��
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

                    // �������� �� ������ Ư�� �Ÿ� �̸��� �� ===========================================
                    //if(rayHit_F.distance != 0.0f
                    //    && rayHit_F.distance < FB_Sensor_Distance)
                    //{
                    //    // ����
                    //    transform.Translate(Vector3.back * moveDelta * 2);

                    //    // ������ ����
                    //    Wheel_Left.transform.Rotate(0, -rot, 0, Space.Self);
                    //    Wheel_Right.transform.Rotate(0, -rot, 0, Space.Self);
                    //    Wheel_BLeft.transform.Rotate(0, -rot, 0, Space.Self);
                    //    Wheel_BRight.transform.Rotate(0, -rot, 0, Space.Self);

                    //    if (rayHit_B_L.distance < rayHit_B_R.distance)
                    //    {
                    //        FallBack = (int)Solution.B_L;
                    //        break;
                    //    }
                    //    else if (rayHit_B_L.distance > rayHit_B_R.distance)
                    //    {
                    //        FallBack = (int)Solution.B_R;
                    //        break;
                    //    }

                    //}
                    //else
                    {
                        // ������ ����
                        transform.Translate(Vector3.forward * moveDelta);

                        // ������ ����
                        Wheel_Left.transform.Rotate(0, rot, 0, Space.Self);
                        Wheel_Right.transform.Rotate(0, rot, 0, Space.Self);
                        Wheel_BLeft.transform.Rotate(0, rot, 0, Space.Self);
                        Wheel_BRight.transform.Rotate(0, rot, 0, Space.Self);
                    }
                }
                break;

            case (int)Solution.B_L:
                {
                    // ����
                    transform.Translate(Vector3.back * moveDelta);

                    // ������ ����
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

                    if (rayHit_B.distance != 0.0f
                        && rayHit_B.distance <= FB_Sensor_Distance)
                        FallBack = (int)Solution.Nothing;
                }
                break;
            case (int)Solution.B_R:
                {
                    // ����
                    transform.Translate(Vector3.back * moveDelta);

                    // ������ ����
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

                    if (rayHit_B.distance != 0.0f
                        && rayHit_B.distance <= FB_Sensor_Distance)
                        FallBack = (int)Solution.Nothing;
                }                
                break;
            case (int)Solution.F_L:
                break;
            case (int)Solution.F_R:
                break;
        }        
        
    }    

    private void SetRay(ref Ray _Ray, GameObject _Sensor)
    {
        _Ray.origin = _Sensor.transform.position;
        _Ray.direction = _Sensor.transform.forward;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision != null && collision.gameObject.tag == "Car")
        {            
            moveSpeed = 10.0f;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision != null && collision.gameObject.tag == "Car")
        {
            moveSpeed = 20.0f;
        }
    }

}

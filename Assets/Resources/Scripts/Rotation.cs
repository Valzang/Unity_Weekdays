using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{    

    public GameObject FrontAxis = null;
    public GameObject BackAxis = null;
    public GameObject Wheel_Left = null;
    public GameObject Wheel_Right = null;
    public GameObject Wheel_BLeft = null;
    public GameObject Wheel_BRight = null;

    // Start is called before the first frame update
    void Start()
    {        
        //Rotate_1();
        //Rotate_2();
        //Rotate_3();
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate_4();
        //Rotate_5();
        //Rotate_6();
        //Look_At_1();
        //Look_At_2();
        Input_Rotate();
    }

    //Wolrd 절대좌표 기준
    void Rotate_1()
    {
        // 오일러 회전, 반복적으로 하게 되면 짐벌락 현상이 일어날 수 있음.
        //transform.eulerAngles = new Vector3(0.0f, 45.0f, 0.0f);

        // 반복적으로 할거 같으면 Quatrernion으로 회전하는 걸 권장.
        Quaternion target = Quaternion.Euler(0.0f, 45.0f, 0.0f);
        transform.rotation = target;
    }

    // Local 상대좌표 기준
    void Rotate_2()
    {
        transform.Rotate(Vector3.up * 45.0f);
    }

    void Rotate_3()
    {
        transform.rotation *= Quaternion.AngleAxis(45.0f, Vector3.up);
    }

    float speed = 150.0f;
    void Rotate_4()
    {
        float rot = speed * Time.deltaTime;
        transform.rotation *= Quaternion.AngleAxis(rot, Vector3.up);
    }

    void Rotate_5()
    {
        float rot = speed * Time.deltaTime;
        transform.Rotate(Vector3.up * rot);
    }

    void Rotate_6()
    {
        float rot = speed * Time.deltaTime;
        this.transform.RotateAround(
            new Vector3(3, 0, 0),   // 기준점
            Vector3.up, // 회전 방향
            rot // 회전 각도
            );
    }

    //void Look_At_1()
    //{
    //    Vector3 dirToTarget = target.transform.position - this.transform.position;
    //    this.transform.forward = dirToTarget.normalized;
    //}
    //
    //void Look_At_2()
    //{
    //    Vector3 dirToTarget = target.transform.position - this.transform.position;
    //    this.transform.rotation = Quaternion.LookRotation(dirToTarget, Vector3.up);
    //}

    void MatchWithWheel()
    {
        //Vector3 dirToTarget = this.transform.position - target.transform.position;
        //this.transform.rotation = Quaternion.LookRotation(dirToTarget, Vector3.up);
    }

    void Input_Rotate()
    {       

        if (Input.GetKey(KeyCode.A))
        {
            float rot = speed * Time.deltaTime;
            Vector3 UpTarget = this.transform.position;
            UpTarget.y += 2;
            Vector3 dirToTarget = UpTarget - this.transform.position;
            dirToTarget = dirToTarget.normalized;
            //print("좌측 y각도 : " + FrontAxis.transform.rotation.eulerAngles.y);

            float Y_Angle = FrontAxis.transform.rotation.eulerAngles.y;
            Y_Angle += (Y_Angle > 180 ? -360 : 0);

            if (Y_Angle > -30.0f)
                FrontAxis.transform.Rotate(new Vector3(0, -rot, 0));
        }

        if (Input.GetKey(KeyCode.D))
        {
            float rot = speed * Time.deltaTime;
            Vector3 UpTarget = this.transform.position;
            UpTarget.y += 2;
            Vector3 dirToTarget = UpTarget - this.transform.position;
            dirToTarget = dirToTarget.normalized;

            float Y_Angle = FrontAxis.transform.rotation.eulerAngles.y;
            Y_Angle += (Y_Angle > 180 ? -360 : 0);

            if (Y_Angle < 30.0f)
                FrontAxis.transform.Rotate(new Vector3(0, rot, 0));
            //FrontAxis.transform.Rotate(dirToTarget, rot, Space.Self);


        }

        if (Input.GetKey(KeyCode.S))
        {
            float rot = speed * Time.deltaTime * 5;
            Wheel_Left.transform.Rotate(0, -rot, 0, Space.Self);
            Wheel_Right.transform.Rotate(0, -rot, 0, Space.Self);
            Wheel_BLeft.transform.Rotate(0, -rot, 0, Space.Self);
            Wheel_BRight.transform.Rotate(0, -rot, 0, Space.Self);           
        }

        if (Input.GetKey(KeyCode.W))
        {
            float rot = speed * Time.deltaTime * 5;
            Wheel_Left.transform.Rotate(0, rot, 0, Space.Self);
            Wheel_Right.transform.Rotate(0, rot, 0, Space.Self);
            Wheel_BLeft.transform.Rotate(0, rot, 0, Space.Self);
            Wheel_BRight.transform.Rotate(0, rot, 0, Space.Self);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heli_Move : MonoBehaviour
{
    [SerializeField]
    [Range(0, 10)]
    public float moveSpeed = 10.0f;

    public GameObject OtherAxis = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Input_Move();
    }

    void Input_Move()
    {

        float moveDelta = this.moveSpeed * Time.deltaTime;

        Vector3 UpTarget = transform.position;
        UpTarget.y += 2;
        Vector3 dirToTarget = UpTarget - transform.position;
        dirToTarget = dirToTarget.normalized;

        float Y_Angle = transform.localRotation.eulerAngles.y;
        Y_Angle += (Y_Angle > 180 ? -360 : 0);

        //===========================================

        Vector3 FrontTarget = OtherAxis.transform.localPosition;
        FrontTarget.y += 2;
        Vector3 dirToTarget_Body = FrontTarget - transform.position;
        dirToTarget_Body = dirToTarget_Body.normalized;

        float X_Angle = OtherAxis.transform.localRotation.eulerAngles.x;
        float Z_Angle = OtherAxis.transform.localRotation.eulerAngles.z;

        //Z_Angle += 90.0f;
        X_Angle += (X_Angle > 180 ? -360 : 0);
        Z_Angle += (Z_Angle > 180 ? -360 : 0);

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveDelta * 2.0f);

            if (X_Angle < 15.0f)
                OtherAxis.transform.Rotate(moveDelta * 4.0f, 0, 0, Space.Self);

            if (Input.GetKey(KeyCode.A) && Z_Angle < 30.0f)
            {
                OtherAxis.transform.Rotate(0, 0, moveDelta * 4.0f, Space.Self);
            }
            else if (Input.GetKey(KeyCode.D) && Z_Angle > -30.0f)
            {
                OtherAxis.transform.Rotate(0, 0, -moveDelta * 4.0f, Space.Self);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * moveDelta * 2.0f);

            if (X_Angle > -15.0f)
                OtherAxis.transform.Rotate(moveDelta * -4.0f, 0, 0, Space.Self);

            if (Input.GetKey(KeyCode.A) && Z_Angle < 30.0f)
            {
                OtherAxis.transform.Rotate(0, 0, moveDelta * 4.0f, Space.Self);
            }
            else if (Input.GetKey(KeyCode.D) && Z_Angle > -30.0f)
            {
                OtherAxis.transform.Rotate(0, 0, -moveDelta * 4.0f, Space.Self);
            }
        }
        else
        {
            float ToZero = X_Angle > 0 ? moveDelta * -5.0f : moveDelta * 5.0f;
            float ToZero2 = Z_Angle > 0 ? moveDelta * -7.0f : moveDelta * 7.0f;
            OtherAxis.transform.Rotate(ToZero, 0, ToZero2, Space.Self);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(dirToTarget, -7 * moveDelta, Space.Self);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(dirToTarget, 7 * moveDelta, Space.Self);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * moveDelta);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.Translate(Vector3.down * moveDelta);
        }

        OtherAxis.transform.localRotation = new Quaternion(OtherAxis.transform.localRotation.x, 0, OtherAxis.transform.localRotation.z, OtherAxis.transform.localRotation.w);
    }
}

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
        Vector3 UpTarget = OtherAxis.transform.position;
        UpTarget.y += 2;
        Vector3 dirToTarget = UpTarget - OtherAxis.transform.position;
        dirToTarget = dirToTarget.normalized;

        float Y_Angle = OtherAxis.transform.localRotation.eulerAngles.y;
        Y_Angle += (Y_Angle > 180 ? -360 : 0);

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveDelta);            
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * moveDelta);            
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(dirToTarget, -6* moveDelta, Space.Self);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(dirToTarget, 6 * moveDelta, Space.Self);
        }
        //else 
        //{
        //    float ToZero = Y_Angle > 0 ? -6 * moveDelta : 6 * moveDelta;
        //    transform.Rotate(dirToTarget, ToZero, Space.Self);
        //}

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * moveDelta);
        }

        if (Input.GetKey(KeyCode.C))
        {
            transform.Translate(Vector3.down * moveDelta);
        }
    }
}

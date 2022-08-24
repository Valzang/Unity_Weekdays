using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    [Range(0,10)]
    public float moveSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        // World ��ǥ ����
        //this.transform.position = new Vector3(0.0f, 5.0f, 0.0f);

        // Local ��ǥ ����
        //this.transform.Translate(new Vector3(0.0f, 5.0f, 0.0f));
    }

    // Update is called once per frame
    void Update()
    {
        //Move_1();  
        //Move_2();
        Input_Move();
    }

    void Move_1()
    {
        // ���� Wolrd ��ǥ ����
        float moveDelta = this.moveSpeed * Time.deltaTime;
        Vector3 pos = transform.position;
        pos.z += moveDelta;
        transform.position = pos;
    }

    void Move_2()
    {
        // ��� Local ��ǥ ����
        float moveDelta = this.moveSpeed * Time.deltaTime;
        transform.Translate(Vector3.forward * moveDelta);        
        // forward�� Vector3(0,0,1)�� ��������
        // �� �ܿ� Vector3.up ; Vector3.down; Vector3.right; Vector3.back; Vector3.left ���� ����
    }

    void Input_Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            float moveDelta = this.moveSpeed * Time.deltaTime;
            transform.Translate(Vector3.forward * moveDelta);
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(new Vector3(0, -2 * moveDelta, 0));
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(new Vector3(0, 2 * moveDelta, 0));
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            float moveDelta = this.moveSpeed * Time.deltaTime;
            transform.Translate(Vector3.back * moveDelta);
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(new Vector3(0, 2 * moveDelta, 0));
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(new Vector3(0, -2 * moveDelta, 0));
            }
        }
    }        

}

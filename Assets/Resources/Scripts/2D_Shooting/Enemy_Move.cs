using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy_Move : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    [SerializeField]
    private float maxSpeed = 250.0f;
    [SerializeField]
    private GameObject Waterball = null;

    private float waterBall_Cooltime = 1.5f;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Attack();
    }
    private void FixedUpdate()
    {
        Move_2D();
    }

    void Attack()
    {
        if (waterBall_Cooltime >= 2.0f)
        {
            Vector3 curPos = transform.position;
            Vector3 curRot = transform.localRotation.eulerAngles;

            Instantiate(Waterball, curPos, Quaternion.Euler(curRot));
            curRot.z += 30;
            Instantiate(Waterball, curPos, Quaternion.Euler(curRot));
            curRot.z -= 60;
            Instantiate(Waterball, curPos, Quaternion.Euler(curRot));
            waterBall_Cooltime = 0.0f;
        }
        waterBall_Cooltime += Time.deltaTime;
    }

    void Move_2D()
    {
        Vector3 position = rigidBody.transform.position;
        position = new Vector3(position.x + (-maxSpeed * Time.deltaTime),
                                position.y,
                                position.z);
        rigidBody.MovePosition(position);
        if (position.x <= -480.0f)
            Destroy(this.gameObject);
    }

}

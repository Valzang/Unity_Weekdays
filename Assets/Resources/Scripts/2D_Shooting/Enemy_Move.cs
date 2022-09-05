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
        waterBall_Cooltime = ShootingGameManager.Instance.waterball_time;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Attack();
    }
    private void FixedUpdate()
    {
        if(rigidBody.transform.position.x >= 315.0f)
            Move_2D();
        if (ShootingGameManager.Instance.BossPhase != ShootingGameManager.Instance.prev_BossPhase)
        {
            if(ShootingGameManager.Instance.waterball_time > 0.2f)
                ShootingGameManager.Instance.waterball_time -= 0.1f;
            ++ShootingGameManager.Instance.prev_BossPhase;
        }
            
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

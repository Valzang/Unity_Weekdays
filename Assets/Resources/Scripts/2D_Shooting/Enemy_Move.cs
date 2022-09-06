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
    private float delta_Y;

    void Start()
    {
        waterBall_Cooltime = ShootingGameManager.Instance.waterball_time;
        rigidBody = GetComponent<Rigidbody2D>();
        int random = Random.Range(0, 2);
        delta_Y = random ==0 ? maxSpeed*1.2f * Time.deltaTime : -maxSpeed * 1.2f * Time.deltaTime;
    }

    private void Update()
    {
        Move_2D();
        Attack();
    }
    private void FixedUpdate()
    {
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

        if (transform.position.x >= 330.0f)
            position.x -= maxSpeed * Time.deltaTime;

        if (position.y > 124.5f)
            delta_Y *= -1.0f;
        else if (position.y < -240.0f)
            delta_Y *= -1.0f;
        position.y += delta_Y;        

        rigidBody.MovePosition(position);
    }

}

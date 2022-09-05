using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Boss : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    [SerializeField]
    private float maxSpeed = 250.0f;
    [SerializeField]
    private GameObject AttackProj = null;

    private float Attack_Cooltime = 1.5f;
    private float Projectile_Angle = 80.0f;
    private float deltaAngle = 7.5f;
    private float delta_Y;

    void Start()
    {
        delta_Y = maxSpeed / 1.5f * Time.deltaTime;
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
        if (Attack_Cooltime >= 0.2f)
        {
            Vector3 curPos = transform.position;
            Vector3 curRot = transform.localRotation.eulerAngles;

            curPos.x += 5;
            curPos.y += 20;
            curRot.z += Projectile_Angle;
            if (Projectile_Angle < -80.0f)
                deltaAngle = 7.5f;
            else if (Projectile_Angle > 80.0f)
                deltaAngle = -7.5f;

            Instantiate(AttackProj, curPos, Quaternion.Euler(curRot));
            Projectile_Angle += deltaAngle;

            Attack_Cooltime = 0.0f;
        }
        Attack_Cooltime += Time.deltaTime;
    }

    void Move_2D()
    {
        Vector3 position = rigidBody.transform.position;

        if (transform.position.x >= 330.0f)
            position.x -= maxSpeed * Time.deltaTime;

       
        if (position.y > 8.5f)
            delta_Y *= -1.0f;
        else if (position.y < -102.0f)
            delta_Y *= -1.0f;
        position.y += delta_Y;

        rigidBody.MovePosition(position);
        if (position.x <= -480.0f)
            Destroy(this.gameObject);
    }
}

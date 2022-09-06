using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Boss : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    [SerializeField]
    private float maxSpeed = 250.0f;
    [SerializeField]
    private GameObject AttackProj = null;
    [SerializeField]
    private Image HPBar = null;
    [SerializeField]
    private GameObject DamageObj = null;

    private float HP = 100.0f;
    private float Attack_Cooltime = 1.5f;
    private float Projectile_Angle = 80.0f;
    private float deltaAngle = 7.5f;
    private float delta_Y;
    private AudioSource DamageSound = null;

    void Start()
    {
        delta_Y = maxSpeed / 1.5f * Time.deltaTime;
        rigidBody = GetComponent<Rigidbody2D>();
        DamageSound = DamageObj.GetComponent<AudioSource>();
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
            if (Projectile_Angle < -60.0f)
                deltaAngle = 7.5f;
            else if (Projectile_Angle > 60.0f)
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectiles"))
        {
            HP -= 7.0f;
            if (HP <= 0.0f)
            {
                ShootingGameManager.Instance.Player_Score += 3000;
                Destroy(this.gameObject);
                return;
            }
            HPBar.fillAmount = HP / 100.0f;
            DamageSound.Play();
        }
    }

}


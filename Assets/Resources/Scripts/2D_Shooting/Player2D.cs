using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Player2D : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    [SerializeField]
    private float maxSpeed = 250.0f;
    [SerializeField]
    private GameObject Fireball = null;


    private float Fireball_Cooltime = 1.0f;

    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {        
        Attack();
    }

    private void FixedUpdate()
    {
        Move_2D();
    }

    void Move_2D()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 position = rigidBody.transform.position;
        position = new Vector3(position.x + (x * maxSpeed * Time.deltaTime),
                                position.y + (y * maxSpeed * Time.deltaTime),
                                position.z);

        rigidBody.MovePosition(position);
    }

    void Attack()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl) && Fireball_Cooltime >= 1.0f)
        {
            Vector3 curPos = transform.position;
            curPos.x += 80;
            curPos.y -= 10;
            Instantiate(Fireball, curPos, transform.rotation);
            Fireball_Cooltime = 0.0f;
        }
        Fireball_Cooltime += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            ShootingGameManager.Instance.Player_Money += 100;
            print("Á¡¼ö : " + ShootingGameManager.Instance.Player_Money);
        }            
    }


    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    print("col : Àû°ú ºÎµúÇû¾î !");
    //}
}

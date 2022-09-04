using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy_Move : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    [SerializeField]
    private float maxSpeed = 250.0f;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move_2D();
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

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.tag)
        {
            case "Player":
                {
                    
                }
                print("tri : 플레이어와 부딪혔어 !");
                break;
            default:
                print("tri : 파이어볼에 맞았어 !");
                break;
        }
            

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    print("col : 플레이어와 부딪혔어 !");
    //}
}

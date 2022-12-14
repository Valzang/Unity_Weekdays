using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Fireball_Move : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    [SerializeField]
    private float maxSpeed = 600.0f;
    [SerializeField]
    private GameObject Explosion = null;
    [SerializeField]
    private GameObject coinObj = null;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        float size = ShootingGameManager.Instance.Fireball_size;
        Vector3 lScale = this.gameObject.transform.localScale;
        this.gameObject.transform.localScale = new Vector3(lScale.x * size, lScale.y * size, lScale.z * size);
    }

   
    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        Vector3 position = rigidBody.transform.position;
        position = new Vector3(position.x + (maxSpeed * Time.deltaTime),
                                position.y,
                                position.z);
        rigidBody.MovePosition(position);
        if (position.x >= 430.0f)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Instantiate(coinObj, collision.transform.position, collision.transform.rotation);
            Instantiate(Explosion, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
            ShootingGameManager.Instance.Player_Score += 100;
            if(ShootingGameManager.Instance.Fireball_Pierce == false)
                Destroy(this.gameObject);
        }
        else if (collision.CompareTag("Enemy_Boss"))
        {
            Instantiate(Explosion, collision.transform.position, collision.transform.rotation);
            if (ShootingGameManager.Instance.Fireball_Pierce == false)
                Destroy(this.gameObject);
        }
    }
}

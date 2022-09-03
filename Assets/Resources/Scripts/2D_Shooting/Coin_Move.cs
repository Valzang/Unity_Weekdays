using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class Coin_Move : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private AudioSource _Sound;

    [SerializeField]
    private AudioClip coinSound = null;

    [SerializeField]
    private float maxSpeed = 250.0f;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        _Sound = GetComponent<AudioSource>();
        _Sound.clip = coinSound;
        _Sound.loop = false;
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
        if (collision.tag == "Player")
        {
            _Sound.Play();
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    float speedMove = 20.0f;
    float speedRotate = 80.0f;

    Rigidbody rigidBody;

    void Start()
    {
        rigidBody = this.gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float rotate = Input.GetAxis("Horizontal");
        float move = Input.GetAxis("Vertical");

        rotate = rotate * speedRotate * Time.deltaTime;
        move = move * speedMove * Time.deltaTime;

        transform.Rotate(Vector3.up * rotate);
        transform.Translate(Vector3.forward * move);

    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        if(hitObject.tag == "Obstacle")
            print("충돌 시작 : " + hitObject.name);
    }

    private void OnCollisionStay(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        if (hitObject.tag == "Obstacle")
            print("충돌 중 : " + hitObject.name);
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        if (hitObject.tag == "Obstacle")
            print("충돌 끝 : " + hitObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject hitObject = other.gameObject;
        if (hitObject.tag == "Obstacle")
            print("트리거 시작 : " + hitObject.name);
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject hitObject = other.gameObject;
        if (hitObject.tag == "Obstacle")
            print("트리거 중 : " + hitObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject hitObject = other.gameObject;
        if (hitObject.tag == "Obstacle")
            print("트리거 끝 : " + hitObject.name);
    }
}

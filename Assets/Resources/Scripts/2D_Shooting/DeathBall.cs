using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DeathBall : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    [SerializeField]
    private float maxSpeed = 600.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        Vector3 position = rigidBody.transform.position;
        float delta_X = (-maxSpeed * Time.deltaTime);
        float delta_Y = 0;
        if (transform.localRotation.eulerAngles.z != 0)
        {
            float curRot = transform.localRotation.eulerAngles.z;
            curRot = curRot > 180.0f ? curRot - 360.0f : curRot;
            delta_Y = curRot < 0
                ? Mathf.Cos((90 + curRot) * Mathf.PI / 180.0f) * Mathf.Abs(delta_X)
                : Mathf.Cos((90 - curRot) * Mathf.PI / 180.0f) * -Mathf.Abs(delta_X);

            delta_X = Mathf.Cos(Mathf.Abs(curRot) * Mathf.PI / 180.0f) * delta_X;
        }

        position = new Vector3(position.x + delta_X,
                                position.y + delta_Y,
                                position.z);
        rigidBody.MovePosition(position);
        if (position.x <= -480.0f)
            Destroy(this.gameObject);
    }
}

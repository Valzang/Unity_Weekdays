using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Move : MonoBehaviour
{
    private float moveSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 Cylinder1 = transform.GetChild(0).gameObject.transform.position;
        Vector3 Cylinder2 = transform.GetChild(1).gameObject.transform.position;
        transform.GetChild(0).gameObject.transform.position = new Vector3(Cylinder1.x, Cylinder1.y-(0.6f* FlappyGameManager.Instance.Difficulty), Cylinder1.z);
        transform.GetChild(1).gameObject.transform.position = new Vector3(Cylinder2.x, Cylinder2.y+(0.6f* FlappyGameManager.Instance.Difficulty), Cylinder2.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 nextPos = this.transform.position;
        nextPos.z -= moveSpeed * Time.deltaTime;
        this.transform.position = new Vector3(nextPos.x, nextPos.y, nextPos.z);
        if (Camera.main.WorldToViewportPoint(transform.position).x < -0.1f)
        {
            print("장애물 삭제");
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public GameObject DragonAxis = null;
    public Spawner spawnerObj;
    public float jumpPower = 10.0f;
    private bool TriggerEnter = false;
    float degree = 0.0f;


    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Camera.main.WorldToViewportPoint(transform.position).y - 0.45f) >= 0.5f)
        {
            print("����");
            spawnerObj.StopInvoke();
            FlappyGameManager.Instance.ChangeScene("#3_FlappyBird_Score");
            Destroy(this.gameObject);
        }
        if (Input.GetButtonDown("Jump"))
        {
            // ���, ������ �ӵ��� ����
            GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower, 0);

            // ����, ������ �� �����ϴ� �ӵ��� �ö� �� �����ϴ� �ӵ��� �ٸ�.
            //GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpPower*100.0f, 0));
        }

        float rot_x = GetComponent<Rigidbody>().velocity.y > 0 ? (GetComponent<Rigidbody>().velocity.y) * -4 : (GetComponent<Rigidbody>().velocity.y) * -2;

        DragonAxis.transform.eulerAngles = new Vector3(rot_x, DragonAxis.transform.eulerAngles.y, DragonAxis.transform.eulerAngles.z);
        degree += Time.deltaTime*16.0f;
        if (degree >= 360)
            degree = 0.0f;

        RenderSettings.skybox.SetFloat("_Rotation", degree);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            print("�浹��");
            spawnerObj.StopInvoke();
            FlappyGameManager.Instance.ChangeScene("#3_FlappyBird_Score");
            Destroy(this.gameObject);
        }
        else if (!TriggerEnter)
        {            
            TriggerEnter = true;
            FlappyGameManager.Instance.gameScore += 100;       
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Obstacle" && TriggerEnter)
        {
            TriggerEnter = false;
        }
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 260, 50), "SCORE : " + FlappyGameManager.Instance.gameScore.ToString());
    }
}

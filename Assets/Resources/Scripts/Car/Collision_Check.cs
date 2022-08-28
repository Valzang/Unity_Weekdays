using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Check : MonoBehaviour
{
    private int Nth = 0;
    private bool Enter_Exit = false;
    Vector3 UpTarget;
    Vector3 SideTarget;
    Vector3 dirToTarget_y;
    Vector3 dirToTarget_z;

    private double Start_Time = 0.0f;
    private double End_Time = 0.0f;

    private void Start()
    {
        ++GameManager.Instance.m_CarCount;
        UpTarget = transform.position;
        UpTarget.y += 2;
        SideTarget = transform.position;
        SideTarget.z += 2;
        dirToTarget_y = UpTarget - transform.position;
        dirToTarget_y = dirToTarget_y.normalized;

        dirToTarget_z = SideTarget - transform.position;
        dirToTarget_z = dirToTarget_z.normalized;
    }

    private void Update()
    {
        End_Time += Time.deltaTime;
        if (GameManager.Instance.m_Ranking.Length != GameManager.Instance.m_CarCount)
        {
            GameManager.Instance.m_Ranking = new string[GameManager.Instance.m_CarCount];
            GameManager.Instance.m_Ranking_Time = new double[GameManager.Instance.m_CarCount];
        }
        if(Nth == GameManager.Instance.Nth)
        {
            GameManager.Instance.m_Ranking[GameManager.Instance.Enter_Order] = this.name;
            GameManager.Instance.m_Ranking_Time[GameManager.Instance.Enter_Order++] = End_Time - Start_Time;
            this.gameObject.SetActive(false);
            if (GameManager.Instance.Enter_Order == GameManager.Instance.m_CarCount)
                GameManager.Instance.ChangeScene("#2_Race_End");
        }

        if (Mathf.Abs(transform.localRotation.eulerAngles.z) > 0.5)
        {
            this.transform.localEulerAngles = new Vector3(0, transform.localRotation.eulerAngles.y, 0.001f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LINE"
            && Enter_Exit == false)
        {
            ++Nth;
            print(this.name + " " + Nth + "πŸƒ˚ Ω√¿€");
            Enter_Exit = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "LINE"
            && Enter_Exit == true)
        {
            Enter_Exit = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spartan_Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject spartanObj = null;

    public int Total_Count = 5;
    public int Spawn_Count = 0;
    private float PhaseCounter = 10.0f;
    private bool isNewPhase = false;

    private void Start()
    {
        Total_Count = SpartanGameManager.Instance.TotalSpartan;
        InvokeRepeating(nameof(MakeObj), 1.0f, (4.0f - SpartanGameManager.Instance.Difficulty * 0.2f));
    }

    private void OnGUI()
    {
        GUIStyle temp = new()
        {
            fontSize = 40
        };
        temp.normal.textColor = Color.red;
        if (PhaseCounter < 10.0f)
            GUI.Box(new Rect(10, 110, 200, 50), "�� ��������� ���� �ð� : " + (int)PhaseCounter + "��", temp);
    }

    private void Update()
    {
        if(isNewPhase)
        {
            PhaseCounter -= Time.deltaTime;
            if(PhaseCounter <= 0.0f)
            {
                isNewPhase = false;
                PhaseCounter = 10.0f;
                InvokeRepeating(nameof(MakeObj), 0.0f, 4.0f - SpartanGameManager.Instance.Difficulty*0.2f);
                print("���� ���� �ӵ� : " + (4.0f - SpartanGameManager.Instance.Difficulty * 0.2f).ToString());
                ++SpartanGameManager.Instance.Difficulty;
                SpartanGameManager.Instance.TotalSpartan += 2;
                SpartanGameManager.Instance.DeadSpartan = 0;
            }
        }
        if (Spawn_Count == Total_Count)
        {
            //print("10�� �� �� ����� �����մϴ�");
            StopInvoke();
            Total_Count += 2;
            Spawn_Count = 0;
            isNewPhase = true;
        }
    }

    public void StopInvoke()
    {
        CancelInvoke("MakeObj");
        return;
    }

    void MakeObj()
    {
        if (Spawn_Count >= Total_Count)
            return;
        //GameObject obj = null;
        if (spartanObj != null)
        {
            float random = Random.Range(-4,5);
            Vector3 curPos = transform.position;
            curPos.x += random * 5.0f;
            Instantiate(spartanObj, curPos, transform.rotation);
            ++Spawn_Count;
        }
    }
}

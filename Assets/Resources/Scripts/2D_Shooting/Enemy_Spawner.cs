using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObject))]
public class Enemy_Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject wolfObj = null;

    //public int Total_Count = 5;
    //public int Spawn_Count = 0;
    //private float PhaseCounter = 15.0f;
    //private bool isNewPhase = false;

    private void Start()
    {
        InvokeRepeating(nameof(MakeObj), 1.0f, 2.0f);
    }

   //private void OnGUI()
   //{        
   //    if (PhaseCounter < 15.0f)
   //    {
   //        GUIStyle temp = new()
   //        {
   //            fontSize = 40
   //        };
   //        temp.normal.textColor = Color.red;
   //        GUI.Box(new Rect(10, 110, 200, 50), "�� ��������� ���� �ð� : " + (int)PhaseCounter + "��", temp);
   //    }
   //        
   //}

    public void StopInvoke()
    {
        CancelInvoke(nameof(MakeObj));
        return;
    }

    void MakeObj()
    {
        if (wolfObj != null)
        {
            float random = Random.Range(-185, 91);
            Vector3 curPos = new Vector3(440, random, 0);
            Instantiate(wolfObj, curPos, transform.rotation);
        }
    }
}

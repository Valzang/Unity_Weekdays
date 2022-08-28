using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Racing_Ranking : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnGUI()
    {
        GUI.Box(new Rect(320, 40, 330, 50), "��ŷ");
        GUI.Box(new Rect(320, 90, 30, 30), "����");
        GUI.Box(new Rect(350, 90, 150, 30), "�̸�");
        GUI.Box(new Rect(500, 90, 150, 30), "�ҿ� �ð�");
        for (int i=0; i<GameManager.Instance.m_CarCount; ++i)
        {
            GUI.Box(new Rect(320, 120 + 30 * i, 30, 30), "#" + i.ToString());
            GUI.Box(new Rect(350, 120 + 30 * i, 150, 30 ), GameManager.Instance.m_Ranking[i]);
            GUI.Box(new Rect(500, 120 + 30 * i, 150, 30), ((float)GameManager.Instance.m_Ranking_Time[i]).ToString() + " ��");
        }
        if (GUI.Button(new Rect(320, 270, 330, 50), "Game Restart"))
        {
            GameManager.Instance.ChangeScene("#2_Race_Circle_Setting");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Racing_Ranking : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnGUI()
    {
        GUI.Box(new Rect(320, 40, 330, 50), "랭킹");
        GUI.Box(new Rect(320, 90, 30, 30), "순위");
        GUI.Box(new Rect(350, 90, 150, 30), "이름");
        GUI.Box(new Rect(500, 90, 150, 30), "소요 시간");
        for (int i=0; i<GameManager.Instance.m_CarCount; ++i)
        {
            GUI.Box(new Rect(320, 120 + 30 * i, 30, 30), "#" + i.ToString());
            GUI.Box(new Rect(350, 120 + 30 * i, 150, 30 ), GameManager.Instance.m_Ranking[i]);
            GUI.Box(new Rect(500, 120 + 30 * i, 150, 30), ((float)GameManager.Instance.m_Ranking_Time[i]).ToString() + " 초");
        }
        if (GUI.Button(new Rect(320, 270, 330, 50), "Game Restart"))
        {
            GameManager.Instance.ChangeScene("#2_Race_Circle_Setting");
        }
    }
}

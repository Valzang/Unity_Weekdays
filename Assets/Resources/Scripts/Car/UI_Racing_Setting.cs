using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Racing_Setting : MonoBehaviour
{
    private void OnGUI()
    {
        GUI.Box(new Rect(310, 70, 260, 50), "설정");
        GUI.Box(new Rect(310, 120, 50, 30), "트랙 수");
        GUI.Box(new Rect(360, 120, 150, 30), GameManager.Instance.Nth.ToString());
        if (GUI.Button(new Rect(510, 120, 30, 30), "<="))
        {
            if(GameManager.Instance.Nth > 2)
                --GameManager.Instance.Nth;
        }
            
        if (GUI.Button(new Rect(540, 120, 30, 30), "=>"))
            ++GameManager.Instance.Nth;
        if (GUI.Button(new Rect(310, 270, 260, 50), "Game Start"))
        {
            GameManager.Instance.m_Ranking = new string[1];
            GameManager.Instance.m_CarCount = 0;
            GameManager.Instance.Enter_Order = 0;
            GameManager.Instance.ChangeScene("#2_Race_Circle");
        }
    }
}

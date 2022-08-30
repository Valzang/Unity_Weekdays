using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpartanSetting : MonoBehaviour
{
    private void OnGUI()
    {
        GUI.Box(new Rect(Screen.width/2.0f-130.0f, Screen.height / 3.0f + 50.0f, 260, 50), "설정");
        GUI.Box(new Rect(Screen.width / 2.0f - 130.0f, Screen.height / 3.0f + 100.0f, 50, 30), "난이도");
        GUI.Box(new Rect(Screen.width / 2.0f - 80.0f, Screen.height / 3.0f + 100.0f, 150, 30), SpartanGameManager.Instance.Difficulty.ToString());
        if (GUI.Button(new Rect(Screen.width / 2.0f + 70.0f, Screen.height / 3.0f + 100.0f, 30, 30), "<="))
        {
            if (SpartanGameManager.Instance.Difficulty > 1)
                --SpartanGameManager.Instance.Difficulty;
        }

        if (GUI.Button(new Rect(Screen.width / 2.0f + 100.0f, Screen.height / 3.0f + 100.0f, 30, 30), "=>"))
        {
            if (SpartanGameManager.Instance.Difficulty < 15)
                ++SpartanGameManager.Instance.Difficulty;
        }
        if (GUI.Button(new Rect(Screen.width / 2.0f - 130.0f, Screen.height / 3.0f+130.0f, 260, 50), "Game Start"))
        {
            SpartanGameManager.Instance.DeadSpartan = 0;
            SpartanGameManager.Instance.TotalDeadSpartan = 0;
            SpartanGameManager.Instance.TotalSpartan = 5 + SpartanGameManager.Instance.Difficulty*2;
            SpartanGameManager.Instance.ChangeScene("#4_Spartan_Defense");
        }

        GUIStyle temp = new GUIStyle();
        temp.normal.textColor = Color.black;        
        temp.fontSize = 100;
        GUI.Box(new Rect(Screen.width / 2.0f - 200.0f, Screen.height / 4.0f, 400, 100), "스파르탄", temp);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpartanSetting : MonoBehaviour
{
    private void OnGUI()
    {
        GUIStyle style = new(GUI.skin.button);
        style.normal.textColor = Color.yellow;
        style.fontSize = 30;
        style.alignment = TextAnchor.MiddleCenter;

        GUIStyle style_box = new(GUI.skin.box);
        style_box.normal.textColor = Color.yellow;
        style_box.fontSize = 30;
        style_box.alignment = TextAnchor.MiddleCenter;

        GUI.Box(new Rect(Screen.width / 2.0f - 160.0f, Screen.height / 1.5f, 320, 50), "설정", style_box);
        GUI.Box(new Rect(Screen.width / 2.0f - 160.0f, Screen.height / 1.5f + 50.0f, 120, 50), "난이도", style_box);
        GUI.Box(new Rect(Screen.width / 2.0f - 40.0f, Screen.height / 1.5f + 50.0f, 80, 50), SpartanGameManager.Instance.Difficulty.ToString(), style_box);
        if (GUI.Button(new Rect(Screen.width / 2.0f + 40.0f, Screen.height / 1.5f + 50.0f, 60, 50), "<=", style))
        {
            if (SpartanGameManager.Instance.Difficulty > 1)
                --SpartanGameManager.Instance.Difficulty;
        }

        if (GUI.Button(new Rect(Screen.width / 2.0f + 100.0f, Screen.height / 1.5f + 50.0f, 60, 50), "=>", style))
        {
            if (SpartanGameManager.Instance.Difficulty < 15)
                ++SpartanGameManager.Instance.Difficulty;
        }
        if (GUI.Button(new Rect(Screen.width / 2.0f - 160.0f, Screen.height / 1.5f + 100.0f, 320, 50), "Game Start", style))
        {
            SpartanGameManager.Instance.DeadSpartan = 0;
            SpartanGameManager.Instance.TotalDeadSpartan = 0;
            SpartanGameManager.Instance.TotalSpartan = 5 + SpartanGameManager.Instance.Difficulty*2;
            SpartanGameManager.Instance.ChangeScene("#4_Spartan_Defense");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpartanEnding : MonoBehaviour
{
    private void OnGUI()
    {

        if (GUI.Button(new Rect(Screen.width / 2.0f - 130, Screen.height / 2.0f + 127.5f, 260, 50), "Game Setting"))
        {
            SpartanGameManager.Instance.ChangeScene("#4_Spartan_Setting");
        }


        GUIStyle style_box = new(GUI.skin.box);
        style_box.normal.textColor = Color.yellow;
        style_box.fontSize = 80;
        style_box.alignment = TextAnchor.MiddleCenter;
        GUI.Box(new Rect(Screen.width / 2.0f-430, Screen.height / 2.0f-42.5f, 860, 85), "Á¡¼ö : " + SpartanGameManager.Instance.TotalDeadSpartan * 100.0f, style_box);
        //GUI.Box(new Rect(Screen.width / 2.0f - 130, Screen.height / 2.0f + 42.5f, 600, 85), (SpartanGameManager.Instance.TotalDeadSpartan * 100.0f).ToString(), temp);

    }
}

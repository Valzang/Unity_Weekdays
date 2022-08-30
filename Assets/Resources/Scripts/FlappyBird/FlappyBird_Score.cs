using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBird_Score : MonoBehaviour
{
    private void OnGUI()
    {
        GUI.Box(new Rect(310, 20, 260, 50), "���� : " + FlappyGameManager.Instance.gameScore);
        GUI.Box(new Rect(310, 70, 260, 50), "����");
        GUI.Box(new Rect(310, 120, 50, 30), "���̵�");
        string Difficulty_text = FlappyGameManager.Instance.Difficulty==1 ? "��" : 
            (FlappyGameManager.Instance.Difficulty == 2 ? "��" :"��");
        GUI.Box(new Rect(360, 120, 150, 30), Difficulty_text);
        if (GUI.Button(new Rect(510, 120, 30, 30), "<="))
        {
            if (FlappyGameManager.Instance.Difficulty > 0)
                --FlappyGameManager.Instance.Difficulty;
        }

        if (GUI.Button(new Rect(540, 120, 30, 30), "=>"))
        {
            if (FlappyGameManager.Instance.Difficulty < 2)
                ++FlappyGameManager.Instance.Difficulty;
        }
        if (GUI.Button(new Rect(310, 270, 260, 50), "Game Start"))
        {
            FlappyGameManager.Instance.gameScore = 0;
            GameManager.Instance.ChangeScene("#3_FlappyBird_Game");
        }
    }
}

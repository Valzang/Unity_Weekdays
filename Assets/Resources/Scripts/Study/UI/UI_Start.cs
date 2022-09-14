using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class UI_Start : MonoBehaviour
{    
    private void OnGUI()
    {
        if (GUI.Button(new Rect(380, 240, 150, 30), "Game Start"))
        {
            GameManager.Instance.ChangeScene("03 Game");
        }
    }
}

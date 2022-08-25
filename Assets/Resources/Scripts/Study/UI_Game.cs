using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class UI_Game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(380, 240, 150, 30), "∞‘¿”æ¿ »Æ¿Œ"))
        {
            GameManager.Instance.ChangeScene("99 End");
        }
    }
}

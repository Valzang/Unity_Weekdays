using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Default : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private int count = 0;
    private void OnGUI()
    {
        string str = "Text Test";
        string str2 = str + " 2";
        string str3 = "Click Count : " + count.ToString();
        GUI.TextArea(new Rect(200, 50, 100, 30), str);
        GUI.TextField(new Rect(200, 100, 100, 30), str2);
        GUI.Box(new Rect(200, 150, 150, 30), str3);

        if (GUI.Button(new Rect(200, 200, 150, 30), "버튼을 누르시오."))
        {
            ++count;
        }
    }
}

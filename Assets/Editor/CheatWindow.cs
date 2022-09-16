using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class CheatWindow : EditorWindow
{
    readonly string[] cheatList = new string[] { "치트", "골드 생성", "포인트 생성" };

    static int selectIndex = 0;

    int getInt = 0;
    string getString = "";

    [MenuItem("InhaMenu/SubMenu/Open Cheat_1", false, 0)]
    static public void OpenCheatWindow()
    {
        CheatWindow getWindow = EditorWindow.GetWindow<CheatWindow>(false, "Cheat Window", true);
    }

    private void OnGUI()
    {
        GUILayout.Space(10.0f);
        int getIndex = EditorGUILayout.Popup(selectIndex, cheatList, GUILayout.MaxWidth(200.0f));

        if (selectIndex != getIndex)
            selectIndex = getIndex;

        string cheatText = "";

        GUILayout.BeginHorizontal(GUILayout.MaxWidth(300.0f));
        {

            switch (selectIndex)
            {
                case 0: // CHEAT
                    GUILayout.Label("치트키 입력", GUILayout.Width(70.0f));
                    getString = EditorGUILayout.TextField(getString, GUILayout.Width(100.0f));
                    cheatText = string.Format("치트키 : {0}", getString);
                    break;
                case 1: // GOLD
                    GUILayout.Label("골드", GUILayout.Width(70.0f));
                    getString = EditorGUILayout.TextField(getInt.ToString(), GUILayout.Width(100.0f));
                    int.TryParse(getString, out getInt);
                    cheatText = string.Format("골드 : {0}", getInt);
                    break;
                case 2: // POINT
                    GUILayout.Label("포인트", GUILayout.Width(70.0f));
                    getString = EditorGUILayout.TextField(getInt.ToString(), GUILayout.Width(100.0f));
                    int.TryParse(getString, out getInt);
                    cheatText = string.Format("포인트 : {0}", getInt);
                    break;
            }
        }
        GUILayout.EndHorizontal();

        //===========================================================================

        GUILayout.Space(20.0f);
        GUILayout.BeginHorizontal(GUILayout.MaxWidth(800.0f));
        {
            GUILayout.BeginVertical(GUILayout.MaxWidth(300.0f));
            {
                GUILayout.BeginHorizontal(GUILayout.MaxWidth(300.0f));
                {
                    if(GUILayout.Button("\n적용\n", GUILayout.Width(100.0f)))
                    {
                        getInt = 0;
                        getString = "";
                        Debug.Log(cheatText);
                    }
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal(GUILayout.MaxWidth(300.0f));
                {
                    if(GUILayout.Button("\n백그라운드\n실행\n",GUILayout.Width(100.0f)))
                    {
                        Application.runInBackground = true;
                    }
                    if (GUILayout.Button("\n백그라운드\n실행 안함\n", GUILayout.Width(100.0f)))
                    {
                        Application.runInBackground = false;
                    }
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical();
        }
        GUILayout.EndHorizontal();
    }

}

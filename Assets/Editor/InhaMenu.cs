using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class InhaMenu : MonoBehaviour
{
    [MenuItem("InhaMenu/Clear PlayerPrefs")]
    private static void Clear_PlayerPrefsAll()
    {
        PlayerPrefs.DeleteAll();
        print("Clear_PlayerPrefsAll");
    }

    [MenuItem("InhaMenu/SubMenu/Select")]
    private static void SubMenu_Selected()
    {
        print("SubMenu_Selected");
    }

    [MenuItem("InhaMenu/SubMenu/HotKey Test 1 %#[")]
    private static void SubMenu_HotKey_1()
    {
        // (% == Ctrl) + (# == Shift) + [
        // %#1 => Ctrl + Shift + 1
        print("HotKey Test : Ctrl + Shift + [");
    }

    [MenuItem("Assets/Load Selected Scene %#L")]
    private static void LoadSelectedScene()
    {
        var selected = Selection.activeObject;
        if(EditorApplication.isPlaying)
            EditorSceneManager.LoadScene(AssetDatabase.GetAssetPath(selected));
        else
            EditorSceneManager.OpenScene(AssetDatabase.GetAssetPath(selected));
        print("LoadSelectedScene");
    }

}

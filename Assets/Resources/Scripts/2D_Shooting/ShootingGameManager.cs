using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShootingGameManager : MonoBehaviour
{
    public int Difficulty = 1;
    public string ID_text;
    public uint Player_Money = 0;
    public uint Player_Score = 0;

    public bool isTimeStop = false;

    private static ShootingGameManager sInstance;
    public static ShootingGameManager Instance
    {
        get
        {
            if (sInstance == null)
            {
                GameObject newGameObject = new GameObject("_ShootingGameManager");
                sInstance = newGameObject.AddComponent<ShootingGameManager>();
            }
            return sInstance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

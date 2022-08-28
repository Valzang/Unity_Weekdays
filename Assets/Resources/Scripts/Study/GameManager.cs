using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int gameScore = 0;
    public int m_CarCount = 0;
    public string[] m_Ranking = new string[1];
    public double[] m_Ranking_Time = new double[1];
    public int Enter_Order = 0;
    public string userID = "";
    public int Nth = 2;

    private static GameManager sInstance;
    public static GameManager Instance 
    { 
        get 
        { 
            if( sInstance == null)
            {
                GameObject newGameObject = new GameObject("_GameManager");
                sInstance = newGameObject.AddComponent<GameManager>();
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

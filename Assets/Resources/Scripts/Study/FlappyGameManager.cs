using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyGameManager : MonoBehaviour
{
    public int gameScore = 0;
    public int Difficulty = 1;

    private static FlappyGameManager sInstance;
    public static FlappyGameManager Instance 
    { 
        get 
        { 
            if( sInstance == null)
            {
                GameObject newGameObject = new GameObject("_FlappyGameManager");
                sInstance = newGameObject.AddComponent<FlappyGameManager>();
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

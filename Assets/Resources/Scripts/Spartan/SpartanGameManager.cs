using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpartanGameManager : MonoBehaviour
{
    public int DeadSpartan = 0;
    public int TotalDeadSpartan = 0;
    public int TotalSpartan = 5;
    public int Difficulty = 1;


    private static SpartanGameManager sInstance;
    public static SpartanGameManager Instance
    {
        get
        {
            if (sInstance == null)
            {
                GameObject newGameObject = new GameObject("_SpartanGameManager");
                sInstance = newGameObject.AddComponent<SpartanGameManager>();
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

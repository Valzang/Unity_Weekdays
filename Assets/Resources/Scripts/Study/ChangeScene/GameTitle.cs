using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTitle : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    void GoNextScene()
    {
        Debug.Log("GoNextScene - Change Loading Scene");
        GameManager.Instance.nextSceneName = "10 Terrain";
        SceneManager.LoadScene("12 LoadingScene");
    }
}

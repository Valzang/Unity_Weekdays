using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingTime : MonoBehaviour
{
    [SerializeField]
    private GameObject remainTime = null;

    [SerializeField]
    private string sceneName;


    void Start()
    {
        remainTime.GetComponent<Text>().text = MazeManager.Instance.PlayTime.ToString() + "√ ";
    }

    void ToMain()
    {
        MazeManager.Instance.isEnemyStun = false;
        MazeManager.Instance.itemLeft = 3;
        MazeManager.Instance.Player_HP = 100.0f;
        MazeManager.Instance.PlayTime = 0.0f;
        SceneManager.LoadScene(sceneName);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MazeManager : MonoBehaviour
{
    public Object ItemUI = null;

    // 아이템 관련
    public uint itemLeft = 3;

    // 플레이어 관련
    public string ID_text;
    public double Player_HP = 100;
    public Image HPBar = null;

    public float PlayTime = 0.0f;
    public bool isTimeStop = false;
    public float volume = 0.0f;

    // 적 관련
    public bool isEnemyStun = false;

    private static MazeManager sInstance;
    public static MazeManager Instance
    {
        get
        {
            if (sInstance == null)
            {
                GameObject newGameObject = new("_MazeManager");
                sInstance = newGameObject.AddComponent<MazeManager>();
            }
            return sInstance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

}

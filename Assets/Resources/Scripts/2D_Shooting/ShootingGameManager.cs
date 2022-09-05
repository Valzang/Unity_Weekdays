using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShootingGameManager : MonoBehaviour
{
    public Object ItemUI = null;
    public uint ItemCondition = 1000;


    // �� ����
    public uint Player_Money = 0;
    public uint Getting_Money = 100;
    public uint Player_Score = 0;

    // �÷��̾� ����
    public string ID_text;
    public double Player_HP = 100;
    public Image HPBar = null;
    public bool Player_Life = false;
    public float Player_SpeedRatio = 1.0f;
    public double selfHeal = 0.0;

    // ���̾ ����
    public float Fireball_time = 1.0f;
    public bool Fireball_Pierce = false;

    // ���̾ ����
    public float waterball_time = 1.5f;

    //����
    public bool isBoss = false;
    public int BossPhase = 0;
    public int prev_BossPhase = 0;



    public float PlayTime = 0.0f;

    public bool isTimeStop = false;

    public float volume = 0.0f;

    private static ShootingGameManager sInstance;
    public static ShootingGameManager Instance
    {
        get
        {
            if (sInstance == null)
            {
                GameObject newGameObject = new("_ShootingGameManager");
                sInstance = newGameObject.AddComponent<ShootingGameManager>();
            }
            return sInstance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void FixedUpdate()
    {
        if (ItemCondition <= Player_Score)
        {
            ItemCondition += (uint)(1000 + ItemCondition*0.2f);
            print("���� ���� ������ �ð� : " + ItemCondition);
            Instantiate(ItemUI);
        }
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

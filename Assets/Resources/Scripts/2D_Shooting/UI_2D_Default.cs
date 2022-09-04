using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_2D_Default : MonoBehaviour
{
    [SerializeField]
    private GameObject OptionUI = null;

    public GameObject ID_Obj = null;
    public GameObject Money_Obj = null;
    public GameObject Score_Obj = null;
    public Image imgHPBar;

    void Start()
    {
        if(ShootingGameManager.Instance.ID_text != null && ShootingGameManager.Instance.ID_text != "")
            ID_Obj.GetComponent<Text>().text = ShootingGameManager.Instance.ID_text;
        else
            ID_Obj.GetComponent<Text>().text = "Test01";


        ShowHPBar(100);
        OptionUI.SetActive(false);
    }

    private void FixedUpdate()
    {
        Money_Obj.GetComponent<Text>().text = ShootingGameManager.Instance.Player_Money.ToString();
        Score_Obj.GetComponent<Text>().text = ShootingGameManager.Instance.Player_Score.ToString();
    }

    public void ShowHPBar(int hp)
    {
        imgHPBar.fillAmount = (float)hp / 100.0f;
    }

    void TimeStop()
    {
        if(!ShootingGameManager.Instance.isTimeStop)
        {
            Time.timeScale = 0.0f;
            ShootingGameManager.Instance.isTimeStop = true;
            OptionUI.SetActive(true);
        }
        
    }
}

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

    public GameObject DoubleMoney_Obj = null;
    private GameObject DM_Text = null;

    public Image imgHPBar;
    public Text curHP;

    private float First_DoubleTime = 60.0f;

    void Start()
    {
        if(ShootingGameManager.Instance.ID_text != null && ShootingGameManager.Instance.ID_text != "")
            ID_Obj.GetComponent<Text>().text = ShootingGameManager.Instance.ID_text;
        else
            ID_Obj.GetComponent<Text>().text = "Test01";

        DM_Text = DoubleMoney_Obj.transform.GetChild(0).gameObject;
        ShowHPBar(100);
        OptionUI.SetActive(false);
    }

    private void FixedUpdate()
    {
        Money_Obj.GetComponent<Text>().text = ShootingGameManager.Instance.Player_Money.ToString();
        Score_Obj.GetComponent<Text>().text = ShootingGameManager.Instance.Player_Score.ToString();
        if (ShootingGameManager.Instance.Getting_Money != 100)
        { 
            DoubleMoney_Obj.SetActive(true);
            DoubleMoney_Obj.GetComponent<Image>().fillAmount = First_DoubleTime / 60.0f;
            
            First_DoubleTime -= Time.deltaTime;
            DM_Text.GetComponent<Text>().text = ((int)(First_DoubleTime)).ToString();
        }
        else if (DoubleMoney_Obj.activeSelf == true)
        {
            DoubleMoney_Obj.SetActive(false);
            First_DoubleTime = 60.0f;
        }
        curHP.text = ((float)ShootingGameManager.Instance.Player_HP).ToString();
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

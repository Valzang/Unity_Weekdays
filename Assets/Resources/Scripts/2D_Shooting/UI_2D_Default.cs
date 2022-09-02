using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_2D_Default : MonoBehaviour
{
    [SerializeField]
    private GameObject OptionUI = null;

    public GameObject textObj = null;
    public Image imgHPBar;



    void Start()
    {
        if(ShootingGameManager.Instance.ID_text != null)
            textObj.GetComponent<Text>().text = ShootingGameManager.Instance.ID_text;
        else
            textObj.GetComponent<Text>().text = "Test01";
        ShowHPBar(100);
        OptionUI.SetActive(false);
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

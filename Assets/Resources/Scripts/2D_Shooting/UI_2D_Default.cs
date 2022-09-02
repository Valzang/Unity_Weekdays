using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_2D_Default : MonoBehaviour
{

    public GameObject textObj = null;
    public Image imgHPBar;

    private bool isTimeStop = false;

    void Start()
    {
        if(ShootingGameManager.Instance.ID_text != null)
            textObj.GetComponent<Text>().text = ShootingGameManager.Instance.ID_text.text;
        else
            textObj.GetComponent<Text>().text = "Test01";
        ShowHPBar(100);
    }

    void Update()
    {
        
    }

    public void ShowHPBar(int hp)
    {
        imgHPBar.fillAmount = (float)hp / 100.0f;
    }

    void TimeStop()
    {
        if(!isTimeStop)
        {
            Time.timeScale = 0.0f;
            isTimeStop = true;
        }
        
    }
}

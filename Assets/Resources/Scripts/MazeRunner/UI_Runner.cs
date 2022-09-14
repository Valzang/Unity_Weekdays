using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Runner : MonoBehaviour
{
    [SerializeField]
    private GameObject OptionUI = null;

    public GameObject itemLeft = null;

    private GameObject DM_Text = null;

    public Image imgHPBar;
    public Text curHP;


    void Start()
    {
        ShowHPBar(100);
        OptionUI.SetActive(false);
    }

    private void FixedUpdate()
    {
        itemLeft.GetComponent<Text>().text = MazeManager.Instance.itemLeft.ToString();        
        curHP.text = ((int)MazeManager.Instance.Player_HP).ToString();
        ShowHPBar((int)MazeManager.Instance.Player_HP);
    }

    public void ShowHPBar(int hp)
    {
        imgHPBar.fillAmount = (float)hp / 100.0f;
    }

    void TimeStop()
    {
        Debug.Log("TimeStop Check");
        if (!MazeManager.Instance.isTimeStop)
        {
            Time.timeScale = 0.0f;
            MazeManager.Instance.isTimeStop = true;
            OptionUI.SetActive(true);
        }
    }
}

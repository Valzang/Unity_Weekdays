using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    private Text Score_Text;
    [SerializeField]
    private Text Time_Text;
    // Start is called before the first frame update
    void Start()
    {
        Score_Text.text = ShootingGameManager.Instance.Player_Score.ToString();
        Time_Text.text = ShootingGameManager.Instance.PlayTime.ToString() + "√ ";
    }

    void onClickOK()
    {
        ShootingGameManager.Instance.ChangeScene("2D_Login");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Login : MonoBehaviour
{

    public InputField inputText;

    private void Start()
    {
        ShootingGameManager.Instance.ID_text = null;
        ShootingGameManager.Instance.Player_Money = 0;
        ShootingGameManager.Instance.Player_Score = 0;
        ShootingGameManager.Instance.PlayTime = 0.0f;
        ShootingGameManager.Instance.volume = 0.0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            onClickOK();
    }

    void onClickOK()
    {        
        print(inputText.text + " ·Î±×ÀÎ");
        ShootingGameManager.Instance.ID_text = inputText.text;
        ShootingGameManager.Instance.ChangeScene("2D_Shooting");
    }
}

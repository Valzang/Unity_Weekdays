using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Login : MonoBehaviour
{

    public InputField inputText;


    void onClickOK()
    {
        print(inputText.text + " �α���");
        ShootingGameManager.Instance.ID_text.text = inputText.text;
        ShootingGameManager.Instance.ChangeScene("2D_Shooting");
    }
}

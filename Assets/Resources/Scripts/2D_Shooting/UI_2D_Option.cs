using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_2D_Option : MonoBehaviour
{    
    public InputField inputText;
    Text titleText;

    void Start()
    {
        titleText = gameObject.GetComponentInChildren<Text>() as Text;
    }


    void Update()
    {
        
    }

    void onClickOK()
    {
        print("onClickOK");
        this.gameObject.SetActive(false);
    }

    void onTextChanged()
    {
        if(titleText!=null)
        {
            titleText.text = inputText.text;
        }
    }

    void onTextEndEdit()
    {
        if (titleText != null)
        {
            titleText.text = inputText.text;
        }
    }
}

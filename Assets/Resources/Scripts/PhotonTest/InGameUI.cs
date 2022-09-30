using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class InGameUI : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject ChatUI;
    [SerializeField] private GameObject previousChat;
    [SerializeField] private InputField Chat;

    private ScrollRect prev_ScrollRect = null;

    static public InGameUI Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }

    }
    void Start()
    {
        prev_ScrollRect = ChatUI.transform.GetChild(0).GetComponent<ScrollRect>();
        PhotonNetwork.IsMessageQueueRunning = true;
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            if (ChatUI.activeSelf && !Chat.isFocused)
                ChatUI.SetActive(false);
            else
            {
                ChatUI.SetActive(true);
                //Chat.ActivateInputField();
                //Chat.Select();
            }
        }
        if(ChatUI.activeSelf && Chat.isFocused)
        {
            if (Input.GetKeyDown(KeyCode.Return))
                SendChat();
        }        
    }

    public void FocusingChat()
    {
        Chat.ActivateInputField();
        Chat.Select();
    }

    public void SendChat()
    {
        if (Chat.text == "")
            return;
        string msg = "[" + PhotonNetwork.LocalPlayer.NickName + "] : " + Chat.text;
        photonView.RPC("ReceiveMsg", RpcTarget.OthersBuffered, msg);
        ReceiveMsg(msg);
        Chat.ActivateInputField();
        Chat.text = "";
    }

    [PunRPC]
    public void ReceiveMsg(string msg)
    {
        previousChat.GetComponent<Text>().text += msg + "\n";
        prev_ScrollRect.verticalNormalizedPosition = 0.0f;
    }
}

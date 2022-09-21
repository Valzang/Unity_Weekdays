using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class LobbyUI : MonoBehaviour
{
    [SerializeField] private GameObject WelcomeText;
    [SerializeField] private GameObject[] NickNames;

    void Start()
    {
        // 닉네임 환영합니다 !
        WelcomeText.GetComponent<Text>().text = PhotonNetwork.LocalPlayer.NickName + WelcomeText.GetComponent<Text>().text;

        Debug.Log(PhotonNetwork.CountOfPlayersOnMaster);
        //Debug.Log(PhotonNetwork.PlayerList);

        for (int i=0 ; i< PhotonNetwork.CountOfPlayersOnMaster; ++i)
        {
            NickNames[i].transform.GetChild(0).GetComponent<Text>().text = PhotonNetwork.CurrentLobby.GetType
        }
    }


    void Update()
    {
        
    }
}

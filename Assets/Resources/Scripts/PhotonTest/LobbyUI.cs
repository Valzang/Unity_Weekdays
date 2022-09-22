using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class LobbyUI : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject WelcomeText;
    [SerializeField] private GameObject CurrentNumberObj;
    [SerializeField] private GameObject TotalNumberObj;
    [SerializeField] private GameObject RoomNameObj;
    [SerializeField] private GameObject WarningObj;

    private Text currentNumber;
    private Text totalNumber;

    private List<RoomInfo> curRoomList = new List<RoomInfo>();

    void Start()
    {
        // 닉네임 환영합니다 !
        WelcomeText.GetComponent<Text>().text = PhotonNetwork.LocalPlayer.NickName + WelcomeText.GetComponent<Text>().text;

        Debug.Log(PhotonNetwork.CountOfPlayersOnMaster);
        currentNumber = CurrentNumberObj.GetComponent<Text>();
        totalNumber = TotalNumberObj.GetComponent<Text>();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        curRoomList = roomList;
    }


    private void FixedUpdate()
    {
        currentNumber.text = "로비 접속자 : " + (PhotonNetwork.CountOfPlayers - PhotonNetwork.CountOfPlayersInRooms).ToString()
                             + "명";
        totalNumber.text = "총 서버 접속자 : " + PhotonNetwork.CountOfPlayers + "명";
    }
    public void MakeRoom()
    {
        // 룸 생성
        for (int i = 0 ; i<curRoomList.Count ; ++i)
        {
            if (RoomNameObj.GetComponent<Text>().text == curRoomList[i].Name)
            {
                WarningObj.SetActive(true);
                WarningObj.transform.GetChild(1).gameObject.GetComponent<Text>().text = "현재 존재하는 방 이름입니다 !";
                return;
            }
        }

        // 룸의 속성 정의
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;    // 최대 접속자수, 포톤 무료는 20CCU이므로 20 초과로는 못한다.
        roomOptions.IsOpen = true;      // 룸의 오픈 여부
        roomOptions.IsVisible = true;   // 로비에서 룸 목록에 노출시킬지 여부

        PhotonNetwork.CreateRoom(RoomNameObj.GetComponent<Text>().text, roomOptions);
    }

    public void FindRoom()
    {
        // 룸 생성
        for (int i = 0 ; i<curRoomList.Count ; ++i)
        {
            if (RoomNameObj.GetComponent<Text>().text == curRoomList[i].Name)
            {
                PhotonNetwork.JoinRoom(RoomNameObj.GetComponent<Text>().text);
                return;
            }
        }

        WarningObj.SetActive(true);
        WarningObj.transform.GetChild(1).gameObject.GetComponent<Text>().text = "해당 이름의 방제가 없습니다 !";
    }

    public void DisableWarning()
    {
        WarningObj.SetActive(false);
    }
}

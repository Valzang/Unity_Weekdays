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
        // �г��� ȯ���մϴ� !
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
        currentNumber.text = "�κ� ������ : " + (PhotonNetwork.CountOfPlayers - PhotonNetwork.CountOfPlayersInRooms).ToString()
                             + "��";
        totalNumber.text = "�� ���� ������ : " + PhotonNetwork.CountOfPlayers + "��";
    }
    public void MakeRoom()
    {
        // �� ����
        for (int i = 0 ; i<curRoomList.Count ; ++i)
        {
            if (RoomNameObj.GetComponent<Text>().text == curRoomList[i].Name)
            {
                WarningObj.SetActive(true);
                WarningObj.transform.GetChild(1).gameObject.GetComponent<Text>().text = "���� �����ϴ� �� �̸��Դϴ� !";
                return;
            }
        }

        // ���� �Ӽ� ����
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;    // �ִ� �����ڼ�, ���� ����� 20CCU�̹Ƿ� 20 �ʰ��δ� ���Ѵ�.
        roomOptions.IsOpen = true;      // ���� ���� ����
        roomOptions.IsVisible = true;   // �κ񿡼� �� ��Ͽ� �����ų�� ����

        PhotonNetwork.CreateRoom(RoomNameObj.GetComponent<Text>().text, roomOptions);
    }

    public void FindRoom()
    {
        // �� ����
        for (int i = 0 ; i<curRoomList.Count ; ++i)
        {
            if (RoomNameObj.GetComponent<Text>().text == curRoomList[i].Name)
            {
                PhotonNetwork.JoinRoom(RoomNameObj.GetComponent<Text>().text);
                return;
            }
        }

        WarningObj.SetActive(true);
        WarningObj.transform.GetChild(1).gameObject.GetComponent<Text>().text = "�ش� �̸��� ������ �����ϴ� !";
    }

    public void DisableWarning()
    {
        WarningObj.SetActive(false);
    }
}

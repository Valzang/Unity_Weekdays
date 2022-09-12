using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    //���� �Է�
    private readonly string version = "1.0";

    //����� ���̵� �Է�
    private string userID = "JJCW";

    private void Awake()
    {
        // ���� ���� �����鿡�� �ڵ����� ���� �ε�
        PhotonNetwork.AutomaticallySyncScene = true;
        // ���� ������ �������� ���� ���
        PhotonNetwork.GameVersion = version;
        // ���� ���̵� �Ҵ�
        PhotonNetwork.NickName = userID;
        // ���� ������ ��� Ƚ�� ����. �ʴ� 30ȸ
        Debug.Log(PhotonNetwork.SendRate);
        // ���� ����
        PhotonNetwork.ConnectUsingSettings();
    }

    // ���� ������ ���� �� ȣ��Ǵ� �ݹ� �Լ�
    public override void OnConnectedToMaster()
    {
        Debug.Log("����� ���� �Ϸ� !");
        Debug.Log($"PhotonNetwork.InLobby = {PhotonNetwork.InLobby}");
        PhotonNetwork.JoinLobby(); // �κ� ���� 
    }

    // �κ� ���� �� ȣ��Ǵ� �ݹ� �Լ�
    public override void OnJoinedLobby()
    {
        Debug.Log($"�κ� ���� ���� : {PhotonNetwork.InLobby}");
        PhotonNetwork.JoinRandomRoom(); // ���� ��ġ����ŷ ��� ����
    }

    // ������ �� ������ �������� ��� ȣ��Ǵ� �ݹ� �Լ�
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log($"�� ���� ���� {returnCode}:{message}");

        // ���� �Ӽ� ����
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 20;    // �ִ� �����ڼ�, ���� ����� 20CCU�̹Ƿ� 20 �ʰ��δ� ���Ѵ�.
        roomOptions.IsOpen = true;      // ���� ���� ����
        roomOptions.IsVisible = true;   // �κ񿡼� �� ��Ͽ� �����ų�� ����

        // �� ����
        PhotonNetwork.CreateRoom("My Room", roomOptions);
    }

    // �� ������ �Ϸ�� �� ȣ��Ǵ� �ݹ� �Լ�
    public override void OnCreatedRoom()
    {
        Debug.Log("�� ���� �Ϸ�");
        Debug.Log($"�� �̸� : {PhotonNetwork.CurrentRoom.Name}");
    }

    // �뿡 ������ �� ȣ��Ǵ� �ݹ� �Լ�
    public override void OnJoinedRoom()
    {
        Debug.Log($"�� ���� �Ϸ� : {PhotonNetwork.InRoom}");
        Debug.Log($"�÷��̾� �� : {PhotonNetwork.CurrentRoom.PlayerCount}");

        PhotonGameManager.instance.isConnect = true;

        // �뿡 ������ ����� ���� Ȯ��
        foreach(var player in PhotonNetwork.CurrentRoom.Players)
        {
            // $ => String.Format() : $"" �ֵ���ǥ �ȿ� �ִ� ������ ��Ʈ������ �ٲ���־��.
            Debug.Log($"{player.Value.NickName}, {player.Value.ActorNumber}");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

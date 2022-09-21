using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

// MonoBehaviourPun : Callback �Լ� �����͵��� �������̵� �� �� ����
public class PhotonManager : MonoBehaviourPunCallbacks
{
    //�̱���
    public static PhotonManager instance = null;

    //���� �Է�
    private readonly string version = "1.0";

    //����� ���̵� �Է�
    private string userID = "JJCW";

    //���̵� ��ĥ ���� ����
    private string name_number = "";

    [Header("DisconnectPanel")]
    //public GameObject DisconnectPanel;
    public InputField NicknameInput;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        Screen.SetResolution(1280, 860, false);

    }

    public void Connect()
    {
        // ���� ���� �����鿡�� �ڵ����� ���� �ε�
        PhotonNetwork.AutomaticallySyncScene = true;
        // ���� ������ �������� ���� ���
        PhotonNetwork.GameVersion = version;

        // ���� ������ ��� Ƚ�� ����. �ʴ� 30ȸ
        Debug.Log(PhotonNetwork.SendRate);

        // ���� ���̵� �Ҵ�
        PhotonNetwork.LocalPlayer.NickName = NicknameInput == null ? userID + name_number : NicknameInput.text;        
        // ���� ����
        PhotonNetwork.ConnectUsingSettings();
    }

    // ���� ������ ���� �� ȣ��Ǵ� �ݹ� �Լ�
    public override void OnConnectedToMaster()
    {
        Debug.Log("������ ���� �Ϸ� !");
        //Debug.Log($"PhotonNetwork.InLobby = {PhotonNetwork.InLobby}");
        PhotonNetwork.JoinLobby(); // �κ� ���� 
        SceneManager.LoadScene("PhotonLobby");
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
        Debug.Log($"�� ���ӿ� �����Ͽ� ���� ����ϴ�. {returnCode}:{message}");

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
        // �ߺ� �г��� ������ ���� �߰� �̸�
        foreach (var player in PhotonNetwork.CurrentRoom.Players)
        {
            if (player.Value == PhotonNetwork.LocalPlayer)
                continue;
            if (player.Value.NickName == PhotonNetwork.LocalPlayer.NickName)
            {
                if (name_number == "")
                    name_number = "1";
                else
                    name_number = (Convert.ToInt32(name_number) + 1).ToString();
            }
        }
        PhotonNetwork.LocalPlayer.NickName = PhotonNetwork.LocalPlayer.NickName + name_number;
        string isMaster = PhotonNetwork.LocalPlayer.IsMasterClient ? "(����)" : "";
        Debug.Log(PhotonNetwork.LocalPlayer.NickName + "��" + isMaster + $" �� ���� �Ϸ� : {PhotonNetwork.InRoom}");
        Debug.Log($"�÷��̾� �� : {PhotonNetwork.CurrentRoom.PlayerCount}");

        PhotonGameManager.instance.isConnect = true;

        // �뿡 ������ ����� ���� Ȯ��
        foreach(var player in PhotonNetwork.CurrentRoom.Players)
        {
            // $ => String.Format() : $"" �ֵ���ǥ �ȿ� �ִ� ������ ��Ʈ������ �ٲ���־��.            
            Debug.Log($"{player.Value.NickName}, {player.Value.ActorNumber}");
        }
        PhotonNetwork.Instantiate("Prefab/PhotonTest/Player", Vector3.zero, Quaternion.identity);
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

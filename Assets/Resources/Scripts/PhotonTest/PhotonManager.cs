using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    //버전 입력
    private readonly string version = "1.0";

    //사용자 아이디 입력
    private string userID = "JJCW";

    private void Awake()
    {
        // 같은 룸의 유저들에게 자동으로 씬을 로딩
        PhotonNetwork.AutomaticallySyncScene = true;
        // 같은 버전의 유저끼리 접속 허용
        PhotonNetwork.GameVersion = version;
        // 유저 아이디 할당
        PhotonNetwork.NickName = userID;
        // 포톤 서버와 통신 횟수 설정. 초당 30회
        Debug.Log(PhotonNetwork.SendRate);
        // 서버 접속
        PhotonNetwork.ConnectUsingSettings();
    }

    // 포톤 서버에 접속 후 호출되는 콜백 함수
    public override void OnConnectedToMaster()
    {
        Debug.Log("방장과 연결 완료 !");
        Debug.Log($"PhotonNetwork.InLobby = {PhotonNetwork.InLobby}");
        PhotonNetwork.JoinLobby(); // 로비 입장 
    }

    // 로비에 접속 후 호출되는 콜백 함수
    public override void OnJoinedLobby()
    {
        Debug.Log($"로비 접속 성공 : {PhotonNetwork.InLobby}");
        PhotonNetwork.JoinRandomRoom(); // 랜덤 매치메이킹 기능 제공
    }

    // 랜덤한 룸 입장이 실패했을 경우 호출되는 콜백 함수
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log($"방 접속 실패 {returnCode}:{message}");

        // 룸의 속성 정의
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 20;    // 최대 접속자수, 포톤 무료는 20CCU이므로 20 초과로는 못한다.
        roomOptions.IsOpen = true;      // 룸의 오픈 여부
        roomOptions.IsVisible = true;   // 로비에서 룸 목록에 노출시킬지 여부

        // 룸 생성
        PhotonNetwork.CreateRoom("My Room", roomOptions);
    }

    // 룸 생성이 완료된 후 호출되는 콜백 함수
    public override void OnCreatedRoom()
    {
        Debug.Log("방 생성 완료");
        Debug.Log($"방 이름 : {PhotonNetwork.CurrentRoom.Name}");
    }

    // 룸에 입장한 후 호출되는 콜백 함수
    public override void OnJoinedRoom()
    {
        Debug.Log($"방 입장 완료 : {PhotonNetwork.InRoom}");
        Debug.Log($"플레이어 수 : {PhotonNetwork.CurrentRoom.PlayerCount}");

        PhotonGameManager.instance.isConnect = true;

        // 룸에 접속한 사용자 정보 확인
        foreach(var player in PhotonNetwork.CurrentRoom.Players)
        {
            // $ => String.Format() : $"" 쌍따옴표 안에 있는 내용을 스트링으로 바꿔어주어라.
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

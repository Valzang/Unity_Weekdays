using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using LitJson;

public class PlayerInfo
{
    public int ID;
    public string Name;
    public double Gold;
    public PlayerInfo(int _id, string _name, double _gold)
    {
        ID = _id;
        Name = _name;
        Gold = _gold;
    }
}

public class JSON_test : MonoBehaviour
{
    public List<PlayerInfo> playerInfoList = new List<PlayerInfo>();
    void Start()
    {
        //SavePlayerInfo();
        LoadPlayerInfo();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SavePlayerInfo()
    {
        Debug.Log("SavePlayerInfo Start");
        playerInfoList.Add(new PlayerInfo(1, "이름1", 1001));
        playerInfoList.Add(new PlayerInfo(2, "이름2", 1002));
        playerInfoList.Add(new PlayerInfo(3, "이름3", 1003));
        playerInfoList.Add(new PlayerInfo(4, "이름4", 1004));
        playerInfoList.Add(new PlayerInfo(5, "이름5", 1005));

        JsonData infoJson = JsonMapper.ToJson(playerInfoList);
        //WriteAllText는 기존에 있던걸 싸그리 덮어써주는데 이를 쓰는 이유는 데이터 앞뒤로 []가 붙기 때문에
        // 덮어씌우지 않게 되면 데이터끼리 [] [] []로 나눠져서 읽어오는데에 문제가 생길 수 있기 때문이다.
        File.WriteAllText(Application.dataPath + "/Resources/JsonData/PlayerInfoData.json",
            infoJson.ToString());
        Debug.Log("SavePlayerInfo Complete");
    }

    public void LoadPlayerInfo()
    {
        Debug.Log("LoadPlayerInfo Start");
        if (File.Exists(Application.dataPath + "/Resources/JsonData/PlayerInfoData.json"))
        {
            string jsonString = File.ReadAllText(Application.dataPath + "/Resources/JsonData/PlayerInfoData.json");
            Debug.Log(jsonString);

            JsonData data = JsonMapper.ToObject(jsonString);
            ParsingJsonPlayerInfo(data);
        }
        Debug.Log("LoadPlayerInfo Complete");
    }

    private void ParsingJsonPlayerInfo(JsonData playerData)
    {
        Debug.Log("ParsingJsonPlayerInfo");
        for (int i=0 ; i< playerData.Count ; ++i)
        {
            Debug.Log(playerData[i]["ID"].ToString());
            Debug.Log(playerData[i]["Name"].ToString());
            Debug.Log(playerData[i]["Gold"].ToString());

            int ii = (int)playerData[i]["ID"];
        }
    }

}

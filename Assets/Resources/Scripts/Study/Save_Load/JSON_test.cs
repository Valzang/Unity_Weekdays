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
        playerInfoList.Add(new PlayerInfo(1, "�̸�1", 1001));
        playerInfoList.Add(new PlayerInfo(2, "�̸�2", 1002));
        playerInfoList.Add(new PlayerInfo(3, "�̸�3", 1003));
        playerInfoList.Add(new PlayerInfo(4, "�̸�4", 1004));
        playerInfoList.Add(new PlayerInfo(5, "�̸�5", 1005));

        JsonData infoJson = JsonMapper.ToJson(playerInfoList);
        //WriteAllText�� ������ �ִ��� �α׸� ������ִµ� �̸� ���� ������ ������ �յڷ� []�� �ٱ� ������
        // ������� �ʰ� �Ǹ� �����ͳ��� [] [] []�� �������� �о���µ��� ������ ���� �� �ֱ� �����̴�.
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

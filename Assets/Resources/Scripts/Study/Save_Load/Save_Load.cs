using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

[System.Serializable]
public class SaveInformation
{
    public string name;

    // 벡터는 Serializable이 되지 않아서 풀어서 사용.
    public float posX;
    public float posY;
    public float posZ;
}

public class Save_Load : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(PlayerPrefs.HasKey("ID"))
            {
                string getID = PlayerPrefs.GetString("ID");
                Debug.Log(string.Format("ID:{0}", getID));
            }
            else
            {
                Debug.Log("저장된 ID 없음");
            }
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (PlayerPrefs.HasKey("ID"))
            {
                Debug.Log("이미 저장된 ID가 있습니다 !");
                return;
            }
            string setID = "PlayerID";
            PlayerPrefs.SetString("ID", setID);
            Debug.Log("저장된 ID : " + setID);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            int getScore = PlayerPrefs.GetInt("Score", 100);
            float getExp = PlayerPrefs.GetFloat("Exp" , 100.0f);
            string getName = PlayerPrefs.GetString("Name", "NONE");

            Debug.Log(getScore.ToString());
            Debug.Log(getExp.ToString());
            Debug.Log(getName);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (PlayerPrefs.HasKey("ID"))
            {
                Debug.Log("삭제된 ID : " + PlayerPrefs.GetString("ID"));
                PlayerPrefs.DeleteKey("ID");
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("모든 키 값 삭제");
            PlayerPrefs.DeleteAll();
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            SaveBinary();
        }

        if(Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("csv 읽기");
            CSV_Load();
        }
    }

    void SaveBinary()
    {
        // 저장정보에 데이터 저장 ================================
        SaveInformation setInfo = new SaveInformation();
        setInfo.name = "Inha";
        setInfo.posX = 0.0f;
        setInfo.posY = 4.5f;
        setInfo.posZ = 5.5f;
        //====================================================
        Debug.Log(setInfo);

        BinaryFormatter formatter1 = new BinaryFormatter();

        // 이진 데이터 공간
        MemoryStream memStream = new MemoryStream();

        // 데이터 공간에 저장정보의 데이터를 이진으로 저장
        formatter1.Serialize(memStream, setInfo);
        // 바이트 단위로 저장된 데이터 가져오기
        byte[] bytes = memStream.GetBuffer();

        string memStr = Convert.ToBase64String(bytes);
        Debug.Log("이진 데이터로 저장 : " + memStr);

        PlayerPrefs.SetString("SaveInformation", memStr);


        //==========================================================================

        string getInfos = PlayerPrefs.GetString("SaveInformation", "NONE");
        Debug.Log("불러온 이진 데이터 : " + getInfos);
        byte[] getBytes = Convert.FromBase64String(getInfos);

        MemoryStream getMemStream = new MemoryStream(getBytes);
        BinaryFormatter formatter2 = new BinaryFormatter();
        SaveInformation getInformation = (SaveInformation)formatter2.Deserialize(getMemStream);

        Debug.Log("이름 : " + getInformation.name);
        Debug.Log("X좌표 : " + getInformation.posX);
        Debug.Log("Y좌표 : " + getInformation.posY);
        Debug.Log("Z좌표 : " + getInformation.posZ);
    }

    void CSV_Load()
    {
        List<Dictionary<string, object>> data = csvReader.Read("Unity_csvLoad_test");
        for(int i =0 ; i< data.Count ; ++i)
        {
            print("ID : " + data[i]["ID"]);
            print("Name : " + data[i]["Name"]);
            print("Description : " + data[i]["Description"]);
            print("AttackPower : " + data[i]["Attack Power"]);
            print("DefensePower : " + data[i]["Defense Power"]);
            print("Durability : " + data[i]["Durability"]);
        }
    }
}

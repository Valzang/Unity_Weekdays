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

    // ���ʹ� Serializable�� ���� �ʾƼ� Ǯ� ���.
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
                Debug.Log("����� ID ����");
            }
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (PlayerPrefs.HasKey("ID"))
            {
                Debug.Log("�̹� ����� ID�� �ֽ��ϴ� !");
                return;
            }
            string setID = "PlayerID";
            PlayerPrefs.SetString("ID", setID);
            Debug.Log("����� ID : " + setID);
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
                Debug.Log("������ ID : " + PlayerPrefs.GetString("ID"));
                PlayerPrefs.DeleteKey("ID");
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("��� Ű �� ����");
            PlayerPrefs.DeleteAll();
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            SaveBinary();
        }

        if(Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("csv �б�");
            CSV_Load();
        }
    }

    void SaveBinary()
    {
        // ���������� ������ ���� ================================
        SaveInformation setInfo = new SaveInformation();
        setInfo.name = "Inha";
        setInfo.posX = 0.0f;
        setInfo.posY = 4.5f;
        setInfo.posZ = 5.5f;
        //====================================================
        Debug.Log(setInfo);

        BinaryFormatter formatter1 = new BinaryFormatter();

        // ���� ������ ����
        MemoryStream memStream = new MemoryStream();

        // ������ ������ ���������� �����͸� �������� ����
        formatter1.Serialize(memStream, setInfo);
        // ����Ʈ ������ ����� ������ ��������
        byte[] bytes = memStream.GetBuffer();

        string memStr = Convert.ToBase64String(bytes);
        Debug.Log("���� �����ͷ� ���� : " + memStr);

        PlayerPrefs.SetString("SaveInformation", memStr);


        //==========================================================================

        string getInfos = PlayerPrefs.GetString("SaveInformation", "NONE");
        Debug.Log("�ҷ��� ���� ������ : " + getInfos);
        byte[] getBytes = Convert.FromBase64String(getInfos);

        MemoryStream getMemStream = new MemoryStream(getBytes);
        BinaryFormatter formatter2 = new BinaryFormatter();
        SaveInformation getInformation = (SaveInformation)formatter2.Deserialize(getMemStream);

        Debug.Log("�̸� : " + getInformation.name);
        Debug.Log("X��ǥ : " + getInformation.posX);
        Debug.Log("Y��ǥ : " + getInformation.posY);
        Debug.Log("Z��ǥ : " + getInformation.posZ);
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

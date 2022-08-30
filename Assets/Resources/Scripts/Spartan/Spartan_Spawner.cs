using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spartan_Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject spartanObj = null;

    public int Total_Count = 5;
    public int Spawn_Count = 0;

    private void Start()
    {
        InvokeRepeating("MakeObj", 1.0f, 4.0f);
    }
    private void Update()
    {
        if (Spawn_Count == Total_Count)
        {
            print("10초 후 새 페이즈를 시작합니다");
            StopInvoke();
            Total_Count += 2;
            Spawn_Count = 0;
            InvokeRepeating("MakeObj", 10.0f, 4.0f);
        }
    }

    public void StopInvoke()
    {
        CancelInvoke("MakeObj");
        return;
    }

    void MakeObj()
    {
        if (Spawn_Count == Total_Count)
            return;
        GameObject obj = null;
        if (spartanObj != null)
        {
            float random = Random.Range(-4,5);
            Vector3 curPos = transform.position;
            curPos.x += random * 5.0f;
            obj = Instantiate(spartanObj, curPos, transform.rotation);
            ++Spawn_Count;
        }
    }
}

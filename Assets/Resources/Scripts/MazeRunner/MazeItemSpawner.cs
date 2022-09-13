using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeItemSpawner : MonoBehaviour
{
    List<int> randSpawner = new List<int>();

    private void Awake()
    {
        for (int i=0; i<3; ++i)
        {
            int temp = Random.Range(0, 8);

            // 겹치지 않게 중복이면 계속 랜덤 돌리기
            while(randSpawner.Contains(temp))
            {
                temp = Random.Range(0, 8);
            }
            randSpawner.Add(temp);

            // temp번째 자식을 켜기
            this.gameObject.transform.GetChild(randSpawner[i]).gameObject.SetActive(true);
        }        
        
        
    }

    void Update()
    {
        
    }
}

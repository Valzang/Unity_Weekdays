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

            // ��ġ�� �ʰ� �ߺ��̸� ��� ���� ������
            while(randSpawner.Contains(temp))
            {
                temp = Random.Range(0, 8);
            }
            randSpawner.Add(temp);

            // temp��° �ڽ��� �ѱ�
            this.gameObject.transform.GetChild(randSpawner[i]).gameObject.SetActive(true);
        }        
        
        
    }

    void Update()
    {
        
    }
}

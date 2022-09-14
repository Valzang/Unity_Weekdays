using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TraceItem : MonoBehaviour
{
    [SerializeField]
    private GameObject itemSpawner = null;
    [SerializeField]
    private GameObject playerObj = null;
    [SerializeField]
    private GameObject ExitWall = null;

    private List<Tuple<GameObject, float>> tempList = new List<Tuple<GameObject, float>>();
    private List<Tuple<GameObject, float>> itemList = new List<Tuple<GameObject, float>>();


    void Start()
    {        

        for (int i = 0 ; i < itemSpawner.transform.childCount ; ++i)
        {
            if (itemSpawner.transform.GetChild(i).gameObject.activeSelf == false)
                continue;
            else
            {
                GameObject tempTarget = itemSpawner.transform.GetChild(i).gameObject;

                //아이템과 플레이어와의 거리
                float dist = (tempTarget.transform.position - playerObj.transform.position).magnitude;
                itemList.Add(new Tuple<GameObject, float>(itemSpawner.transform.GetChild(i).gameObject, dist));
            }
        }
        itemList.Sort((A, B) => A.Item2.CompareTo(B.Item2));
        // 아이템 리스트에 정렬해서 넣어두기
    }
    private void FixedUpdate()
    {
        // 없어진 건 삭제
        for (int i = itemList.Count-1 ; i >= 0 ; --i)
        {
            if (!itemList[i].Item1.activeSelf)
                itemList.RemoveAt(i);
        }

        // 임시 리스트에 새로 계산해준 것 넣어주고 itemList에 다시 넣어주기
        tempList = new List<Tuple<GameObject, float>>();
        for (int i = 0 ; i < itemList.Count ; ++i)
        {
            float dist = (itemList[i].Item1.transform.position - playerObj.transform.position).magnitude;
            tempList.Add(new Tuple<GameObject, float>(itemList[i].Item1, dist));
        }

        itemList.Clear();
        itemList = tempList;
        itemList.Sort((A, B) => A.Item2.CompareTo(B.Item2));
    }

    void Update()
    {
        if (itemList.Count > 0)
        {
            Vector3 itemDirection = itemList[0].Item1.transform.position - playerObj.transform.position;
            this.transform.forward = itemDirection.normalized;
        }
        else if(ExitWall.activeSelf)
        {
            if (ExitWall.transform.position.y < -12.0f)
            { 
                Destroy(this.gameObject);
                return;
            }
            Vector3 exitDirection = ExitWall.transform.position - playerObj.transform.position;
            this.transform.forward = exitDirection.normalized;
        }
        else
            ExitWall.SetActive(true);
    }
}

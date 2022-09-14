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

    private List<Tuple<GameObject, float>> temp_list = new List<Tuple<GameObject, float>>();
    private List<Tuple<GameObject, float>> itemList = new List<Tuple<GameObject, float>>();

    private NavMeshAgent temp_itemTracer = new NavMeshAgent();
    private NavMeshAgent itemTracer = null;
    //private GameObject target = null;

    void Start()
    {        
        itemTracer = this.transform.parent.gameObject.GetComponent<NavMeshAgent>();
        temp_itemTracer = itemTracer;

        Debug.Log("시작 시 스포너 아이템 갯수 : " + itemSpawner.transform.childCount);

        for (int i = 0 ; i < itemSpawner.transform.childCount ; ++i)
        {
            if (itemSpawner.transform.GetChild(i).gameObject.activeSelf == false)
            {
                Debug.Log(i + "번째 자식인 " + itemSpawner.transform.GetChild(i).gameObject.name + "이 활성화가 안되어있음");
                continue;
            }
            else
            {
                Debug.Log(i + "번째 자식 넣어줄거임");
                GameObject tempTarget = itemSpawner.transform.GetChild(i).gameObject;
                
                temp_itemTracer.SetDestination(tempTarget.transform.position);
                itemList.Add(new Tuple<GameObject, float>(itemSpawner.transform.GetChild(i).gameObject, temp_itemTracer.remainingDistance));
            }
        }
        itemList.Sort((A, B) => A.Item2.CompareTo(B.Item2));
        // 아이템 리스트에 정렬해서 넣어두기

        Debug.Log("시작 시 아이템 리스트 갯수 : " + itemList.Count);
    }
    private void FixedUpdate()
    {
        for (int i = itemList.Count-1 ; i >= 0 ; --i)
        {
            if (!itemList[i].Item1.activeSelf)
                itemList.RemoveAt(i);
        }
        temp_list = new List<Tuple<GameObject, float>>();

        for (int i = 0 ; i < itemList.Count ; ++i)
        {
            temp_itemTracer.SetDestination(itemList[i].Item1.transform.position);
            temp_list.Add(new Tuple<GameObject, float>(itemList[i].Item1, temp_itemTracer.remainingDistance));
        }

        itemList.Clear();
        itemList = temp_list;
        itemList.Sort((A, B) => A.Item2.CompareTo(B.Item2));
    }

    void Update()
    {
        Debug.Log("아이템 리스트 갯수 : " + itemList.Count);
        Debug.Log("임시 리스트 갯수 : " + temp_list.Count);
        Vector3 itemDirection = itemList[0].Item1.transform.position - playerObj.transform.position;
        this.transform.forward = itemDirection.normalized;
    }
}

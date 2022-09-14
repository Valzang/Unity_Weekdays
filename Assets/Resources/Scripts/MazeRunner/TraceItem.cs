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

        Debug.Log("���� �� ������ ������ ���� : " + itemSpawner.transform.childCount);

        for (int i = 0 ; i < itemSpawner.transform.childCount ; ++i)
        {
            if (itemSpawner.transform.GetChild(i).gameObject.activeSelf == false)
            {
                Debug.Log(i + "��° �ڽ��� " + itemSpawner.transform.GetChild(i).gameObject.name + "�� Ȱ��ȭ�� �ȵǾ�����");
                continue;
            }
            else
            {
                Debug.Log(i + "��° �ڽ� �־��ٰ���");
                GameObject tempTarget = itemSpawner.transform.GetChild(i).gameObject;
                
                temp_itemTracer.SetDestination(tempTarget.transform.position);
                itemList.Add(new Tuple<GameObject, float>(itemSpawner.transform.GetChild(i).gameObject, temp_itemTracer.remainingDistance));
            }
        }
        itemList.Sort((A, B) => A.Item2.CompareTo(B.Item2));
        // ������ ����Ʈ�� �����ؼ� �־�α�

        Debug.Log("���� �� ������ ����Ʈ ���� : " + itemList.Count);
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
        Debug.Log("������ ����Ʈ ���� : " + itemList.Count);
        Debug.Log("�ӽ� ����Ʈ ���� : " + temp_list.Count);
        Vector3 itemDirection = itemList[0].Item1.transform.position - playerObj.transform.position;
        this.transform.forward = itemDirection.normalized;
    }
}

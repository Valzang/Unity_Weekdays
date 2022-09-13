using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TraceItem : MonoBehaviour
{
    [SerializeField]
    private GameObject itemSpawner = null;
        
    private List<Tuple<GameObject, float>> itemList = new List<Tuple<GameObject, float>>();

    private NavMeshAgent temp_itemTracer = null;
    private NavMeshAgent itemTracer = null;
    private GameObject target = null;

    private void Awake()
    {
        temp_itemTracer = new NavMeshAgent();
        itemTracer = this.transform.parent.gameObject.GetComponent<NavMeshAgent>();

        for (int i = 0; i < itemSpawner.transform.childCount; ++i)
        {
            if (!itemSpawner.transform.GetChild(i).gameObject.activeSelf)
                continue;
            else
            {
                GameObject tempTarget = itemSpawner.transform.GetChild(i).gameObject;
                temp_itemTracer.SetDestination(tempTarget.transform.position);
                itemList.Add(new Tuple<GameObject, float>(itemSpawner.transform.GetChild(i).gameObject, temp_itemTracer.remainingDistance));
            }                
        }  
        itemList.Sort((A, B) => A.Item2.CompareTo(B.Item2));
    }

    void Start()
    {
    }
    private void FixedUpdate()
    {

    }

    void Update()
    {
        
    }
}

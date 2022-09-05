using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObject))]
public class Enemy_Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject wolfObj = null;

    private void Start()
    {
        InvokeRepeating(nameof(MakeObj), 1.0f, 2.0f);
    }

    public void StopInvoke()
    {
        CancelInvoke(nameof(MakeObj));
        return;
    }

    void MakeObj()
    {
        if (wolfObj != null)
        {
            float random = Random.Range(-185, 91);
            Vector3 curPos = new(440, random, 0);
            Instantiate(wolfObj, curPos, transform.rotation);
        }
    }
}

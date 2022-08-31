using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MonoBehaviour
{
    [SerializeField]
    private GameObject spartanObj = null;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(MakeObj), 1.5f);
    }

    void MakeObj()
    {
        //GameObject obj = null;
        if (spartanObj != null)
        {
            Vector3 curPos = transform.position;
            curPos.y += 2.0f;
            Instantiate(spartanObj, curPos, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}

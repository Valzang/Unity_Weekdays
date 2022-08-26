using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heli_Rotate_Blade : MonoBehaviour
{
    public GameObject OtherAxis = null;

    float speed = 300.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 UpTarget = OtherAxis.transform.localPosition;
        Vector3 UpTarget = transform.localPosition;
        UpTarget.y += 2;
        //Vector3 dirToTarget = UpTarget - OtherAxis.transform.localPosition;
        Vector3 dirToTarget = UpTarget - transform.localPosition;
        dirToTarget = dirToTarget.normalized;

        float rot = speed * Time.deltaTime * 5;
        //this.transform.Rotate(0, -rot, 0, Space.Self);
        this.transform.Rotate(dirToTarget, -rot, Space.Self);
    }
}

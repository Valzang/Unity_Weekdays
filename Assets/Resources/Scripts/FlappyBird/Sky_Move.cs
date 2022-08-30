using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky_Move : MonoBehaviour
{
    Vector3 CamPos;
    private float moveSpeed = 4.0f;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {        
        Vector3 nextPos = this.transform.position;
        nextPos.z -= moveSpeed * Time.deltaTime;
        this.transform.position = new Vector3(nextPos.x, nextPos.y, nextPos.z);
        CamPos = Camera.main.WorldToViewportPoint(transform.position);
        print(CamPos.x);
        if (CamPos.x <= 0.0f)
        {
            CamPos.x = 1.0f;
            Vector3 newVec = Camera.main.WorldToViewportPoint(CamPos);
            Vector3 CompareVec = transform.position;

        }
    }
}

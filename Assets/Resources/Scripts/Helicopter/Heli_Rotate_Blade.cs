using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heli_Rotate_Blade : MonoBehaviour
{
    float speed = 300.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rot = speed * Time.deltaTime * 5;
        this.transform.Rotate(0, -rot, 0, Space.Self);
    }
}

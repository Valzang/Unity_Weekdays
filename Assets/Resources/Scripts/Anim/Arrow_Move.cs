using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Move : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float fireSpeed = 100.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(2.0f * fireSpeed * Time.deltaTime * Vector3.forward);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}

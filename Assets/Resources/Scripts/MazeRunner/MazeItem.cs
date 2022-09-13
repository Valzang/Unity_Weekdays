using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeItem : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, 0.0f , -100 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + "°ú Á¢ÃË");
        if(other.CompareTag("Player"))
        {
            --MazeManager.Instance.itemLeft;
            this.gameObject.SetActive(false);
        }
    }
}

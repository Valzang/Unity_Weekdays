using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitChecker : MonoBehaviour
{
    [SerializeField]
    private GameObject ExitWall = null;
    [SerializeField]
    private GameObject ExitWall_map = null;

    private bool check = false;

    private void OnTriggerStay(Collider other)
    {
        if (check)
            return;
        if(other.CompareTag("Player"))
        {            
            Vector3 nextPos = ExitWall.gameObject.transform.position;
            if(!check && nextPos.y < -12.0f)
            {
                check = true;
                Destroy(ExitWall_map);
                ExitWall.gameObject.GetComponent<BoxCollider>().enabled = false;
                return;
            }
            nextPos.y -= 5 * Time.deltaTime;
            ExitWall.gameObject.transform.position = nextPos;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDancing : MonoBehaviour
{
    private void Update()
    {
        this.gameObject.transform.Rotate(0, 30 * Time.deltaTime, 0);
    }

}

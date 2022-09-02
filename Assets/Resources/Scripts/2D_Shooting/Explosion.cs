using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update    

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<SpriteRenderer>().sprite.name == "Explosion_Altered_11")
            Destroy(this.gameObject);
    }
}

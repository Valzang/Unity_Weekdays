using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollide : MonoBehaviour
{
    public GameObject thisBody = null;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            if (other.name != thisBody.name)
            {
                Animation OtherSpartan = other.GetComponentInChildren<Animation>();
                if(!OtherSpartan.IsPlaying("die"))
                {
                    OtherSpartan.wrapMode = WrapMode.Once;
                    OtherSpartan.CrossFade("die", 0.3f);
                    this.gameObject.GetComponent<BoxCollider>().enabled = false;
                    ++SpartanGameManager.Instance.DeadSpartan;
                    ++SpartanGameManager.Instance.TotalDeadSpartan;
                }
            }
        }

        // 적이 장애물 부술때
        if (other.tag == "Obstacle" && thisBody.tag == "Enemy")
        {
            print("other : " + other.name + " / this : " + thisBody.name);
            Destroy(other.gameObject);
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }

    }
}

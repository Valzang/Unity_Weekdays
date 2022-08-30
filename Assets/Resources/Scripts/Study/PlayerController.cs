using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Animation spartanKing;

    // Start is called before the first frame update
    void Start()
    {
        spartanKing = gameObject.GetComponentInChildren<Animation>();
        spartanKing.wrapMode = WrapMode.Loop;
        spartanKing.Play("idle");
    }

    // Update is called once per frame
    void Update()
    {
        //Animation_Play_2();
        Animation_Play_3();
    }

    private void Animation_Play_1()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            spartanKing.Play("attack");
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            spartanKing.Play("idle");
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            spartanKing.Play("walk");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            spartanKing.Play("run");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            spartanKing.Play("charge");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            spartanKing.Play("idlebattle");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            spartanKing.Play("resist");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            spartanKing.Play("victory");
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            spartanKing.Play("salute");
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            spartanKing.Play("die");
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            spartanKing.Play("diehard");
        }
    }

    private void Animation_Play_2()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.CrossFade("attack", 0.3f);
            //spartanKing.Play("attack");
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.Play("attack");
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.Play("idle");
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.Play("walk");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.Play("run");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.Play("charge");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.Play("idlebattle");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.Play("resist");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.Play("victory");
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.Play("salute");
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.Play("die");
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.Play("diehard");
        }
    }

    private void Animation_Play_3()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.CrossFade("attack", 0.3f);
            //spartanKing.Play("attack");
        }
    }
}

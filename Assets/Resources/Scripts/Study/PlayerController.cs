using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject swordCollider = null;
    Animation spartanKing;

    CharacterController pcControl;
    private float runSpeed = 6.0f;
    Vector3 Velocity;

    private float rotationSpeed = 360.0f;
    


    void Start()
    {
        spartanKing = gameObject.GetComponentInChildren<Animation>();
        spartanKing.wrapMode = WrapMode.Loop;
        spartanKing.Play("idle");

        pcControl = gameObject.GetComponent<CharacterController>();
    }


    void Update()
    {
        //Animation_Play_2();
        Animation_Play_3();
        //CharacterControl();
        RotateView();
        CharacterControl_Slerp();
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
            StartCoroutine("BackToIdle", "attack");
            //spartanKing.wrapMode = WrapMode.Once;
            //spartanKing.CrossFade("attack", 0.3f);
            //spartanKing.Play("attack");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.CrossFade("attack", 0.3f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.CrossFade("idle", 0.3f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.CrossFade("walk", 0.3f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.CrossFade("run", 0.3f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.CrossFade("charge", 0.3f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.CrossFade("idlebattle", 0.3f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            StartCoroutine("BackToIdle", "resist");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            StartCoroutine("BackToIdle", "victory");
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            StartCoroutine("BackToIdle", "salute");
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            StartCoroutine("BackToIdle", "die");
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            StartCoroutine("BackToIdle", "diehard");
        }
    }

    IEnumerator BackToIdle(string _animName)
    {
        if(spartanKing.IsPlaying(_animName) != true)
        {
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.CrossFade(_animName, 0.3f);
            if (_animName == "attack")
                swordCollider.gameObject.GetComponent<BoxCollider>().enabled = true;


            float delayTime = spartanKing.GetClip(_animName).length - 0.3f;

            yield return new WaitForSeconds(delayTime);

            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.CrossFade("idle", 0.3f);
            swordCollider.gameObject.GetComponent<BoxCollider>().enabled = false;
        }        
    }

    private void CharacterControl()
    {
        Velocity = new Vector3(Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical"));

        Velocity *= runSpeed;

        if(Velocity.magnitude > 0.5f)
        {
            spartanKing.CrossFade("run", 0.3f);
            transform.LookAt(transform.position + Velocity);
        }
        else
        {
            spartanKing.CrossFade("idle", 0.3f);
        }

        //pcControl.Move(Velocity * Time.deltaTime + Physics.gravity * 0.01f);
        pcControl.SimpleMove(Velocity);
    }

    private void CharacterControl_Slerp()
    {
        if (spartanKing.IsPlaying("attack"))
            return;

        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * runSpeed*2.0f * Time.deltaTime);
            spartanKing.CrossFade("run", 0.3f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0.0f,-1.0f,0.0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0.0f,1.0f,0.0f);
        }
       
        if (spartanKing.IsPlaying("run") != true)
        {
            spartanKing.CrossFade("idle", 0.3f);
        }

        /*
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical"));

        //direction *= runSpeed;

        if (direction.sqrMagnitude > 0.01f)
        {
            spartanKing.CrossFade("run", 0.3f);

            Vector3 Forward = Vector3.Slerp(
                transform.forward, 
                direction, 
                rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction)
                );

            transform.LookAt(transform.position + Forward);
        }
        else if(spartanKing.IsPlaying("attack") != true)
        {
            spartanKing.CrossFade("idle", 0.3f);
        }

        pcControl.SimpleMove(direction * runSpeed);
        //pcControl.Move(direction * runSpeed * Time.deltaTime + Physics.gravity * 0.01f);
        */
    }

    void RotateView()
    {
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(0.0f,
                                Input.GetAxisRaw("Mouse X") * 3.0f,
                                0.0f);
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, transform.rotation.eulerAngles.y, 0.0f));
        //transform.rotation.z
    }
}

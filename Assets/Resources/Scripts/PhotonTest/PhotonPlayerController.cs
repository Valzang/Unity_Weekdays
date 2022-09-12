using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonPlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject swordCollider = null;
    Animation spartanKing;
    //private CharacterController pcControl = null;
    private readonly float runSpeed = 6.0f;
    //Vector3 Velocity;

    //private float rotationSpeed = 360.0f;
    private PhotonView photonView;
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (!photonView.IsMine)
        {
            GetComponentInChildren<Camera>().gameObject.SetActive(false);
        }
        spartanKing = gameObject.GetComponentInChildren<Animation>();
        spartanKing.wrapMode = WrapMode.Loop;
        spartanKing.Play("idle");

        //pcControl = gameObject.GetComponent<CharacterController>();
    }


    void Update()
    {

        if (!photonView.IsMine)
            return;
        //Animation_Play_2();
        Animation_Play_3();
        //CharacterControl();
        RotateView();
        CharacterControl_Slerp();
    }    private void Animation_Play_3()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetMouseButton(0))
        {
            StartCoroutine(nameof(BackToIdle), "attack");
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
            StartCoroutine(nameof(BackToIdle), "resist");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            StartCoroutine(nameof(BackToIdle), "victory");
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            StartCoroutine(nameof(BackToIdle), "salute");
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            StartCoroutine(nameof(BackToIdle), "die");
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            StartCoroutine(nameof(BackToIdle), "diehard");
        }
    }

    IEnumerator BackToIdle(string _animName)
    {
        if(spartanKing.IsPlaying(_animName) != true)
        {
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.CrossFade(_animName, 0.3f);
            if (_animName == "attack")
                swordCollider.GetComponent<BoxCollider>().enabled = true;


            float delayTime = spartanKing.GetClip(_animName).length - 0.3f;

            yield return new WaitForSeconds(delayTime);

            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.CrossFade("idle", 0.3f);
            swordCollider.GetComponent<BoxCollider>().enabled = false;
        }        
    }

    
    private void CharacterControl_Slerp()
    {
        if (spartanKing.IsPlaying("attack"))
            return;

        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(2.0f * runSpeed * Time.deltaTime * Vector3.forward);
            spartanKing.CrossFade("run", 0.3f);
        }
        else 
        {
            spartanKing.CrossFade("idle", 0.3f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0.0f,-1.0f,0.0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0.0f,1.0f,0.0f);
        }
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
    }
}

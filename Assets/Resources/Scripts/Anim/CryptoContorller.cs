using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptoContorller : MonoBehaviour
{
    [SerializeField]
    [Range(0,10)]
    private float Mouse_Sensitivity = 4.5f;

    public float runSpeed = 6.0f;
    public float rotationSpeed = 360.0f;

    CharacterController pcController;
    Vector3 direction;

    Animator animator;

    public Animator idleAnimator;
    public Animator swordAnimator;
    public Animator bowAnimator;
    public Animator gunAnimator;
    public GameObject Sword;
    public GameObject Bow;
    public GameObject Arrow;
    public GameObject Gun;


    void Start()
    {
        pcController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {        
        animator.SetFloat("Speed", pcController.velocity.magnitude);
        CharacterControl_Slerp();
        Attack();
        WeaponChange();
        RotateView();
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetMouseButton(0))
            animator.SetTrigger("Attack");
    }

    void WeaponChange()
    {
        // 검
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (animator.runtimeAnimatorController.name != swordAnimator.runtimeAnimatorController.name)
            {
                animator.runtimeAnimatorController = swordAnimator.runtimeAnimatorController;
                Sword.SetActive(true);
            }
            else
            {
                animator.runtimeAnimatorController = idleAnimator.runtimeAnimatorController;
                Sword.SetActive(false);
            }
        }

        // 활
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (animator.runtimeAnimatorController.name != bowAnimator.runtimeAnimatorController.name)
                animator.runtimeAnimatorController = bowAnimator.runtimeAnimatorController;
            else
                animator.runtimeAnimatorController = idleAnimator.runtimeAnimatorController;
        }

        // 총
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (animator.runtimeAnimatorController.name != gunAnimator.runtimeAnimatorController.name)
                animator.runtimeAnimatorController = gunAnimator.runtimeAnimatorController;
            else
                animator.runtimeAnimatorController = idleAnimator.runtimeAnimatorController;
        }
    }

    void CharacterControl_Slerp()
    {
        direction = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            direction = transform.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {            
            transform.Rotate(0.0f, -1.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0.0f, 1.0f, 0.0f);
        }   
        pcController.Move(runSpeed * Time.deltaTime * direction);
    }

    void RotateView()
    {
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(0.0f,
                                Input.GetAxisRaw("Mouse X") * Mouse_Sensitivity,
                                0.0f);
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, transform.rotation.eulerAngles.y, 0.0f));
    }

    void setOnCollider()
    {
        Sword.transform.GetChild(0).transform.gameObject.GetComponent<BoxCollider>().enabled = true;
        print("검 콜리전 ON");
    }

    void setOffCollider()
    {
        Sword.transform.GetChild(0).transform.gameObject.GetComponent<BoxCollider>().enabled = false;
        print(Sword.transform.GetChild(0).transform.gameObject.GetComponent<BoxCollider>().name);
        print("검 콜리전 OFF");
    }
}

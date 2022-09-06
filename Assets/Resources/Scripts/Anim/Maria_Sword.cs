using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maria_Sword : MonoBehaviour
{
    [SerializeField]
    GameObject SwordCollider = null;
    
    public float runSpeed = 6.0f;
    public float rotationSpeed = 360.0f;

    CharacterController pcController;
    Vector3 direction;

    Animator animator;


    void Start()
    {
        pcController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        SwordCollider.SetActive(false);
    }

    void Update()
    {
        animator.SetFloat("Speed", pcController.velocity.magnitude);
        CharacterControl_Slerp();
        Attack();
        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetBool("Sit", !animator.GetBool("Sit"));
        }
    }

    [System.Obsolete]
    private void FixedUpdate()
    {
        if((isAnimating("Run")
            || isAnimating("Standing")))
        {
            print("걷거나 서있는 중");
            SwordCollider.SetActive(false);
        }

        if (isAnimating("Attack 1") || isAnimating("Attack 2")
            || isAnimating("Attack 3") || isAnimating("Attack 4"))
        {
            print("공격 중");
            SwordCollider.SetActive(true);
        }
    }

    void Attack()
    {        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animator.SetTrigger("Attack1");
            SwordCollider.SetActive(true);
        }            
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            animator.SetTrigger("Attack2");
            SwordCollider.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            animator.SetTrigger("Attack3");
            SwordCollider.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            animator.SetTrigger("Attack4");
            SwordCollider.SetActive(true);
        }
    }

    bool isAnimating(string _name)
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(_name) 
            && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.95f;
    }

    void CharacterControl_Slerp()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (direction.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp(
                transform.forward,
                direction,
                rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction));
            transform.LookAt(transform.position + forward);
        }
        else
        {

        }

        pcController.Move(runSpeed * Time.deltaTime * direction);
    }
}

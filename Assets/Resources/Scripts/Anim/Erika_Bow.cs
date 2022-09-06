using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Erika_Bow : MonoBehaviour
{
    
    public float runSpeed = 6.0f;
    public float rotationSpeed = 360.0f;

    CharacterController pcController;
    Vector3 direction;

    Animator animator;


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
    }


    void Attack()
    {        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animator.SetTrigger("Attack");
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

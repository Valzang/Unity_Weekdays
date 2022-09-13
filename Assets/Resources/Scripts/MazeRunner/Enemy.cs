using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent agent;
    Animator animator;

    private float stunTime = 0.0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if(MazeManager.Instance.isEnemyStun)
        {
            stunTime += Time.deltaTime;
            if (stunTime > 5.0f)
            {
                stunTime = 0.0f;
                MazeManager.Instance.isEnemyStun = false;
                animator.SetBool("Stun", false);
                Debug.Log("적 스턴 벗어남");
            }
            return;
        }
        agent.destination = target.transform.position;
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Sword"))
        {
            if (MazeManager.Instance.isEnemyStun)
                stunTime = 0.0f;
            else
            {
                MazeManager.Instance.isEnemyStun = true;
            }
            animator.SetBool("Stun", true);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    [SerializeField] public Transform target;
    private NavMeshAgent navMeshAgent;
    private Rigidbody rb;
    private Animator animator;
    [SerializeField] private EnemyHealth enemyHealth;
    
    private float lastAttacKTime = 0f;
    [SerializeField] private float timeBetweenAttacks = 2f;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (enemyHealth.IsDead())
        {
            navMeshAgent.isStopped = true;
            animator.SetBool("Run", false);
        }
        else
        {
            animator.SetBool("Run", navMeshAgent.velocity.magnitude > 0.5f);

            if (target != null && navMeshAgent.isOnNavMesh)
            {
                navMeshAgent.SetDestination(target.position);

                if (Vector3.Distance(transform.position, target.position) < 2.2f)
                {
                    if (Time.time > lastAttacKTime + timeBetweenAttacks)
                    {
                        animator.SetTrigger("Attack");
                        lastAttacKTime = Time.time;
                    }
                }
            }
        }
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseControls : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float moveSpeed = 10f;
    
    
    private CharacterController characterController;
    private Animator animator;
    private Vector3 targetPosition;

   

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        targetPosition = transform.position;
    }

    private void Update()
    {
        float distToTarget = Vector3.Distance(transform.position, targetPosition);
        if (distToTarget > 1f && PlayerHealth.isAlive)
        {
            Vector3 targetDirection = Vector3.Normalize(targetPosition - transform.position);
            characterController.Move(targetDirection * moveSpeed * Time.deltaTime);
            transform.LookAt(targetPosition);
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 500, layerMask))
            {
                //print("hit: " + hit.collider.name);
                targetPosition = hit.point;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Chop");
        }
    }
}

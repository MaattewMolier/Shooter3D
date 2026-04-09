using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    // Enemy movement settings options
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform target;

    [SerializeField] private float animationSpeed = 1f;
    [SerializeField] private float animationMotionSpeed = 1f;

    [SerializeField] private float speedChangeMultipler = 3f;

    private void Update()
    {
        // Enemy walking
        if(target != null){
            agent.SetDestination(target.position);
            if (agent.remainingDistance > 1.5f)
            {
                animator.SetFloat("Speed", animationSpeed);
                animator.SetFloat("MotionSpeed", animationMotionSpeed);
            }
            else
            {
                float newSpeed = Mathf.MoveTowards(animator.GetFloat("Speed"), 0f, Time.deltaTime * speedChangeMultipler);
                animator.SetFloat("Speed", newSpeed);
                animator.SetFloat("MotionSpeed", animationMotionSpeed);
            }
        }
        else
        {
            agent.ResetPath();
        }
        
    }
    // Animation Event
    public void OnFootstep()
    {
        Debug.Log("Footstep!");
    }

    // Setting target (either Player or Tree)
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}

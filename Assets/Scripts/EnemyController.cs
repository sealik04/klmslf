using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform playerTransform;
    public NavMeshAgent navMesh;
    public Animator enemyAnim;
    HealthController enemyHealthController;
    public float enemySpeed = 5f;
    public float attackRange = 3f;
    public float damageAmount = 25f;
    
    

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        navMesh = GetComponent<NavMeshAgent>();
        navMesh.speed = enemySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer <= attackRange)
        {
            navMesh.isStopped = true;
            enemyAnim.SetBool("isRunning", false);
            enemyAnim.SetBool("isAttacking", true);
        }
        else
        {
            navMesh.isStopped = false;
            navMesh.destination = playerTransform.position;
            enemyAnim.SetBool("isRunning", true);
            enemyAnim.SetBool("isAttacking", false);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerController playerController = collision.collider.GetComponent<PlayerController>();
            
            if (playerController != null)
            {
                playerController.TakeDamage(damageAmount);
            }
        }
    }

   
}
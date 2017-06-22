using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    public GameObject DesiredTarget;
    public float EnemyAIInterval = 1f;
    private NavMeshAgent navMeshAgent;
    //private float LastAICheck;

    void Start()
    {
        //LastAICheck = Time.time;
        navMeshAgent = GetComponent<NavMeshAgent>();
        InvokeRepeating("FollowTarget", 2f, EnemyAIInterval);
    }

    void Update()
    {
        //FollowTarget();
    }

    private void FollowTarget()
    {
        // Only recalculate the NavMesh destination every second
        //if (Time.time >= (LastAICheck + EnemyAIInterval))
        //{
            Vector3 destinaton = DesiredTarget.transform.position;
            navMeshAgent.SetDestination(destinaton);
            //LastAICheck = Time.time;
        //}
    }
}

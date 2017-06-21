using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    public GameObject DesiredTarget;
    private NavMeshAgent navMeshAgent;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        HeadForDestintation();
    }

    private void HeadForDestintation()
    {
        Vector3 destinaton = DesiredTarget.transform.position;
        navMeshAgent.SetDestination(destinaton);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;


[RequireComponent(typeof(NavMeshAgent))]
public class EnemyPathFinding : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject target;



    private void Awake()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        target = FindObjectOfType<BuildManager>().gameObject;
    }

    public void Disable()
    {
        agent.SetDestination(transform.position);
    }
    private void Update()
    {
        agent.SetDestination(target.transform.position);
    }
}

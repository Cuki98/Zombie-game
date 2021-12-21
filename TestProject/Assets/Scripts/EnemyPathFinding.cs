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
    public float maxDistance = 10;


    private void Awake()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        target = FindObjectOfType<BuildManager>().gameObject;
    }

    public void Disable()
    {
        agent.SetDestination(transform.position);
    }

    public void SetSpeed(float speed)
    {
        agent.speed = speed;
    }
    private void Update()
    {
        if(Vector3.Distance(transform.position , target.transform.position) > maxDistance)
        agent.SetDestination(target.transform.position);
    }
}

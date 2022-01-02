using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiRandomRoaming : MonoBehaviour
{
    private NavMeshAgent agent;
    public float walkRadius;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating("FindRandomPosition", 0f , Random.Range(3 , 8));
    }
    public void FindRandomPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
        randomDirection.y = 0;
        randomDirection += transform.position;
        agent.SetDestination(randomDirection);
    }
}

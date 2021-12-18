using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(HealthComponent))]
public class RagdollDeath : MonoBehaviour
{
    HealthComponent healthComponent;
    public GameObject deathParticles;
    private void Awake()
    {
        healthComponent = GetComponent<HealthComponent>();
        healthComponent.OnHealthRunOut += ActivateRagdoll;


        Rigidbody[] rigidBodies = GetComponentsInChildren<Rigidbody>();
        Collider [] colliders = GetComponentsInChildren<Collider>();

        for (int i = 0; i < rigidBodies.Length; i++)
        {
            rigidBodies[i].useGravity = false;
            rigidBodies[i].isKinematic = true;
            colliders[i].isTrigger = true;
        }
    }

    private void ActivateRagdoll(object sender, EventArgs e)
    {
     
        GetComponent<EnemyPathFinding>().Disable();
        GetComponent<EnemyPathFinding>().enabled = false;
        Destroy(GetComponent<CapsuleCollider>());//.enabled = false;
        GetComponent<Animator>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;

        Tools.SetLayerRecursively(gameObject , 7);
        

        Rigidbody [] rigidBodies  = GetComponentsInChildren<Rigidbody>();
        Collider[] colliders = GetComponentsInChildren<Collider>();
        for (int i = 0; i < rigidBodies.Length; i++)
        {
            rigidBodies[i].useGravity = true;
            rigidBodies[i].isKinematic = false;
            colliders[i].isTrigger = false;
        }
        rigidBodies[UnityEngine.Random.Range(0 , rigidBodies.Length)].AddForce((transform.up * Tools.GetNumberBetween(-1 , 1) )* 700/2 , ForceMode.Impulse);

        Instantiate(deathParticles , transform.position , Quaternion.identity);
    }


}

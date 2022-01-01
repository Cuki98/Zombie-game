using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollToggler : MonoBehaviour
{
    private void Awake()
    {
        ToggleRagdoll(true);
    }
    public void ToggleRagdoll(bool value)
    {
        if (value == true)
        {
            Rigidbody[] rigidBodies = GetComponentsInChildren<Rigidbody>();
            Collider[] colliders = GetComponentsInChildren<Collider>();
            for (int i = 0; i < rigidBodies.Length; i++)
            {
                rigidBodies[i].useGravity = true;
                rigidBodies[i].isKinematic = false;
                colliders[i].isTrigger = false;
            }
        }
        else if (value == false)
        {
            Rigidbody[] rigidBodies = GetComponentsInChildren<Rigidbody>();
            Collider[] colliders = GetComponentsInChildren<Collider>();

            for (int i = 0; i < rigidBodies.Length; i++)
            {
                rigidBodies[i].useGravity = false;
                rigidBodies[i].isKinematic = true;
                colliders[i].isTrigger = true;
            }
        }
    }
}

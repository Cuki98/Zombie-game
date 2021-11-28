using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Vector3 rotation;
    public float rotationSpeed;

    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + rotation * rotationSpeed * Time.deltaTime);    
    }
}

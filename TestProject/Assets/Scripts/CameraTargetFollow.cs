using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetFollow : MonoBehaviour
{

    public Transform target;
    public float followSpeed;
    public float yOffset;

    private void Update()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = new Vector3(target.position.x, yOffset, target.position.z);
        transform.position = Vector3.Slerp(transform.position, targetPos, followSpeed * Time.deltaTime);
    }
}

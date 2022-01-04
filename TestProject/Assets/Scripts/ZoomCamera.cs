using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{

    public Transform original;
    public Transform target;
    public Vector3 targetOffset;

    public void ResetTarget()
    {
        target = null;
        LeanTween.move(gameObject, original.position, 0.3f).setEaseLinear();
        LeanTween.rotate(gameObject, original.rotation.eulerAngles, 0.3f).setEaseLinear();
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
        LeanTween.move(gameObject, target.position + targetOffset, 0.3f).setEaseLinear();
        LeanTween.rotate(gameObject, target.rotation.eulerAngles + targetOffset, 0.3f).setEaseLinear();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Camera Shake")]
public class CameraShakeSO : ScriptableObject
{
    public float shakeDuration = 0.02f;
    public float shakeAmmount = 0.1f;
    public float decreaseFactor = 0.09f;
}

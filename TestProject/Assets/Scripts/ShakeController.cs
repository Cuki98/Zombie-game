using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeController : MonoBehaviour
{
	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	[Header("Shaking")]
	public Transform ShakeTransform;

	// How long the object should shake for.
	public float shakeDuration = 0f;

	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;


	Vector3 originalPos;

	public void AddShake(float ShakeDuration, float shakeAmmount, float decreaseFactor)
	{
		this.shakeDuration = ShakeDuration;
		this.shakeAmount = shakeAmmount;
		this.decreaseFactor = decreaseFactor;
	}

	void OnEnable()
	{
		originalPos = ShakeTransform.localPosition;
	}

	void Update()
	{
		if (!ShakeTransform) return;
		if (shakeDuration > 0)
		{
			ShakeTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shakeDuration = 0f;
			ShakeTransform.localPosition = Vector3.Slerp(transform.localPosition, originalPos, 15 * Time.deltaTime);
		}
	}
}

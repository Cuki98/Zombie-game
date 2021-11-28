using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

	public ShakeController shake;
	public static CameraController i;


	private void Awake()
	{
		i = this;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    public ShakeController shakeController;
    public static UiController i;

    private void Awake()
    {
        i = this;
    }
}

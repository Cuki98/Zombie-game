using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDeath : MonoBehaviour
{
    HealthComponent health;

    private void Awake()
    {
        health = GetComponent<HealthComponent>();
        health.OnHealthRunOut += OnHealthRunOut;
    }

    private void OnHealthRunOut(object sender, EventArgs e)
    {
        Destroy(gameObject);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CameraShakeSO takeDamageShake;
    HealthComponent healthComponent;

    private void Awake()
    {
        healthComponent = GetComponent<HealthComponent>();
        healthComponent.OnTakeDamage += OnDamageTaken;
        healthComponent.OnHealthRunOut += OnDie;
    }

    private void OnDie(object sender, EventArgs e)
    {
        IAlive[] aliveComponents =  GetComponents<IAlive>();
        for (int i = 0; i < aliveComponents.Length; i++)
        {
            aliveComponents[i].Disable();
        }
    }

    private void OnDamageTaken(object sender, HealthComponent.DamageTakenArgs e)
    {
        CameraController.i.shake.AddShake(takeDamageShake.shakeDuration , takeDamageShake.shakeAmmount , takeDamageShake.decreaseFactor);
    }
}

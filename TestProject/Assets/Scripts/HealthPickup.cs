using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PickupHandler))]
public class HealthPickup : Pickup
{

    [Range(0 , 100)]public float healthPercent;

    public override void OnPickedUp(GameObject player)
    {
        HealthComponent health = player.GetComponent<HealthComponent>();
        if (health != null)
        {
            health.HealPercentage(healthPercent);
        }
    }
}

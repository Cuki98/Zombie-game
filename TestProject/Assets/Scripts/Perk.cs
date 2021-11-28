using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
public class Perk : Pickup
{
    public PickupData data;
    public float perkDuration;
 


    public override void OnPickedUp(GameObject player)
    {
        PerkHandler pHandler = player.GetComponent<PerkHandler>();
        if (pHandler) pHandler.HandlePerk(new PerkAftermath(data, perkDuration, OnPerkTerminated));
  
    }
    public virtual void OnPerkTerminated()
    {
      
    }

    
}

public class PerkAftermath
{

    public UnityAction terminationEvent;
    public PickupData data;
    public float duration;
    public float currentDuration;
    public PerkAftermath(PickupData data, float duration , UnityAction terminationEvent)
    {
        this.data = data;
        this.duration = duration;
        this.terminationEvent = terminationEvent;
        currentDuration = duration;
    }
}


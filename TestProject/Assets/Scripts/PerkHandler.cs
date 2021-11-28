using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PerkHandler : MonoBehaviour
{
    public List<PerkAftermath> activePerks = new List<PerkAftermath>();

    public event EventHandler<PerkHandlerEventArgs> PerkAdded;
    public event EventHandler<PerkHandlerEventArgs> PerkRenewed;
    public event EventHandler<PerkHandlerEventArgs> perkTerminated;

    private void Update()
    {

        for (int i = 0; i < activePerks.Count; i++)
        {
            activePerks[i].currentDuration -= Time.deltaTime;


            if (activePerks[i].currentDuration <= 0)
            {
                activePerks[i].terminationEvent?.Invoke();
                perkTerminated?.Invoke(this , new PerkHandlerEventArgs {data = activePerks[i].data });
                activePerks.Remove(activePerks[i]);
            }
        }
    }

    public void HandlePerk(PerkAftermath perk)
    {
        bool foundPerk = false;
        for (int i = 0; i < activePerks.Count ; i++)
        {
            if (perk.data.Name == activePerks[i].data.Name)
            {
                foundPerk = true;
                activePerks[i].currentDuration = activePerks[i].duration;
                PerkRenewed?.Invoke(this, new PerkHandlerEventArgs { data = activePerks[i].data });
            }
        }


        if (!foundPerk)
        {
            activePerks.Add(perk);
            PerkAdded?.Invoke(this , new PerkHandlerEventArgs {data = perk.data });
        }


            
    }

    public class PerkHandlerEventArgs
    {
        public PickupData data;
    }
}

using UnityEngine;

public class InstaKill : Perk
{
    DamageDistributor distributor;
    public override void OnPickedUp(GameObject player)
    {
       base.OnPickedUp(player);
         distributor = player.GetComponent<DamageDistributor>();
        if (distributor) distributor.SetInstaKill(true);
    }
   
    public override void OnPerkTerminated()
    {
        base.OnPerkTerminated();
        distributor.SetInstaKill(false);
    }
}

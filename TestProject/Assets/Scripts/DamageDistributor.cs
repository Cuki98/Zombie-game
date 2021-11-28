using UnityEngine;

public class DamageDistributor : MonoBehaviour
{

    private bool instaKill;
    public void DealDamage(HealthComponent health , float damage , DamageType type)
    {
        if (instaKill)
        {
            health.TakeDamage(health.health.clampValues.maximum, type);
        }
        else      
        {
            health.TakeDamage(damage, type);
        }
    }

    public void SetInstaKill(bool value)
    {
        instaKill = value;
    }
}

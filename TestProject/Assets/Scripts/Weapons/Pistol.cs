using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Firearm
{

    private void Start()
    {
        SetUp();
    }
 
    public override void Shoot()
    {
        Projectile p_temp = ObjectPooler.Instance.SpawnFromPool("NormalBullets", projectileEjectionPoint.position , projectileEjectionPoint.rotation).GetComponent<Projectile>();
        p_temp.SetUp(damageDistributor);
        base.Shoot(); 
    }
}

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
        Projectile p_temp = Instantiate(projectile, projectileEjectionPoint.position, projectileEjectionPoint.rotation);
        p_temp.SetUp(damageDistributor);
        base.Shoot(); 
    }
}

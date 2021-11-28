using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ProjectileShooting : MonoBehaviour
{
    public GasAction actionAttributes;
    public Transform projectileEjectionPoint;
    public Projectile projectile;

    private event EventHandler OnShoot; 

    private void Awake()
    {
       // actionAttributes.OverrideAction(Shoot(DamageDistributor distributor));
    }
    public void Shoot(DamageDistributor distributor)
    {
        Projectile p_temp = Instantiate(projectile, projectileEjectionPoint.position, projectileEjectionPoint.rotation);
        p_temp.SetUp(distributor);
    }
}

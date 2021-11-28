using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Firearm
{
    public float pellets;
    public float PelletSpread;

    private void Start()
    {
        SetUp();
      
    }

    public override void Shoot()
    {
        for (int i = 0; i < pellets; i++)
        {
            Quaternion rot = projectileEjectionPoint.rotation;
            rot.y += Random.Range(-PelletSpread, PelletSpread);
            Projectile p_temp = Instantiate(projectile, projectileEjectionPoint.position, rot);
            p_temp.SetUp(damageDistributor);
        }
        base.Shoot();
    }
}

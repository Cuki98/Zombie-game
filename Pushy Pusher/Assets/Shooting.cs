﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectile;
    public Transform fireposition;
    public float fireRate;
    private float lastShotTime;
    
    bool cooldownOver{ get { return Time.time >= lastShotTime + fireRate; } }
    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownOver)
        {
            Instantiate(projectile , fireposition.position , fireposition.rotation);
            lastShotTime = Time.time;
        }
    }
}

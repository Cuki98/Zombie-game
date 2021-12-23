using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firearm : Weapon
{
    public int currentAmmo;
    public int maxAmmo;
    public float fireRate;
    public float damage;

    public AudioClip shootSfx;
    protected DamageDistributor damageDistributor;
    public CameraShakeSO shootingShake;

    [Header("Transforms")]
    public Transform projectileEjectionPoint;
    public Projectile projectile;

    protected float lastShotTime;

    //Checks if the shooting cooldown is down
    protected bool FireCooldownActive { get { return Time.time >= lastShotTime + fireRate; } }

    protected bool shootingConstraint = false;
    protected bool CanShoot { get { return FireCooldownActive && !shootingConstraint && !usageConstraint; } }

    protected GasAction gShoot;


    private void Start()
    {
        SetUp();
    }

    public override void InputCallbacks()
    {
        if (CanShoot)
            Shoot();
    }

    public virtual void SetUp()
    {
        damageDistributor = weaponOwner.GetComponent<DamageDistributor>();
    }

    public virtual void Shoot()
    {
        lastShotTime = Time.time;
        CameraController.i.shake.AddShake(shootingShake.shakeDuration, shootingShake.shakeAmmount, shootingShake.decreaseFactor);
        gameObject.ReproduceLocalSound(shootSfx , soundSettings: new SoundManager.SoundSettings(0.2f));
  
    }
}

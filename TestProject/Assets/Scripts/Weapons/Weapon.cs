using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponData weaponData;
    protected GameObject weaponOwner;
    [HideInInspector]public bool usageConstraint = false;

    public virtual void InputCallbacks()
    {
        
    }

    public virtual void Initialize(GameObject weaponOwner)
    {
        this.weaponOwner = weaponOwner;
    }
}

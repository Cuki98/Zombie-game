using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class WeaponHandler : MonoBehaviour
{
    public Weapon[] loadout;
    public float switchWeaponInterval;
    public Transform WeaponHolder;


    [HideInInspector]public int loadoutIndex;
    //Swithc Checks
    float lastSwitchedTime;
    public bool SwitchCooldownActive { get { return Time.time >= lastSwitchedTime + switchWeaponInterval; } }
    public bool CanSwitchWeapon { get { return SwitchCooldownActive; /*&& Input.GetAxisRaw("Mouse ScrollWheel") != 0;*/ } }

    public event EventHandler<SwitchWeaponArgs> OnSwitchedWeapon;


    //Actions
    private GasAction gCallWeaponInputs;
    private GasAction gSwitchWeapons;


    //components
    private InputManager inputManager;

    private void Awake()
    {
        //SetUp Firearms
        for (int i = 0; i < loadout.Length; i++)
        {
            loadout[i].Initialize(gameObject);
        }

        inputManager = GetComponent<InputManager>();
        ActionManager manager = GetComponent<ActionManager>();

    }
    private void Update()
    {
        if(inputManager.IsTouchDown())
        loadout[loadoutIndex].InputCallbacks();
    }
    public void GiveWeapon()
    {
        
    }
    public void RetrieveWeapon()
    {
        
    }
    public void EquipWeapon(int index)
    {
        Transform activatingWeapon = null;

        for (int i = 0; i < WeaponHolder.childCount; i++)
        {
            WeaponHolder.GetChild(i).gameObject.SetActive(false);

            if (WeaponHolder.GetChild(i).name == loadout[loadoutIndex].weaponData.Name)
            {
                activatingWeapon = WeaponHolder.GetChild(i);
            }
        }

        if(activatingWeapon != null)
        activatingWeapon.gameObject.SetActive(true);
    }
    public void SwitchWeapon(bool up)
    {
        
        if (loadout.Length == 1 || !CanSwitchWeapon) return;
        if (!up)
        {
            if (loadoutIndex == loadout.Length - 1)
            {
                loadoutIndex = 0;
            }
            else loadoutIndex++;
        }
        else if (up)
        {
            if (loadoutIndex == 0)
            {
                loadoutIndex = loadout.Length - 1;
            }
            else
                loadoutIndex--;
        }


        lastSwitchedTime = Time.time;
        OnSwitchedWeapon?.Invoke(this, new SwitchWeaponArgs {Up=  up });
        EquipWeapon(loadoutIndex);

     

    }

    public Weapon GetEquippedWeapon()
    {
        return loadout[loadoutIndex];
    }
    public void DeativateWeaponUsage()
    {
        for (int i = 0; i < loadout.Length; i++)
        {
            loadout[i].usageConstraint = true;
        }
    }
    public void ActivateWeaponUsage()
    {
        for (int i = 0; i < loadout.Length; i++)
        {
            loadout[i].usageConstraint = false;
        }
    }
    public Weapon GetPreviousWeapon()
    {
        if (loadout.Length == 1) return null;

        int tempLoadoutIndex = loadoutIndex;

        if (loadoutIndex == 0)
        {
            tempLoadoutIndex = loadout.Length - 1;
        }
        else
            tempLoadoutIndex--;

        return loadout[tempLoadoutIndex];
    }
    public Weapon GetNextWeapon()
    {
        if (loadout.Length == 1) return null;

        int tempLoadoutIndex = loadoutIndex;

        if (loadoutIndex == loadout.Length - 1)
        {
            tempLoadoutIndex = 0;
        }
        else
            tempLoadoutIndex++;

        return loadout[tempLoadoutIndex];
    }

    public class SwitchWeaponArgs : EventArgs
    {
        public bool Up;
    }
}

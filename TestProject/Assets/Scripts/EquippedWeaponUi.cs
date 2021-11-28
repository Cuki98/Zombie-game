using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquippedWeaponUi : MonoBehaviour
{
    public LoadoutWeaponSlot previousWeapon;
    public LoadoutWeaponSlot mainWeapon;
    public LoadoutWeaponSlot NextWeapon;

    public WeaponHandler weaponH;

    public Button up;
    public Button down;



    //vectors
    Vector3 equippedSlotPosition;
    Vector3 equippedSlotScale;

    Vector3 previousSlotPosition;
    Vector3 previousSlotScale;

    Vector3 nextSlotPosition;
    Vector3 nextSlotScale;

    private void Awake()
    {
        weaponH.OnSwitchedWeapon += OnWeaponSwitch;
        up.onClick.AddListener(() => 
        {
            weaponH.SwitchWeapon(true);
        });
        down.onClick.AddListener(() =>
        {
            weaponH.SwitchWeapon(false);
        });


        equippedSlotPosition = mainWeapon.transform.position;
        equippedSlotScale = mainWeapon.transform.localScale;


        previousSlotPosition = previousWeapon.transform.position;
        previousSlotScale = previousWeapon.transform.localScale;

        nextSlotPosition = NextWeapon.transform.position;
        nextSlotScale = NextWeapon.transform.localScale;
    }

    private void OnWeaponSwitch(object sender, WeaponHandler.SwitchWeaponArgs e)
    {



        PopulateWeapon();

        if (e.Up)
        {
            mainWeapon.transform.position = previousSlotPosition;
            mainWeapon.transform.localScale = previousSlotScale;

            NextWeapon.transform.position = equippedSlotPosition;
            NextWeapon.transform.localScale = equippedSlotScale;

            previousWeapon.transform.position = nextSlotPosition;
            previousWeapon.transform.localScale = nextSlotScale;



            //PreviousWeapon
            LeanTween.move(mainWeapon.gameObject, equippedSlotPosition, .12f);
            LeanTween.scale(mainWeapon.gameObject, equippedSlotScale, .12f);

            LeanTween.move(previousWeapon.gameObject, previousSlotPosition, .12f);
            LeanTween.scale(previousWeapon.gameObject, previousSlotScale, .12f);


            LeanTween.move(NextWeapon.gameObject, nextSlotPosition, .12f);
            LeanTween.scale(NextWeapon.gameObject, nextSlotScale, .12f);

        }
        else
        {

            mainWeapon.transform.position = nextSlotPosition;
            mainWeapon.transform.localScale = nextSlotScale;

            NextWeapon.transform.position = equippedSlotPosition;
            NextWeapon.transform.localScale = equippedSlotScale;

            previousWeapon.transform.position = equippedSlotPosition;
            previousWeapon.transform.localScale = equippedSlotScale;



            //PreviousWeapon
            LeanTween.move(mainWeapon.gameObject, equippedSlotPosition, .12f);
            LeanTween.scale(mainWeapon.gameObject, equippedSlotScale, .12f);

            LeanTween.move(NextWeapon.gameObject, nextSlotPosition, .12f);
            LeanTween.scale(NextWeapon.gameObject, nextSlotScale, .12f);

            LeanTween.move(previousWeapon.gameObject, previousSlotPosition, .12f);
            LeanTween.scale(previousWeapon.gameObject, previousSlotScale, .12f);

        }


    }

    private void Start()
    {
        PopulateWeapon();
    }
    private void PopulateWeapon()
    {
        if (weaponH.GetPreviousWeapon() == null)
            previousWeapon.gameObject.SetActive(false);
        else
        {
            previousWeapon.gameObject.SetActive(true);
            previousWeapon.weapon = weaponH.GetPreviousWeapon();
        }

        if (weaponH.GetNextWeapon() == null)
            NextWeapon.gameObject.SetActive(false);
        else
        {
            NextWeapon.gameObject.SetActive(true);
            NextWeapon.weapon = weaponH.GetNextWeapon();
        }

        if (previousWeapon.weapon == NextWeapon.weapon)
        {
            NextWeapon.gameObject.SetActive(false);
        }
        else
        {
            NextWeapon.gameObject.SetActive(true);
        }

        mainWeapon.weapon = weaponH.loadout[weaponH.loadoutIndex];
    }


}

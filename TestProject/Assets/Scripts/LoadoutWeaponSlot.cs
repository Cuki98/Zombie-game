using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadoutWeaponSlot : MonoBehaviour
{
    public Weapon weapon;
    public Image weaponImage;
    public TMPro.TextMeshProUGUI ammunitionText;


    private void Update()
    {

        if (!weapon) return;


        Firearm fireWeapon = (Firearm)weapon;

        if (fireWeapon)
        {
            ammunitionText.gameObject.SetActive(true);
            ammunitionText.text = string.Format("<size=%100>{0}</size><size=%70>/{1}</size>", fireWeapon.currentAmmo, fireWeapon.maxAmmo);
        }

        
        weaponImage.sprite = weapon.weaponData.thumbNail;
    }

}

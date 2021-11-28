using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Data")]
public class WeaponData : ScriptableObject
{
    public string Name;
    public Sprite thumbNail;
    public float price;
}

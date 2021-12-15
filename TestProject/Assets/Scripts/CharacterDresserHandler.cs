using AdvancedPeopleSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterDresserHandler : MonoBehaviour
{
    public CharacterSettings characterSettings;
    public CharacterSettings temporaryCharacterSettings;

    public CharacterCustomization characterCustomization;

     

    public static CharacterDresserHandler Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Debug.Log("Ran");
        characterCustomization.LoadCharacterFromFile("Data/Character/appack25");
    }

    public void ResetToDefault()
    {
        characterCustomization.ResetAll();
    }
    public void TemporaryEquip(CharacterElementType type, int equip)
    {
        //ResetToDefault();
        characterCustomization.SetElementByIndex(type, equip);     
    }

    public void Revert()
    {

    }
}

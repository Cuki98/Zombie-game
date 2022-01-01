using AdvancedPeopleSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class CharacterDresserHandler : MonoBehaviour
{
    public CharacterCustomization characterCustomization;

    public static CharacterDresserHandler Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        List<SavedCharacterData> data = characterCustomization.GetSavedCharacterDatas();
        characterCustomization.LoadCharacterFromFile(data[data.Count - 1].path);
    }

    public void ResetToDefault()
    {
        characterCustomization.ResetAll();
    }
    public void TemporaryEquip(CharacterElementType type, int equip)
    {
        //ResetToDefault();
        characterCustomization.SetElementByIndex(type, equip);
        characterCustomization.ClearSavedData();
        characterCustomization.SaveCharacterToFile(CharacterCustomizationSetup.CharacterFileSaveFormat.Json);
        
    }

    public void Revert()
    {
        
    }
}

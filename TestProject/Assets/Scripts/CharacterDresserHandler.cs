using AdvancedPeopleSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using Photon.Pun;
using Photon.Realtime;

public class CharacterDresserHandler : MonoBehaviour
{
    public bool LoadOnAwake;
    public bool autoUpdate = true;
    public CharacterCustomization characterCustomization;

  

    private void Awake()
    {
    }

    private void OnEnable()
    {
        if (LoadOnAwake)
            LoadCharacter();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TemporaryEquip(CharacterElementType.Hat , Random.Range(0 , 5));
        }
    }
    public void ResetToDefault()
    {
        characterCustomization.ResetAll();
    }
    public void TemporaryEquip(CharacterElementType type, int equip)
    {
        //ResetToDefault();
        characterCustomization.SetElementByIndex(type, equip);
        SaveCharacter();
        Debug.Log(characterCustomization.name);
        
    }

    public void LoadAll()
    {
        CharacterDresserHandler[] character = FindObjectsOfType<CharacterDresserHandler>();

        for (int i = 0; i < character.Length; i++)
        {
            if (character[i].autoUpdate)
            {
                character[i].LoadCharacter();
            }
        }
    }
    public void LoadCharacter()
    {
        if (!characterCustomization) return;
        PhotonView pv=   GetComponent<PhotonView>();

        if (pv)
        {
            if (!pv.IsMine) return;
            List<SavedCharacterData> data = characterCustomization.GetSavedCharacterDatas();
            characterCustomization.LoadCharacterFromFile(data[data.Count - 1].path);

        }
        else
        {
            List<SavedCharacterData> data = characterCustomization.GetSavedCharacterDatas();
            characterCustomization.LoadCharacterFromFile(data[data.Count - 1].path);
        }
    }
    public void SaveCharacter()
    {
        characterCustomization.ClearSavedData();
        characterCustomization.SaveCharacterToFile(CharacterCustomizationSetup.CharacterFileSaveFormat.Json);
    }
}

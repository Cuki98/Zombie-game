using AdvancedPeopleSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuyableClothingItemUi : MonoBehaviour
{
    private ItemCollection item;
    private CharacterElementType clothingType;
    private int clothingIndex;

    private Button button;
    public void SetItem(ItemCollection item)
    {
        this.item = item;
    }

    public void SetUp(CharacterElementType clotheType , int index)
    {
        this.clothingType = clotheType;
        clothingIndex = index;

    }
    private void Awake()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(() =>
        {
            CharacterDresserHandler.Instance.TemporaryEquip(clothingType , clothingIndex);
        });
    }
}

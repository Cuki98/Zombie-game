using AdvancedPeopleSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class BuyableClothingItemUi : MonoBehaviour
{
    private ItemCollection item;
    private CharacterElementType clothingType;
    private int clothingIndex;

    public UnityAction onButtonClicked = ()=> { };
    public Button button;
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
            Debug.Log(onButtonClicked == null);
            onButtonClicked?.Invoke();
        });
    }
}

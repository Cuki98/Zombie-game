using AdvancedPeopleSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Collection")]
public class ItemCollectionSO: ScriptableObject
{
    public CharacterElementType ClothingType;
    public List<ItemCollection> itemCollection = new List<ItemCollection>();
}

[System.Serializable]public class ItemCollection
{
    public string Iname;
    public Sprite image;
    public float price;
}

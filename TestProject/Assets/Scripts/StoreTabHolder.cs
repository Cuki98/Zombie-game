using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StoreTabHolder : MonoBehaviour
{
    public Transform tabHolder;
    public Transform itemHolder;
    public GameObject itemRefference;

    private List<Tab> tabs = new List<Tab>();
    private Tab selectedTab;

    private void Awake()
    {
        for (int i = 0; i < tabHolder.childCount; i++)
        {
            if (tabHolder.GetChild(i).GetComponent<Tab>())
                tabs.Add(tabHolder.GetChild(i).GetComponent<Tab>());


        }

        for (int i = 0; i < tabs.Count; i++)
        {
            tabs[i].OnTabSelected += OnTabSelected;
        }
    }

    private void OnTabSelected(Tab arg0)
    {
        if (selectedTab)
        {          

            selectedTab.Deselect();
            if (selectedTab.name == arg0.gameObject.name)
            {
                itemHolder.gameObject.SetActive(false);
                selectedTab = null;
                return;
            }
        }

        selectedTab = arg0;

        if(!itemHolder.gameObject.activeSelf)
        itemHolder.gameObject.SetActive(true);

        if (itemHolder.childCount != 1)
        for (int i = 0; i < itemHolder.childCount; i++)
        {
            Destroy(itemHolder.GetChild(i).gameObject);
        }



        for (int i = 0; i < arg0.itemCollection.itemCollection.Count; i++)
        {
            GameObject refference = Instantiate(itemRefference , Vector2.zero , Quaternion.identity);
            refference.name = arg0.itemCollection.itemCollection[i].Iname;
            refference.transform.GetChild(0).GetComponent<Image>().sprite = arg0.itemCollection.itemCollection[i].image;
            refference.transform.SetParent(itemHolder);

            BuyableClothingItemUi buyableItem = refference.GetComponent<BuyableClothingItemUi>();

            if (buyableItem)
            {
               
                buyableItem.SetUp(arg0.itemCollection.ClothingType, i);
                buyableItem.SetItem(arg0.itemCollection.itemCollection[i]);
            }
            refference.SetActive(true);
        }
    }

}

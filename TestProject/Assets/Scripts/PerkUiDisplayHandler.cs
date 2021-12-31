using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerkUiDisplayHandler : MonoBehaviour
{
    public PerkHandler perkHandler;
    public GameObject holder;
    private GameObject perkTemplate;

    private List<PickUpToUiData> uiToDataList = new List<PickUpToUiData>();


    private void Awake()
    {
        if (!perkHandler)
        {
            perkHandler = GameObject.Find("Player").GetComponent<PerkHandler>();
        }

        if (perkHandler)
        {
            perkHandler.perkTerminated += OnPerkTerminated;
            perkHandler.PerkAdded += OnPerkAdded;
            perkHandler.PerkRenewed += OnPerkReknewed;
        }
        perkTemplate =transform.Find("PerkTemplate").gameObject;
    }
    private PickUpToUiData FindPerk(string name)
    {
       
        for (int i = 0; i < uiToDataList.Count; i++)
        {
            if (uiToDataList[i].data.Name == name)
            {
                return new PickUpToUiData(uiToDataList[i].data , (uiToDataList[i].gameObject));
            }
        }
  
        return null;
    }



    private void OnPerkTerminated(object sender, PerkHandler.PerkHandlerEventArgs e)
    {

        Destroy(FindPerk(e.data.Name).gameObject);
        uiToDataList.RemoveAll(l => l.data.Name == e.data.Name);
        ArrangePerks();
    }

    private void ArrangePerks()
    {
        for (int i = 0; i < uiToDataList.Count; i++)
        {
            if (uiToDataList[i].gameObject)
            uiToDataList[i].gameObject.transform.position = transform.position + new Vector3(i * 150, 0); ;
        }
    }
    private void OnPerkReknewed(object sender, PerkHandler.PerkHandlerEventArgs e)
    {
     
    }

    private void OnPerkAdded(object sender, PerkHandler.PerkHandlerEventArgs e)
    {
        GameObject perk = Instantiate(perkTemplate , transform);
        perk.SetActive(true);
        perk.GetComponent<Image>().sprite = e.data.thumbnail;
        uiToDataList.Add(new PickUpToUiData(e.data, perk));
        ArrangePerks();
    }

    private class PickUpToUiData
    {
        public PickupData data;
        public GameObject gameObject;

        public PickUpToUiData(PickupData data , GameObject gameObject)
        {
            this.data = data;
            this.gameObject = gameObject;
        }

    }
}

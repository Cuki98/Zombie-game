using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Tab : MonoBehaviour
{
    public ItemCollectionSO itemCollection;
    public UnityAction<Tab> OnTabSelected;
    private Image background;
    private bool selected;

    private void Awake()
    {
        background = transform.Find("Background").GetComponent<Image>();
        GetComponent<Button>().onClick.AddListener(()=> { Select();});
    }
    public void Select()
    {
        background.color = Tools.GetColorByHex("#6A6A6A");
        selected = true;
        OnTabSelected?.Invoke(this);
    }
    public void Deselect()
    {
        background.color = Tools.GetColorByHex("#353535");
        selected = false;
    }

    public bool IsSelected()
    {
        return selected;
    }
}

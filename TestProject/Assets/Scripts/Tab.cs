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
        background.color = Tools.GetColorByHex("#5E5E5E");
    }
    public void Select()
    {
        background.color = Tools.GetColorByHex("#00CFFF");
        selected = true;
        OnTabSelected?.Invoke(this);
    }
    public void Deselect()
    {
        background.color = Tools.GetColorByHex("#5E5E5E");
        selected = false;
    }

    public bool IsSelected()
    {
        return selected;
    }
}

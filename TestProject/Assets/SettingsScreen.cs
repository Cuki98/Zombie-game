using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScreen : MonoBehaviour, Iscreen
{

    private Transform holder;
    Vector3 originalPosition;
    void Awake()
    {

        holder = transform.Find("Holder");
        originalPosition = transform.Find("OriginalPosition").position;     
    }

    public bool HasAnimation()
    {
        return true;
    }

    public void OnScreenActivate()
    {
        transform.position = new Vector3(originalPosition.x - 1000, originalPosition.y , originalPosition.z);

        LeanTween.cancel(holder.gameObject);
        LeanTween.moveX(holder.gameObject, originalPosition.x, 0.3f).setEaseLinear();
    }

    public void OnScreenDeactivate()
    {
        LeanTween.cancel(holder.gameObject);
        LeanTween.moveX(holder.gameObject, originalPosition.x - 1000, 0.3f).setEaseLinear();
    }
}

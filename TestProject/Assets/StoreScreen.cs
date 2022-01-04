using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreScreen : MonoBehaviour , Iscreen
{
    Vector3 finalPosition;
    Vector3 originalPosition;

    private Transform holder;

    void Awake()
    {

        holder = transform.Find("Holder");
        originalPosition = transform.Find("OriginalPosition").position;
        finalPosition = transform.Find("FinalPosition").position;
    }
    
    public bool HasAnimation()
    {
        return true;
    }

    public void OnScreenActivate()
    {
        transform.position = originalPosition;

        LeanTween.cancel(holder.gameObject);
        LeanTween.moveX(holder.gameObject, finalPosition.x, 0.3f).setEaseLinear();
    }

    public void OnScreenDeactivate()
    {
        LeanTween.cancel(holder.gameObject);
        LeanTween.moveX(holder.gameObject, originalPosition.x , 0.3f).setEaseLinear();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LobbyButtonAnimations : MonoBehaviour , IPointerEnterHandler , IPointerExitHandler
{
    public float modifier = 0.15f;
    private Button button;
    private Transform buttonContent;
    private Vector3 scaleFactor = Vector3.one;
    private Vector3 originalScale;

    private void Awake()
    {
        scaleFactor *= modifier;
        button = GetComponent<Button>();
        buttonContent = button.transform.GetChild(0);
        originalScale = buttonContent.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        LeanTween.scale(buttonContent.gameObject,  buttonContent.transform.localScale + scaleFactor , 0.1f).setEaseLinear();
        SoundManager.ReproduceGlobalSound(gameObject , GameAssets.i.buttonHoverSfx);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LeanTween.cancel(buttonContent.gameObject);
        LeanTween.scale(buttonContent.gameObject,originalScale, 0.1f).setEaseLinear();
    }

}

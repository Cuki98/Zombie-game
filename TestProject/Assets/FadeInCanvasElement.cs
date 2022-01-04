using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class FadeInCanvasElement : MonoBehaviour
{
    private CanvasGroup canvas;
    public float transitionDuration = 0.3f;

    private void Awake()
    {
        canvas = GetComponent<CanvasGroup>();
    }
    private void OnEnable()
    {
        canvas.alpha = 0;
        float canvasALpha = canvas.alpha;

        LeanTween.cancel(gameObject);
        LeanTween.value(gameObject, canvasALpha, 1, transitionDuration).setOnUpdate((float val) =>
        {
            canvas.alpha = val;

        }).setEaseInOutCirc();
    }

    public void Disable()
    {

        float canvasALpha = canvas.alpha;

        LeanTween.cancel(gameObject);
        LeanTween.value(gameObject, canvasALpha, 0, transitionDuration).setOnUpdate((float val) =>
        {
            canvas.alpha = val;

        }).setEaseOutCirc().setOnComplete(()=> { gameObject.SetActive(false); });
    }


}

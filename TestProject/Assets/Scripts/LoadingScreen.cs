using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingScreen : MonoBehaviour
{
    public Image background;
    public Image icon;
    public TextMeshProUGUI text;


    private void FadeText()
    {
        LeanTween.value(gameObject, text.color.a, 1, 2).setOnUpdate((float val) =>
        {

            Color c = text.color;
            c.a = val;
            text.color = c;
        }).setOnComplete(() =>
        {
            LeanTween.value(gameObject, text.color.a, 0, 2).setOnUpdate((float val) =>
            {

                Color c = text.color;
                c.a = val;
                text.color = c;

            }).setOnComplete(FadeText);
        });
    }

    public void DeactivateLoadingScreen()
    {
        LeanTween.cancel(gameObject);
        LeanTween.value(gameObject, background.color.a, 0, 1f).setOnUpdate((float val) =>
        {

            Color c = background.color;
            c.a = val;
            background.color = c;

        });
        LeanTween.value(gameObject, text.color.a, 0, 0.3f).setOnUpdate((float val) =>
        {

            Color c = text.color;
            c.a = val;
            text.color = c;

        });
        LeanTween.value(gameObject, icon.color.a, 0, 0.3f).setOnUpdate((float val) =>
        {

            Color c = icon.color;
            c.a = val;
            icon.color = c;

        });
    }

    public void ActivateLoadingScreen(float speed)
    {
        LeanTween.cancel(gameObject);

        icon.transform.localScale = Vector3.zero;


        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);


        LeanTween.value(gameObject, background.color.a, 1, speed).setOnUpdate((float val) =>
        {

            Color c = background.color;
            c.a = val;
            background.color = c;

        }).setOnComplete(() =>
        {
            LeanTween.value(gameObject, icon.color.a, 1, 0.1f).setOnUpdate((float val) =>
            {

                Color c = icon.color;
                c.a = val;
                icon.color = c;

            });
            LeanTween.scale(icon.gameObject, new Vector3(1.1965f, 1.1965f, 1.1965f), 1f).setEaseOutCirc().setOnComplete(FadeText);
            LeanTween.value(gameObject, text.color.a, 1, 0.3f).setOnUpdate((float val) =>
            {

                Color c = text.color;
                c.a = val;
                text.color = c;

            });

        });
    }



    bool v = true;
    private void Update()
    {
        icon.transform.Rotate(0, 0, 35 * Time.deltaTime);     
    }
}

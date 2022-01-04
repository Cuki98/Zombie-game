using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuScreen : MonoBehaviour , Iscreen
{
    public GameObject buttons;
    private Button findGame;
    private Button wardrobe;
    private Button settings;
    private Button quit;

    private Vector3 originalScale;
    private void Awake()
    {
        originalScale = transform.localScale;

        settings = buttons.transform.Find("settings").GetComponent<Button>();
        findGame = buttons.transform.Find("findGame").GetComponent<Button>();
        wardrobe = buttons.transform.Find("wardrobe").GetComponent<Button>();
        quit = buttons.transform.Find("quit").GetComponent<Button>();
    }

    private void Start()
    {
        findGame.onClick.AddListener(() =>
        {

        });
        settings.onClick.AddListener(() =>
        {
            MainMenuController.instance.SetScreen("Settings");
        });
        wardrobe.onClick.AddListener(() =>
        {
            MainMenuController.instance.SetScreen("Store");
        });
        quit.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }



    public bool HasAnimation()
    {
        return true;
    }

    public void OnScreenActivate()
    {
        LeanTween.cancel(gameObject);
        LeanTween.scaleY(gameObject, originalScale.y , 0.5f).setEaseOutCirc();
    }

    public void OnScreenDeactivate()
    {
        LeanTween.cancel(gameObject);
        LeanTween.scaleY(gameObject, 1.3f, 0.5f).setEaseInOutCirc() ;
    }



}

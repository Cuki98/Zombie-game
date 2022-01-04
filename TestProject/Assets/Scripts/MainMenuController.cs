using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenuController : MonoBehaviour
{
    public bool AutomaticallySetScreens = true;
    public GameObject buttons;
    public LoadingScreen loadingScreen;
    public List<GameObject> screens = new List<GameObject>();
    private GameObject previousScreen = null;
    private GameObject currentScreen = null;


    public static MainMenuController instance;

    //Buttons

    private Animator anim;



    private Button settings;
    private Button findGame;
    private Button wardrobe;
    private Button quit;



    private void Awake()
    {

        instance = this;

        string user = PlayerPrefs.GetString("USERNAME", "");
        anim = GetComponent<Animator>();

        settings = buttons.transform.Find("settings").GetComponent<Button>();
        findGame = buttons.transform.Find("findGame").GetComponent<Button>();
        wardrobe = buttons.transform.Find("wardrobe").GetComponent<Button>();
        quit = buttons.transform.Find("quit").GetComponent<Button>();


        findGame.onClick.AddListener(() =>
        {

        });
        settings.onClick.AddListener(()=> 
        {

        });
        wardrobe.onClick.AddListener(() =>
        {

        });
        quit.onClick.AddListener(() =>
        {

        });





        loadingScreen.ActivateLoadingScreen(0);
        SetUpScreensAutomatically();
        if (user != "")
        {
           SetScreen("MainMenu");

        }
        else
        {
            SetScreen("CharacterCreationScreen");
        }

        RoomLobbyHandler.OnPlayerSpawn.AddListener(OnPlayerSpawn);
    }

    private void OnPlayerSpawn()
    {
        loadingScreen.DeactivateLoadingScreen();
    }

    public void SetUpScreensAutomatically()
    {
        if (!AutomaticallySetScreens) return;

       GameObject tabHolder = transform.Find("Tabs").gameObject;
        for (int i = 0; i < tabHolder.transform.childCount; i++)
        {
            screens.Add(tabHolder.transform.GetChild(i).gameObject);
        }
    }
    
    public GameObject GetScreenByName(string screenName)
    {

        for (int i = 0; i < screens.Count; i++)
        {
            if (screens[i].name.ToLower() == screenName.ToLower())
            {
                return screens[i];
            }
        }

        Debug.LogError("No Screen with that name was found.");
        return null;
    }

    public void SetScreen(GameObject nextScreen)
    {
        if (!previousScreen)
        {
            //If there are no screens deativate all of the active screens
            for (int i = 0; i < screens.Count; i++)
            {
                screens[i].SetActive(false);
            }
        }

        if (!currentScreen)
        {
            currentScreen = nextScreen;
            currentScreen.SetActive(true);
        }
        else
        {

            previousScreen = currentScreen;
            currentScreen = nextScreen;

            Iscreen pScreen = previousScreen.GetComponent<Iscreen>();
            if (pScreen != null)
            {
                if(pScreen.HasAnimation())
                pScreen.OnScreenDeactivate();
                else
                  previousScreen.SetActive(false);
            }
            else
            {
                previousScreen.SetActive(false);
            }

            currentScreen.SetActive(true);

        }


        Iscreen screen = currentScreen.GetComponent<Iscreen>();
        if (screen != null)
        {
            Debug.Log("Not Null");
            screen.OnScreenActivate();
        }


    }
    public void SetScreen(string currentScreen)
    {
      GameObject screenToSet =  GetScreenByName(currentScreen);

        if (screenToSet != null)
        {
            SetScreen(screenToSet);
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}


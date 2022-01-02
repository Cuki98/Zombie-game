using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{

    public bool AutomaticallySetScreens = true;

    public List<GameObject> screens = new List<GameObject>();
    private GameObject previousScreen = null;
    private GameObject currentScreen = null;




    private Animator anim;


    private void Awake()
    {
        PlayerPrefs.DeleteAll();
        string user = PlayerPrefs.GetString("USERNAME", "");
        anim = GetComponent<Animator>();



        SetUpScreensAutomatically();
        if (user != "")
        {
            SetScreen("MainMenu");

        }
        else
        {
            SetScreen("CharacterCreationScreen");
        }
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
            previousScreen.SetActive(false);
            currentScreen.SetActive(true);

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
}


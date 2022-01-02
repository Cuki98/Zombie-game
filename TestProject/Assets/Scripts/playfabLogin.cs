using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine;

public class playfabLogin : MonoBehaviour
{
    private string username;
    void Start()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            PlayFabSettings.TitleId = "4FCDA";
        }
    }
    public void SetUsername(string name)
    {
        username = name;
        PlayerPrefs.SetString("USERNAME", username);
    }
    public void Login()
    {
        if (!IsValidUsername()) return;

        LoginUsingCustomId();
    }
    private bool IsValidUsername()
    {
        bool isValid = false;
        if (username.Length >= 3 && username.Length <= 24)
            isValid = true;

        return isValid;
    }
    private void LoginUsingCustomId()
    {
        Debug.Log($"Login To Playfab as {username}");
        var request = new LoginWithCustomIDRequest { CustomId = username , CreateAccount = true};
        PlayFabClientAPI.LoginWithCustomID(request , OnLoginCustomIdSuccess , OnFailure);
    }

    private void UpdateDisplayName(string displayName)
    {
        Debug.Log($"Updating Playfab account's display name to:{displayName}");
        var request = new UpdateUserTitleDisplayNameRequest { DisplayName = displayName};
        PlayFabClientAPI.UpdateUserTitleDisplayName(request , OnDisplayNameSuccess , OnFailure);
    }

    private void OnDisplayNameSuccess(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log($"You have updated the display name of the playfab account!");
    }

    private void OnLoginCustomIdSuccess(LoginResult result)
    {
        Debug.Log($"You have logged into playfab using custom id{username}");
        UpdateDisplayName(username);
    }
    private void OnFailure(PlayFabError error)
    {
        Debug.Log($"There was an issue with your request {error.GenerateErrorReport()}");
    }

}

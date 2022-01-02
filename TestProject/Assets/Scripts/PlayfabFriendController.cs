using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
public class PlayfabFriendController : MonoBehaviour
{

    public static Action<List<FriendInfo>> onFriendListUpdated = delegate { };


    private void Awake()
    {
        UiAddFriend.OnAddFriend += HandleAddPlayfabFriend;
    }
    private void OnDestroy()
    {
        UiAddFriend.OnAddFriend -= HandleAddPlayfabFriend;
    }

    private void Start()
    {
        
    }

    private void HandleAddPlayfabFriend(string name)
    {
        var request = new AddFriendRequest { FriendTitleDisplayName = name };
        PlayFabClientAPI.AddFriend(request, OnFriendAddedSuccess, OnFailure);
    }

    private void OnFriendAddedSuccess(AddFriendResult obj)
    {
        GetPlayfabFriends();
    }

    private void GetPlayfabFriends()
    {
        var request = new GetFriendsListRequest { IncludeSteamFriends = false, IncludeFacebookFriends = false, XboxToken = null };
        PlayFabClientAPI.GetFriendsList(request, OnFriendListSuccess, OnFailure);
    }

    private void OnFriendListSuccess(GetFriendsListResult result)
    {
        onFriendListUpdated?.Invoke(result.Friends);
    }

    private void OnFailure(PlayFabError error)
    {
        Debug.Log($"Error occured {error.GenerateErrorReport()}");
    }
}

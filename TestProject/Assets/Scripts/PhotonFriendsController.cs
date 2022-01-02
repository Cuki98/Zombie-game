using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using PlayfabFriendInfo = PlayFab.ClientModels.FriendInfo;
using PhotonFriendInfo = Photon.Realtime.FriendInfo;
using System;
using System.Linq;

public class PhotonFriendsController : MonoBehaviourPunCallbacks
{
    public static Action<List<PhotonFriendInfo>> OnDisplayFriends = delegate { };


    private void Awake()
    {
        PlayfabFriendController.onFriendListUpdated += handlefriendsUpdated;
    }

    private void OnDestroy()
    {
        PlayfabFriendController.onFriendListUpdated -= handlefriendsUpdated;
    }
    private void handlefriendsUpdated(List<PlayfabFriendInfo> friends)
    {
        if (friends.Count != 0)
        {
            string[] friendDisplayNames = friends.Select(f => f.TitleDisplayName).ToArray();
            PhotonNetwork.FindFriends(friendDisplayNames);
        }
    }

    public override void OnFriendListUpdate(List<PhotonFriendInfo> friendList)
    {
        OnDisplayFriends?.Invoke(friendList);
    }
}

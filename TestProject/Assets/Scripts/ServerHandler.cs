using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;
using Photon.Realtime;

public class ServerHandler : MonoBehaviourPunCallbacks
{
    public static Action GetPhotonFriends = delegate { };

    public static Action OnJoinLobby;
    public static Action<Photon.Realtime.Player> OnPlayerJoin;
    public static Action<Photon.Realtime.Player> OnPlayerLeave;
    public static Action OnPersonallyJoinRoom;
    public static Action OnPersonallyLeaveRoom;

    //unity methods
    private void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        string nickname = PlayerPrefs.GetString("USERNAME");
        ConnectToPhoton(nickname);
    }

    //public methods
    private void ConnectToPhoton(string nickName)
    {
        Debug.Log($"Connect to photon as {nickName}");
        PhotonNetwork.AuthValues = new AuthenticationValues(nickName);
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.NickName = nickName;
        PhotonNetwork.ConnectUsingSettings();
    }

    //private methods
    public void CreatePhotonRoom(string roomName)
    {
        if (!PhotonNetwork.IsConnected) return;

        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 4;
        ro.IsVisible = true;
        ro.IsOpen = true;
        PhotonNetwork.JoinOrCreateRoom(roomName, ro ,TypedLobby.Default);
    }

    ///Callbacks

    public override void OnConnectedToMaster()
    {
        Debug.Log("You have connected to master");
        if (!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();
        }
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("You have connected to a photon lobby");
        GetPhotonFriends?.Invoke();
        OnJoinLobby?.Invoke();
        CreatePhotonRoom($"{PhotonNetwork.NickName}'s room");
    }

    public void JoinRandomRoom()
    {

        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom();
        }

        if(PhotonNetwork.IsConnected)
        PhotonNetwork.JoinRandomRoom();


    }

    public override void OnCreatedRoom()
    {
        Debug.Log($"You have created A photon room name {PhotonNetwork.CurrentRoom.Name}");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log($"You have joined A photon room name {PhotonNetwork.CurrentRoom.Name}");
        OnPersonallyJoinRoom?.Invoke();

    }
    public override void OnLeftRoom()
    {
        Debug.Log("you have left a photon room");
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log($"You failed to join a photon room: {message}");
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        Debug.Log($"Another Player Has Joined the room {newPlayer.UserId}");
        OnPlayerJoin?.Invoke(newPlayer);
    }
    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        Debug.Log($"Player has left the room {otherPlayer.UserId}");
    }
    public override void OnMasterClientSwitched(Photon.Realtime.Player newMasterClient)
    {
        Debug.Log($"New master Client is {newMasterClient.UserId}");
    }

}

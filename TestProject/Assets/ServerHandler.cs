using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;
using Photon.Realtime;

public class ServerHandler : MonoBehaviourPunCallbacks
{
    //unity methods
    private void Start()
    {
        string randomName = $"Tester{Guid.NewGuid().ToString()}";
        ConnectToPhoton(randomName);
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
    private void CreatePhotonRoom(string roomName)
    {
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
        CreatePhotonRoom("TestRoom");
    }

    public override void OnCreatedRoom()
    {
        Debug.Log($"You have created A photon room name {PhotonNetwork.CurrentRoom.Name}");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log($"You have joined A photon room name {PhotonNetwork.CurrentRoom.Name}");
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

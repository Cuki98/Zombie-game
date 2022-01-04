using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun ;
using AdvancedPeopleSystem;
using UnityEngine.Events;

public class RoomLobbyHandler : MonoBehaviour
{

    public static UnityEvent OnPlayerSpawn = new UnityEvent();

    public List<Transform> spawnPositions = new List<Transform>();
    private List<Transform> availableSpawnPositions = new List<Transform>();
    PhotonView pv;

    private void Awake()
    {
        availableSpawnPositions = new List<Transform>(spawnPositions);

        pv = GetComponent<PhotonView>();

        ServerHandler.OnPlayerJoin += OnClientJoin;
        ServerHandler.OnPersonallyJoinRoom += OnPersonallyJoinRoom;
        ServerHandler.OnJoinLobby += OnJoinLobby;
       
    }

    private void OnJoinLobby()
    {
    //  Instantiate("LobbyCharacter", spawnPositions[PhotonNetwork.PlayerList.Length - 1].position, spawnPositions[PhotonNetwork.PlayerList.Length - 1].rotation);
    }

    private void Update()
    {

    }



    private void OnPersonallyJoinRoom()
    {
        PhotonNetwork.Instantiate("LobbyCharacter", spawnPositions[PhotonNetwork.PlayerList.Length - 1].position , spawnPositions[PhotonNetwork.PlayerList.Length- 1].rotation);
        OnPlayerSpawn?.Invoke();

    }

    private void OnClientJoin(Photon.Realtime.Player player)
    {
    }
}

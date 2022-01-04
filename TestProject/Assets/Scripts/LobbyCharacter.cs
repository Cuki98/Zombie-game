using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using AdvancedPeopleSystem;

public class LobbyCharacter : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI username;
    private CharacterCustomization character;
    private PhotonView pv;

    private void Awake()
    {
        if (PhotonNetwork.IsConnected)
            pv = GetComponent<PhotonView>();

        character = GetComponent<CharacterCustomization>();

        if (pv == null) return;
        if (pv.IsMine)
        {
            Debug.Log(PhotonNetwork.NickName);
            pv.RPC("SetUsernameText", RpcTarget.AllBuffered, PhotonNetwork.NickName);
        }
    }

    [PunRPC]
    public void SetUsernameText(string Username)
    {
        username.text = Username;

    }


  
}

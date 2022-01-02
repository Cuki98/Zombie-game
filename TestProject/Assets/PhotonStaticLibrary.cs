using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public static class PhotonStaticLibrary 
{
    public static GameObject CreateObject(string prefabName , Vector3 position , Quaternion rotation)
    {
        return PhotonNetwork.Instantiate(prefabName , position , rotation);
    }

    [PunRPC]
    public static void CallFunctionThroughRPC()
    {
    
    }
}

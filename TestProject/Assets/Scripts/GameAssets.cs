using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets i;

    public AudioClip buttonHoverSfx;

    private void Awake()
    {
        i = this;
    }

    
}

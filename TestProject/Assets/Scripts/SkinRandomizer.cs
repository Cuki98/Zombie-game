using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinRandomizer : MonoBehaviour
{
    public Transform skins;
    private void Awake()
    {
        RandomizeSkin();
    }

    public void RandomizeSkin()
    {
        for (int i = 0; i < skins.childCount; i++)
        {
            skins.GetChild(i).gameObject.SetActive(false);
        }

        skins.GetChild(Random.Range(0, skins.childCount)).gameObject.SetActive(true);
    }
}

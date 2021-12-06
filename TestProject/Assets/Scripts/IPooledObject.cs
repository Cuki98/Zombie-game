using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPooledObject 
{
    void OnSpawn();

    IEnumerator Sleep(float time);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class UICharacterRotate : MonoBehaviour
{
    public GameObject character;

    public float mouseRotateCharacterPower = 8f;

    private bool toogle = false;

    void Update()
    {

        if (Input.GetMouseButtonDown(2))
        {
            toogle = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (Input.GetMouseButtonUp(2))
        {
            toogle = false;
            Cursor.lockState = CursorLockMode.None;
        }


        if (toogle)
        {
            character.transform.rotation =
                Quaternion.Euler(character.transform.eulerAngles +
                (Vector3.up * -Input.GetAxis("Mouse X") * mouseRotateCharacterPower)
                );
        }
    }

}

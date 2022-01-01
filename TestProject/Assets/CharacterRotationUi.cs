using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterRotationUi : MonoBehaviour ,IPointerDownHandler, IPointerUpHandler
{
    public GameObject character;
    public float mouseRotateCharacterPower = 8f;
    bool toogle = false;


    public void OnPointerDown(PointerEventData eventData)
    {
        toogle = true;
        Debug.Log("YEEER");
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        toogle = false;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        if (toogle)
        {
            character.transform.rotation =
            Quaternion.Euler(character.transform.eulerAngles +
            (Vector3.up * -Input.GetAxis("Mouse X") * mouseRotateCharacterPower)
            );
        }
    }
}

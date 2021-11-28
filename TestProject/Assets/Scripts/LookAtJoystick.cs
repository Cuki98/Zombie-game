using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookAtJoystick : MonoBehaviour
{
    private Vector2 input;
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        //input = playerInput.actions["Look"].ReadValue<Vector2>();
        if (input == Vector2.zero) return;

        float heading = Mathf.Atan2(input.x, input.y);
        transform.rotation = Quaternion.Euler(0, heading * Mathf.Rad2Deg, 0f);
    }
}

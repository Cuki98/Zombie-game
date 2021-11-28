using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    private TouchControls touchControls;
    private bool touchDown;


    private void Awake()
    {
        touchControls = new TouchControls();
    }

    private void OnEnable()
    {
        touchControls.Enable(); 
    }

    private void OnDisable()
    {
        touchControls.Disable();
    }

    private void Start()
    {
        touchControls.Touch.TouchPress.started += ctx => StartTouch(ctx);
        touchControls.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
    }

    private void EndTouch(InputAction.CallbackContext ctx)
    {
        if(!EventSystem.current.IsPointerOverGameObject())
        touchDown = false;
    }

    private void StartTouch(InputAction.CallbackContext ctx)
    {
        if (!EventSystem.current.IsPointerOverGameObject())
            touchDown = true;
    }

    public bool IsTouchDown()
    {
        return touchDown;
    }
    public Vector3 GetTouchPosition()
    {
   
        return touchControls.Touch.TouchPosition.ReadValue<Vector2>();
    }

}

using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    ///Universal/////////////////
    public InputType inputType = InputType.pc;

    public Vector2 GatherMovementInputs()
    {
        switch (inputType)
        {
            case InputType.touch:
                return GetStickValue();
                break;
            case InputType.pc:
                return GatherAxisInputs();
                break;
            case InputType.controller:
                return Vector2.zero;
                break;
            default:
                return GatherAxisInputs();
                break;
        }
    }

    public Vector2 GatherDirectionalInput()
    {
        switch (inputType)
        {
            case InputType.touch:
                return GetTouchPosition();
                break;
            case InputType.pc:
             return GatherMouseInput();
                break;
            case InputType.controller:
                return Vector2.zero;
                break;
            default:
                return Vector2.zero;
                break;
        }
    }

    //Pc Controlls///////////////////////////////////////////////////////////



    private Vector2 GatherAxisInputs()
    {
        float h = touchControls.PcMove.Horizontal.ReadValue<float>();
        float v = touchControls.PcMove.Vertical.ReadValue<float>();

        return new Vector2(h, v);
    }

    private Vector2 GatherMouseInput()
    {
        return touchControls.PcMove.MousePosition.ReadValue<Vector2>();
    }

    //Touch Controlls//////////////////////////////////////////////////////////
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
        if (!EventSystem.current.IsPointerOverGameObject())
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

    public Vector2 GetStickValue()
    {
        return touchControls.Touch.Move.ReadValue<Vector2>();

    }
}

public enum InputType
{
    touch, pc, controller
}
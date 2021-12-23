// GENERATED AUTOMATICALLY FROM 'Assets/Input/TouchControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @TouchControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @TouchControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TouchControls"",
    ""maps"": [
        {
            ""name"": ""Touch"",
            ""id"": ""ef841196-9ab5-436d-ad0e-34efc11e8147"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""c549d04e-6474-49ce-bdf5-ed8ac795adeb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TapAction"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4fa4bc29-47f9-4c20-a010-13685584c036"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchPress"",
                    ""type"": ""Button"",
                    ""id"": ""f15ed660-62f7-4dac-8865-28f8da35ee47"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1)""
                },
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""cd7c3bdf-d33f-404b-bd81-a0ccde5fba8d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2e9f26cd-4636-4831-bd84-4d5f3701ee1b"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a73841e1-627b-485a-bf7c-4c606d6a8cba"",
                    ""path"": ""<Touchscreen>/primaryTouch"",
                    ""interactions"": ""Press(pressPoint=0.1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TapAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""64f28a87-b93f-4a16-9b84-09a0c6afcbdd"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af95a20d-1797-4276-a1dc-410721e37304"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PcMove"",
            ""id"": ""9722b9ae-0449-4ab2-b2d6-d985385f5e8f"",
            ""actions"": [
                {
                    ""name"": ""Vertical"",
                    ""type"": ""PassThrough"",
                    ""id"": ""85cc79e1-4add-4af2-b993-263850440882"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Horizontal"",
                    ""type"": ""PassThrough"",
                    ""id"": ""19ecfdfa-762e-4a18-90a8-de7281479964"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0bfbfc84-ee28-4e2b-aedc-32d131c31bac"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""6ab50f13-f030-47b8-b571-96cb6096ddb3"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""bfabd120-fd79-40c2-ac0c-eaa35d664705"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""8bcc3cae-126a-43c0-a85b-a87f9611d17e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""468b3e94-c649-4cf2-b257-a00315871cb4"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""02b3476f-770d-4eff-a0ce-974751bca1fc"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""a2036e55-b993-4c3e-86df-199129b184ec"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9d04b435-3705-4cb1-8a45-b3f7e390e75b"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Touch
        m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
        m_Touch_Move = m_Touch.FindAction("Move", throwIfNotFound: true);
        m_Touch_TapAction = m_Touch.FindAction("TapAction", throwIfNotFound: true);
        m_Touch_TouchPress = m_Touch.FindAction("TouchPress", throwIfNotFound: true);
        m_Touch_TouchPosition = m_Touch.FindAction("TouchPosition", throwIfNotFound: true);
        // PcMove
        m_PcMove = asset.FindActionMap("PcMove", throwIfNotFound: true);
        m_PcMove_Vertical = m_PcMove.FindAction("Vertical", throwIfNotFound: true);
        m_PcMove_Horizontal = m_PcMove.FindAction("Horizontal", throwIfNotFound: true);
        m_PcMove_MousePosition = m_PcMove.FindAction("MousePosition", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Touch
    private readonly InputActionMap m_Touch;
    private ITouchActions m_TouchActionsCallbackInterface;
    private readonly InputAction m_Touch_Move;
    private readonly InputAction m_Touch_TapAction;
    private readonly InputAction m_Touch_TouchPress;
    private readonly InputAction m_Touch_TouchPosition;
    public struct TouchActions
    {
        private @TouchControls m_Wrapper;
        public TouchActions(@TouchControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Touch_Move;
        public InputAction @TapAction => m_Wrapper.m_Touch_TapAction;
        public InputAction @TouchPress => m_Wrapper.m_Touch_TouchPress;
        public InputAction @TouchPosition => m_Wrapper.m_Touch_TouchPosition;
        public InputActionMap Get() { return m_Wrapper.m_Touch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchActions set) { return set.Get(); }
        public void SetCallbacks(ITouchActions instance)
        {
            if (m_Wrapper.m_TouchActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnMove;
                @TapAction.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTapAction;
                @TapAction.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTapAction;
                @TapAction.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTapAction;
                @TouchPress.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPress;
                @TouchPress.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPress;
                @TouchPress.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPress;
                @TouchPosition.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPosition;
            }
            m_Wrapper.m_TouchActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @TapAction.started += instance.OnTapAction;
                @TapAction.performed += instance.OnTapAction;
                @TapAction.canceled += instance.OnTapAction;
                @TouchPress.started += instance.OnTouchPress;
                @TouchPress.performed += instance.OnTouchPress;
                @TouchPress.canceled += instance.OnTouchPress;
                @TouchPosition.started += instance.OnTouchPosition;
                @TouchPosition.performed += instance.OnTouchPosition;
                @TouchPosition.canceled += instance.OnTouchPosition;
            }
        }
    }
    public TouchActions @Touch => new TouchActions(this);

    // PcMove
    private readonly InputActionMap m_PcMove;
    private IPcMoveActions m_PcMoveActionsCallbackInterface;
    private readonly InputAction m_PcMove_Vertical;
    private readonly InputAction m_PcMove_Horizontal;
    private readonly InputAction m_PcMove_MousePosition;
    public struct PcMoveActions
    {
        private @TouchControls m_Wrapper;
        public PcMoveActions(@TouchControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Vertical => m_Wrapper.m_PcMove_Vertical;
        public InputAction @Horizontal => m_Wrapper.m_PcMove_Horizontal;
        public InputAction @MousePosition => m_Wrapper.m_PcMove_MousePosition;
        public InputActionMap Get() { return m_Wrapper.m_PcMove; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PcMoveActions set) { return set.Get(); }
        public void SetCallbacks(IPcMoveActions instance)
        {
            if (m_Wrapper.m_PcMoveActionsCallbackInterface != null)
            {
                @Vertical.started -= m_Wrapper.m_PcMoveActionsCallbackInterface.OnVertical;
                @Vertical.performed -= m_Wrapper.m_PcMoveActionsCallbackInterface.OnVertical;
                @Vertical.canceled -= m_Wrapper.m_PcMoveActionsCallbackInterface.OnVertical;
                @Horizontal.started -= m_Wrapper.m_PcMoveActionsCallbackInterface.OnHorizontal;
                @Horizontal.performed -= m_Wrapper.m_PcMoveActionsCallbackInterface.OnHorizontal;
                @Horizontal.canceled -= m_Wrapper.m_PcMoveActionsCallbackInterface.OnHorizontal;
                @MousePosition.started -= m_Wrapper.m_PcMoveActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_PcMoveActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_PcMoveActionsCallbackInterface.OnMousePosition;
            }
            m_Wrapper.m_PcMoveActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Vertical.started += instance.OnVertical;
                @Vertical.performed += instance.OnVertical;
                @Vertical.canceled += instance.OnVertical;
                @Horizontal.started += instance.OnHorizontal;
                @Horizontal.performed += instance.OnHorizontal;
                @Horizontal.canceled += instance.OnHorizontal;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
            }
        }
    }
    public PcMoveActions @PcMove => new PcMoveActions(this);
    public interface ITouchActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnTapAction(InputAction.CallbackContext context);
        void OnTouchPress(InputAction.CallbackContext context);
        void OnTouchPosition(InputAction.CallbackContext context);
    }
    public interface IPcMoveActions
    {
        void OnVertical(InputAction.CallbackContext context);
        void OnHorizontal(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
    }
}

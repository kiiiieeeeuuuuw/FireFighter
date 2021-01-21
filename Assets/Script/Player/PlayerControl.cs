// GENERATED AUTOMATICALLY FROM 'Assets/Script/Player/PlayerControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControl : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControl"",
    ""maps"": [
        {
            ""name"": ""Azerty"",
            ""id"": ""e5e0b0ef-1302-4444-905c-24c4098bfe9c"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6a3c95de-3ea0-40fc-9b0a-8252707d9c32"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ce903bbd-c858-4543-9228-fa046be78a6f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left Dash"",
                    ""type"": ""Button"",
                    ""id"": ""97e941f8-907c-4527-99d3-71dfb73f10d5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right Dash"",
                    ""type"": ""Button"",
                    ""id"": ""a7e3a36a-c785-47ec-92cd-33ec5726756e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""0948f185-71ce-4924-943c-7d862bf780ce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UpAttack"",
                    ""type"": ""Button"",
                    ""id"": ""7d99b3cd-d104-486c-955e-6f3027e27258"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DownAttack"",
                    ""type"": ""Button"",
                    ""id"": ""cdbfbd23-2850-47d2-aa8f-ecdee41f6756"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftMouse"",
                    ""type"": ""Button"",
                    ""id"": ""0c8fd001-2cb9-4861-b6a5-cef7b584517a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightMouse"",
                    ""type"": ""Button"",
                    ""id"": ""e10ddae8-32ad-4188-819a-bed2c3a6735f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Sideways"",
                    ""id"": ""3d32a092-7dc1-46eb-851d-c069d6701019"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""9ab944de-392c-47fd-aa2e-adc5976f4b43"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a49daca9-2965-48c8-aa53-22233a9e4d7c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6992c794-3323-49b6-a925-793bc4e92a75"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Left Dash"",
                    ""id"": ""1c942c89-6593-49a8-b649-857effdbe5a0"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left Dash"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""dff5fc5d-94e4-4441-9e38-50858176bd5c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Left Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""5f1ddebb-74f0-4127-b663-76bb9f313f7d"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Left Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right Dash"",
                    ""id"": ""fcb210e1-9b6f-4472-9930-4b6528025bc3"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right Dash"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""51088e32-e7ab-4a51-a37b-e5deef52459c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Right Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""ed110975-23bf-49e9-98d6-8468856e6836"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Right Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ba90a9c5-e1f7-4133-a6dc-9520f4848825"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""2101732f-56a1-43ba-9e49-04f5dd1b2fac"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpAttack"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""0caea3d5-28da-4c83-9c6f-f6905a32ad2e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""UpAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""050499c2-b3f4-44bf-bc04-d60c9218d9ef"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""UpAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""db2618a9-7164-44c4-a3f3-bf4a85235390"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DownAttack"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""0ae744b0-eefe-489d-981c-b95d75bfba8a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""DownAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""1634fe5e-2b5d-4fe9-89cd-e613e3fca793"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DownAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8aee27e0-1c81-488b-ba26-ee458bd629a7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""LeftMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32a15e5c-ad4f-4617-a022-7777359d5e07"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""RightMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""ButtonSelection"",
            ""id"": ""66ed6325-05d6-4220-89fd-41e3ede44a55"",
            ""actions"": [
                {
                    ""name"": ""MoveUp"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e501bf82-c954-425b-a23d-df21f4508789"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveDown"",
                    ""type"": ""Button"",
                    ""id"": ""a25fd6a3-bc86-49cf-88a9-e3bafec2a758"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PerformAction"",
                    ""type"": ""Button"",
                    ""id"": ""034efcf4-afc4-4203-befa-b78271bfb02a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a993448e-4114-4508-a095-ce3cbebc88af"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bfb26882-5f7d-4353-b353-896cc64749c9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7492d76d-fb77-41a2-a81a-3a782d70cd08"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""PerformAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse & Keyboard"",
            ""bindingGroup"": ""Mouse & Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Azerty
        m_Azerty = asset.FindActionMap("Azerty", throwIfNotFound: true);
        m_Azerty_Move = m_Azerty.FindAction("Move", throwIfNotFound: true);
        m_Azerty_Jump = m_Azerty.FindAction("Jump", throwIfNotFound: true);
        m_Azerty_LeftDash = m_Azerty.FindAction("Left Dash", throwIfNotFound: true);
        m_Azerty_RightDash = m_Azerty.FindAction("Right Dash", throwIfNotFound: true);
        m_Azerty_Attack = m_Azerty.FindAction("Attack", throwIfNotFound: true);
        m_Azerty_UpAttack = m_Azerty.FindAction("UpAttack", throwIfNotFound: true);
        m_Azerty_DownAttack = m_Azerty.FindAction("DownAttack", throwIfNotFound: true);
        m_Azerty_LeftMouse = m_Azerty.FindAction("LeftMouse", throwIfNotFound: true);
        m_Azerty_RightMouse = m_Azerty.FindAction("RightMouse", throwIfNotFound: true);
        // ButtonSelection
        m_ButtonSelection = asset.FindActionMap("ButtonSelection", throwIfNotFound: true);
        m_ButtonSelection_MoveUp = m_ButtonSelection.FindAction("MoveUp", throwIfNotFound: true);
        m_ButtonSelection_MoveDown = m_ButtonSelection.FindAction("MoveDown", throwIfNotFound: true);
        m_ButtonSelection_PerformAction = m_ButtonSelection.FindAction("PerformAction", throwIfNotFound: true);
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

    // Azerty
    private readonly InputActionMap m_Azerty;
    private IAzertyActions m_AzertyActionsCallbackInterface;
    private readonly InputAction m_Azerty_Move;
    private readonly InputAction m_Azerty_Jump;
    private readonly InputAction m_Azerty_LeftDash;
    private readonly InputAction m_Azerty_RightDash;
    private readonly InputAction m_Azerty_Attack;
    private readonly InputAction m_Azerty_UpAttack;
    private readonly InputAction m_Azerty_DownAttack;
    private readonly InputAction m_Azerty_LeftMouse;
    private readonly InputAction m_Azerty_RightMouse;
    public struct AzertyActions
    {
        private @PlayerControl m_Wrapper;
        public AzertyActions(@PlayerControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Azerty_Move;
        public InputAction @Jump => m_Wrapper.m_Azerty_Jump;
        public InputAction @LeftDash => m_Wrapper.m_Azerty_LeftDash;
        public InputAction @RightDash => m_Wrapper.m_Azerty_RightDash;
        public InputAction @Attack => m_Wrapper.m_Azerty_Attack;
        public InputAction @UpAttack => m_Wrapper.m_Azerty_UpAttack;
        public InputAction @DownAttack => m_Wrapper.m_Azerty_DownAttack;
        public InputAction @LeftMouse => m_Wrapper.m_Azerty_LeftMouse;
        public InputAction @RightMouse => m_Wrapper.m_Azerty_RightMouse;
        public InputActionMap Get() { return m_Wrapper.m_Azerty; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AzertyActions set) { return set.Get(); }
        public void SetCallbacks(IAzertyActions instance)
        {
            if (m_Wrapper.m_AzertyActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_AzertyActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_AzertyActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_AzertyActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_AzertyActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_AzertyActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_AzertyActionsCallbackInterface.OnJump;
                @LeftDash.started -= m_Wrapper.m_AzertyActionsCallbackInterface.OnLeftDash;
                @LeftDash.performed -= m_Wrapper.m_AzertyActionsCallbackInterface.OnLeftDash;
                @LeftDash.canceled -= m_Wrapper.m_AzertyActionsCallbackInterface.OnLeftDash;
                @RightDash.started -= m_Wrapper.m_AzertyActionsCallbackInterface.OnRightDash;
                @RightDash.performed -= m_Wrapper.m_AzertyActionsCallbackInterface.OnRightDash;
                @RightDash.canceled -= m_Wrapper.m_AzertyActionsCallbackInterface.OnRightDash;
                @Attack.started -= m_Wrapper.m_AzertyActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_AzertyActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_AzertyActionsCallbackInterface.OnAttack;
                @UpAttack.started -= m_Wrapper.m_AzertyActionsCallbackInterface.OnUpAttack;
                @UpAttack.performed -= m_Wrapper.m_AzertyActionsCallbackInterface.OnUpAttack;
                @UpAttack.canceled -= m_Wrapper.m_AzertyActionsCallbackInterface.OnUpAttack;
                @DownAttack.started -= m_Wrapper.m_AzertyActionsCallbackInterface.OnDownAttack;
                @DownAttack.performed -= m_Wrapper.m_AzertyActionsCallbackInterface.OnDownAttack;
                @DownAttack.canceled -= m_Wrapper.m_AzertyActionsCallbackInterface.OnDownAttack;
                @LeftMouse.started -= m_Wrapper.m_AzertyActionsCallbackInterface.OnLeftMouse;
                @LeftMouse.performed -= m_Wrapper.m_AzertyActionsCallbackInterface.OnLeftMouse;
                @LeftMouse.canceled -= m_Wrapper.m_AzertyActionsCallbackInterface.OnLeftMouse;
                @RightMouse.started -= m_Wrapper.m_AzertyActionsCallbackInterface.OnRightMouse;
                @RightMouse.performed -= m_Wrapper.m_AzertyActionsCallbackInterface.OnRightMouse;
                @RightMouse.canceled -= m_Wrapper.m_AzertyActionsCallbackInterface.OnRightMouse;
            }
            m_Wrapper.m_AzertyActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @LeftDash.started += instance.OnLeftDash;
                @LeftDash.performed += instance.OnLeftDash;
                @LeftDash.canceled += instance.OnLeftDash;
                @RightDash.started += instance.OnRightDash;
                @RightDash.performed += instance.OnRightDash;
                @RightDash.canceled += instance.OnRightDash;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @UpAttack.started += instance.OnUpAttack;
                @UpAttack.performed += instance.OnUpAttack;
                @UpAttack.canceled += instance.OnUpAttack;
                @DownAttack.started += instance.OnDownAttack;
                @DownAttack.performed += instance.OnDownAttack;
                @DownAttack.canceled += instance.OnDownAttack;
                @LeftMouse.started += instance.OnLeftMouse;
                @LeftMouse.performed += instance.OnLeftMouse;
                @LeftMouse.canceled += instance.OnLeftMouse;
                @RightMouse.started += instance.OnRightMouse;
                @RightMouse.performed += instance.OnRightMouse;
                @RightMouse.canceled += instance.OnRightMouse;
            }
        }
    }
    public AzertyActions @Azerty => new AzertyActions(this);

    // ButtonSelection
    private readonly InputActionMap m_ButtonSelection;
    private IButtonSelectionActions m_ButtonSelectionActionsCallbackInterface;
    private readonly InputAction m_ButtonSelection_MoveUp;
    private readonly InputAction m_ButtonSelection_MoveDown;
    private readonly InputAction m_ButtonSelection_PerformAction;
    public struct ButtonSelectionActions
    {
        private @PlayerControl m_Wrapper;
        public ButtonSelectionActions(@PlayerControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveUp => m_Wrapper.m_ButtonSelection_MoveUp;
        public InputAction @MoveDown => m_Wrapper.m_ButtonSelection_MoveDown;
        public InputAction @PerformAction => m_Wrapper.m_ButtonSelection_PerformAction;
        public InputActionMap Get() { return m_Wrapper.m_ButtonSelection; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ButtonSelectionActions set) { return set.Get(); }
        public void SetCallbacks(IButtonSelectionActions instance)
        {
            if (m_Wrapper.m_ButtonSelectionActionsCallbackInterface != null)
            {
                @MoveUp.started -= m_Wrapper.m_ButtonSelectionActionsCallbackInterface.OnMoveUp;
                @MoveUp.performed -= m_Wrapper.m_ButtonSelectionActionsCallbackInterface.OnMoveUp;
                @MoveUp.canceled -= m_Wrapper.m_ButtonSelectionActionsCallbackInterface.OnMoveUp;
                @MoveDown.started -= m_Wrapper.m_ButtonSelectionActionsCallbackInterface.OnMoveDown;
                @MoveDown.performed -= m_Wrapper.m_ButtonSelectionActionsCallbackInterface.OnMoveDown;
                @MoveDown.canceled -= m_Wrapper.m_ButtonSelectionActionsCallbackInterface.OnMoveDown;
                @PerformAction.started -= m_Wrapper.m_ButtonSelectionActionsCallbackInterface.OnPerformAction;
                @PerformAction.performed -= m_Wrapper.m_ButtonSelectionActionsCallbackInterface.OnPerformAction;
                @PerformAction.canceled -= m_Wrapper.m_ButtonSelectionActionsCallbackInterface.OnPerformAction;
            }
            m_Wrapper.m_ButtonSelectionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveUp.started += instance.OnMoveUp;
                @MoveUp.performed += instance.OnMoveUp;
                @MoveUp.canceled += instance.OnMoveUp;
                @MoveDown.started += instance.OnMoveDown;
                @MoveDown.performed += instance.OnMoveDown;
                @MoveDown.canceled += instance.OnMoveDown;
                @PerformAction.started += instance.OnPerformAction;
                @PerformAction.performed += instance.OnPerformAction;
                @PerformAction.canceled += instance.OnPerformAction;
            }
        }
    }
    public ButtonSelectionActions @ButtonSelection => new ButtonSelectionActions(this);
    private int m_MouseKeyboardSchemeIndex = -1;
    public InputControlScheme MouseKeyboardScheme
    {
        get
        {
            if (m_MouseKeyboardSchemeIndex == -1) m_MouseKeyboardSchemeIndex = asset.FindControlSchemeIndex("Mouse & Keyboard");
            return asset.controlSchemes[m_MouseKeyboardSchemeIndex];
        }
    }
    public interface IAzertyActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLeftDash(InputAction.CallbackContext context);
        void OnRightDash(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnUpAttack(InputAction.CallbackContext context);
        void OnDownAttack(InputAction.CallbackContext context);
        void OnLeftMouse(InputAction.CallbackContext context);
        void OnRightMouse(InputAction.CallbackContext context);
    }
    public interface IButtonSelectionActions
    {
        void OnMoveUp(InputAction.CallbackContext context);
        void OnMoveDown(InputAction.CallbackContext context);
        void OnPerformAction(InputAction.CallbackContext context);
    }
}

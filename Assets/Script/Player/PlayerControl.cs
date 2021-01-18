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
                    ""groups"": """",
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
                    ""groups"": """",
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
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Azerty
        m_Azerty = asset.FindActionMap("Azerty", throwIfNotFound: true);
        m_Azerty_Move = m_Azerty.FindAction("Move", throwIfNotFound: true);
        m_Azerty_Jump = m_Azerty.FindAction("Jump", throwIfNotFound: true);
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
    public struct AzertyActions
    {
        private @PlayerControl m_Wrapper;
        public AzertyActions(@PlayerControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Azerty_Move;
        public InputAction @Jump => m_Wrapper.m_Azerty_Jump;
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
            }
        }
    }
    public AzertyActions @Azerty => new AzertyActions(this);
    public interface IAzertyActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}

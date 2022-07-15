// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""Inputs"",
            ""id"": ""9611e288-785b-45dd-9fe6-460e451888de"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""fe77544e-3c3d-44c4-96fb-7b3213330d22"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""caa2637e-0843-49c1-aeb9-207ff685692e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""4d68e9b8-f4be-4f58-a6d9-5658799cc6e9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c375373f-ddde-478d-9484-d8feb54d9048"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3ee87e31-4252-4aa8-b2f9-708630be521a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f87d2810-02ac-430f-abd0-46cf5e2edbb6"",
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
                    ""id"": ""f6382830-cf6a-43f2-ad73-0222a3f01426"",
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
        // Inputs
        m_Inputs = asset.FindActionMap("Inputs", throwIfNotFound: true);
        m_Inputs_Move = m_Inputs.FindAction("Move", throwIfNotFound: true);
        m_Inputs_Jump = m_Inputs.FindAction("Jump", throwIfNotFound: true);
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

    // Inputs
    private readonly InputActionMap m_Inputs;
    private IInputsActions m_InputsActionsCallbackInterface;
    private readonly InputAction m_Inputs_Move;
    private readonly InputAction m_Inputs_Jump;
    public struct InputsActions
    {
        private @PlayerInputs m_Wrapper;
        public InputsActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Inputs_Move;
        public InputAction @Jump => m_Wrapper.m_Inputs_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Inputs; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputsActions set) { return set.Get(); }
        public void SetCallbacks(IInputsActions instance)
        {
            if (m_Wrapper.m_InputsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_InputsActionsCallbackInterface = instance;
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
    public InputsActions @Inputs => new InputsActions(this);
    public interface IInputsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}

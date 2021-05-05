// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/ActionMaps.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ActionMaps : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ActionMaps()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ActionMaps"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""7be2dac2-aa5f-4476-ac70-ec2384b2cdf6"",
            ""actions"": [
                {
                    ""name"": ""Main Thruster"",
                    ""type"": ""Value"",
                    ""id"": ""601fb750-1674-4099-8a8c-aca8b846eb9b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left Thruster"",
                    ""type"": ""Value"",
                    ""id"": ""bbc505f5-1bcd-466e-af75-bb80f8bff54c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right Thruster"",
                    ""type"": ""Value"",
                    ""id"": ""8bf4d5c4-0a3a-4ebb-b6ef-6bbaebbfae2f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left Break"",
                    ""type"": ""Value"",
                    ""id"": ""cccf8b18-3687-4f10-b7bf-801da5bd855d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right Break"",
                    ""type"": ""Value"",
                    ""id"": ""be5168a9-2398-4819-bb99-9fd542468241"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9c8737e0-7433-410d-8d4c-e2ffd2167123"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Main Thruster"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2701562a-be54-40e1-8b4b-a6a1d4efc9a4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left Thruster"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""97c6b057-f6b9-4373-a6a9-54618ee5706b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right Thruster"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc5bd38f-18cc-41b2-99ee-3e2acf487965"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left Break"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6d4942f-5d4f-4e61-9550-d59d98d4db7f"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right Break"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_MainThruster = m_Gameplay.FindAction("Main Thruster", throwIfNotFound: true);
        m_Gameplay_LeftThruster = m_Gameplay.FindAction("Left Thruster", throwIfNotFound: true);
        m_Gameplay_RightThruster = m_Gameplay.FindAction("Right Thruster", throwIfNotFound: true);
        m_Gameplay_LeftBreak = m_Gameplay.FindAction("Left Break", throwIfNotFound: true);
        m_Gameplay_RightBreak = m_Gameplay.FindAction("Right Break", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_MainThruster;
    private readonly InputAction m_Gameplay_LeftThruster;
    private readonly InputAction m_Gameplay_RightThruster;
    private readonly InputAction m_Gameplay_LeftBreak;
    private readonly InputAction m_Gameplay_RightBreak;
    public struct GameplayActions
    {
        private @ActionMaps m_Wrapper;
        public GameplayActions(@ActionMaps wrapper) { m_Wrapper = wrapper; }
        public InputAction @MainThruster => m_Wrapper.m_Gameplay_MainThruster;
        public InputAction @LeftThruster => m_Wrapper.m_Gameplay_LeftThruster;
        public InputAction @RightThruster => m_Wrapper.m_Gameplay_RightThruster;
        public InputAction @LeftBreak => m_Wrapper.m_Gameplay_LeftBreak;
        public InputAction @RightBreak => m_Wrapper.m_Gameplay_RightBreak;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @MainThruster.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMainThruster;
                @MainThruster.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMainThruster;
                @MainThruster.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMainThruster;
                @LeftThruster.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftThruster;
                @LeftThruster.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftThruster;
                @LeftThruster.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftThruster;
                @RightThruster.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightThruster;
                @RightThruster.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightThruster;
                @RightThruster.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightThruster;
                @LeftBreak.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftBreak;
                @LeftBreak.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftBreak;
                @LeftBreak.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftBreak;
                @RightBreak.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightBreak;
                @RightBreak.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightBreak;
                @RightBreak.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightBreak;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MainThruster.started += instance.OnMainThruster;
                @MainThruster.performed += instance.OnMainThruster;
                @MainThruster.canceled += instance.OnMainThruster;
                @LeftThruster.started += instance.OnLeftThruster;
                @LeftThruster.performed += instance.OnLeftThruster;
                @LeftThruster.canceled += instance.OnLeftThruster;
                @RightThruster.started += instance.OnRightThruster;
                @RightThruster.performed += instance.OnRightThruster;
                @RightThruster.canceled += instance.OnRightThruster;
                @LeftBreak.started += instance.OnLeftBreak;
                @LeftBreak.performed += instance.OnLeftBreak;
                @LeftBreak.canceled += instance.OnLeftBreak;
                @RightBreak.started += instance.OnRightBreak;
                @RightBreak.performed += instance.OnRightBreak;
                @RightBreak.canceled += instance.OnRightBreak;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnMainThruster(InputAction.CallbackContext context);
        void OnLeftThruster(InputAction.CallbackContext context);
        void OnRightThruster(InputAction.CallbackContext context);
        void OnLeftBreak(InputAction.CallbackContext context);
        void OnRightBreak(InputAction.CallbackContext context);
    }
}

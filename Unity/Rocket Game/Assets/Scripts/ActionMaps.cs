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
                },
                {
                    ""name"": ""Camera Control"",
                    ""type"": ""Value"",
                    ""id"": ""a94ae61d-3dd3-444c-9cf0-fca691999019"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Zoom In"",
                    ""type"": ""Value"",
                    ""id"": ""026747a8-6df7-49bd-8a26-d1e815e178bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Zoom Out"",
                    ""type"": ""Button"",
                    ""id"": ""253675a4-1dae-4482-8927-156ed99b1304"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Refuel"",
                    ""type"": ""Value"",
                    ""id"": ""e0bb8af8-884c-412b-a8fa-96c4384c5150"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Refuel Main Tank"",
                    ""type"": ""Value"",
                    ""id"": ""615e92a0-986d-4f92-bff8-835842a480b9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Refuel Left Tank"",
                    ""type"": ""Value"",
                    ""id"": ""0a528f87-ce17-4777-908b-0d5d778f6586"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Refuel Right Tank"",
                    ""type"": ""Value"",
                    ""id"": ""a1db71d8-f6b8-4fc5-901a-e1a775957f63"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""d36f1a03-7f8c-4fa6-8e49-5d927464012d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Break"",
                    ""type"": ""Value"",
                    ""id"": ""9a642251-d98a-4055-b935-1a5926192d65"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9c8737e0-7433-410d-8d4c-e2ffd2167123"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Main Thruster"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f8358b7-152f-4095-9451-d3dae1951f71"",
                    ""path"": ""<Keyboard>/upArrow"",
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
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left Thruster"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cfd67787-c131-4562-8967-24dba8a23020"",
                    ""path"": ""<Keyboard>/rightArrow"",
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
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right Thruster"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d544f70-ee15-47e3-9dca-9c63cb0cc3b1"",
                    ""path"": ""<Keyboard>/leftArrow"",
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
                    ""id"": ""8e2ba83e-9479-45f9-bd88-e4d2356e1902"",
                    ""path"": ""<Keyboard>/x"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""8ed5ff57-7cc9-4de1-a265-283c04f3b357"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right Break"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b3151cc6-aabd-46d5-ad84-8e79d0e3f23c"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera Control"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8cd7f93b-f7b9-40e7-8d2e-a50de445a1bb"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom In"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1bd6c86a-1d1d-4e43-9b4a-5b7d56f81d03"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom Out"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5862f56-e9fb-4d2f-a843-07c488b304f9"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Refuel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e286285d-5e88-4e51-aa92-be8e7392c601"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Refuel Main Tank"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5e624a3-9034-4000-b0d5-5ccab07a5611"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Refuel Left Tank"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f54c40ac-241a-469e-bd9a-defc099d5eb8"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Refuel Right Tank"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45dcd133-fe80-41de-aa03-59e041b1e3e6"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""751bb5cd-83f5-4574-aea4-4a4d7fd335a9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Break"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b4384a6-41f5-44fa-91e3-7033ba46cf17"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Break"",
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
        m_Gameplay_CameraControl = m_Gameplay.FindAction("Camera Control", throwIfNotFound: true);
        m_Gameplay_ZoomIn = m_Gameplay.FindAction("Zoom In", throwIfNotFound: true);
        m_Gameplay_ZoomOut = m_Gameplay.FindAction("Zoom Out", throwIfNotFound: true);
        m_Gameplay_Refuel = m_Gameplay.FindAction("Refuel", throwIfNotFound: true);
        m_Gameplay_RefuelMainTank = m_Gameplay.FindAction("Refuel Main Tank", throwIfNotFound: true);
        m_Gameplay_RefuelLeftTank = m_Gameplay.FindAction("Refuel Left Tank", throwIfNotFound: true);
        m_Gameplay_RefuelRightTank = m_Gameplay.FindAction("Refuel Right Tank", throwIfNotFound: true);
        m_Gameplay_Pause = m_Gameplay.FindAction("Pause", throwIfNotFound: true);
        m_Gameplay_Break = m_Gameplay.FindAction("Break", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_CameraControl;
    private readonly InputAction m_Gameplay_ZoomIn;
    private readonly InputAction m_Gameplay_ZoomOut;
    private readonly InputAction m_Gameplay_Refuel;
    private readonly InputAction m_Gameplay_RefuelMainTank;
    private readonly InputAction m_Gameplay_RefuelLeftTank;
    private readonly InputAction m_Gameplay_RefuelRightTank;
    private readonly InputAction m_Gameplay_Pause;
    private readonly InputAction m_Gameplay_Break;
    public struct GameplayActions
    {
        private @ActionMaps m_Wrapper;
        public GameplayActions(@ActionMaps wrapper) { m_Wrapper = wrapper; }
        public InputAction @MainThruster => m_Wrapper.m_Gameplay_MainThruster;
        public InputAction @LeftThruster => m_Wrapper.m_Gameplay_LeftThruster;
        public InputAction @RightThruster => m_Wrapper.m_Gameplay_RightThruster;
        public InputAction @LeftBreak => m_Wrapper.m_Gameplay_LeftBreak;
        public InputAction @RightBreak => m_Wrapper.m_Gameplay_RightBreak;
        public InputAction @CameraControl => m_Wrapper.m_Gameplay_CameraControl;
        public InputAction @ZoomIn => m_Wrapper.m_Gameplay_ZoomIn;
        public InputAction @ZoomOut => m_Wrapper.m_Gameplay_ZoomOut;
        public InputAction @Refuel => m_Wrapper.m_Gameplay_Refuel;
        public InputAction @RefuelMainTank => m_Wrapper.m_Gameplay_RefuelMainTank;
        public InputAction @RefuelLeftTank => m_Wrapper.m_Gameplay_RefuelLeftTank;
        public InputAction @RefuelRightTank => m_Wrapper.m_Gameplay_RefuelRightTank;
        public InputAction @Pause => m_Wrapper.m_Gameplay_Pause;
        public InputAction @Break => m_Wrapper.m_Gameplay_Break;
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
                @CameraControl.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCameraControl;
                @CameraControl.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCameraControl;
                @CameraControl.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCameraControl;
                @ZoomIn.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnZoomIn;
                @ZoomIn.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnZoomIn;
                @ZoomIn.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnZoomIn;
                @ZoomOut.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnZoomOut;
                @ZoomOut.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnZoomOut;
                @ZoomOut.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnZoomOut;
                @Refuel.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRefuel;
                @Refuel.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRefuel;
                @Refuel.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRefuel;
                @RefuelMainTank.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRefuelMainTank;
                @RefuelMainTank.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRefuelMainTank;
                @RefuelMainTank.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRefuelMainTank;
                @RefuelLeftTank.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRefuelLeftTank;
                @RefuelLeftTank.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRefuelLeftTank;
                @RefuelLeftTank.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRefuelLeftTank;
                @RefuelRightTank.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRefuelRightTank;
                @RefuelRightTank.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRefuelRightTank;
                @RefuelRightTank.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRefuelRightTank;
                @Pause.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Break.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBreak;
                @Break.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBreak;
                @Break.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBreak;
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
                @CameraControl.started += instance.OnCameraControl;
                @CameraControl.performed += instance.OnCameraControl;
                @CameraControl.canceled += instance.OnCameraControl;
                @ZoomIn.started += instance.OnZoomIn;
                @ZoomIn.performed += instance.OnZoomIn;
                @ZoomIn.canceled += instance.OnZoomIn;
                @ZoomOut.started += instance.OnZoomOut;
                @ZoomOut.performed += instance.OnZoomOut;
                @ZoomOut.canceled += instance.OnZoomOut;
                @Refuel.started += instance.OnRefuel;
                @Refuel.performed += instance.OnRefuel;
                @Refuel.canceled += instance.OnRefuel;
                @RefuelMainTank.started += instance.OnRefuelMainTank;
                @RefuelMainTank.performed += instance.OnRefuelMainTank;
                @RefuelMainTank.canceled += instance.OnRefuelMainTank;
                @RefuelLeftTank.started += instance.OnRefuelLeftTank;
                @RefuelLeftTank.performed += instance.OnRefuelLeftTank;
                @RefuelLeftTank.canceled += instance.OnRefuelLeftTank;
                @RefuelRightTank.started += instance.OnRefuelRightTank;
                @RefuelRightTank.performed += instance.OnRefuelRightTank;
                @RefuelRightTank.canceled += instance.OnRefuelRightTank;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Break.started += instance.OnBreak;
                @Break.performed += instance.OnBreak;
                @Break.canceled += instance.OnBreak;
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
        void OnCameraControl(InputAction.CallbackContext context);
        void OnZoomIn(InputAction.CallbackContext context);
        void OnZoomOut(InputAction.CallbackContext context);
        void OnRefuel(InputAction.CallbackContext context);
        void OnRefuelMainTank(InputAction.CallbackContext context);
        void OnRefuelLeftTank(InputAction.CallbackContext context);
        void OnRefuelRightTank(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnBreak(InputAction.CallbackContext context);
    }
}

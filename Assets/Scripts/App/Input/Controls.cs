// GENERATED AUTOMATICALLY FROM 'Assets/Input/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Global"",
            ""id"": ""d5aca702-3528-4764-ac9d-90335ccec718"",
            ""actions"": [
                {
                    ""name"": ""RestartLevel"",
                    ""type"": ""Button"",
                    ""id"": ""d46d0552-3b7c-4047-b53c-45d066f529d9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleAudioSettings"",
                    ""type"": ""Button"",
                    ""id"": ""3ffc4888-3c53-4a18-b90e-cb64aaf1a4f4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0dbb8bce-15ef-4e81-9889-631becf8bab1"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RestartLevel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4cef7301-6db0-4111-93aa-959dfa45147c"",
                    ""path"": ""<Keyboard>/semicolon"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleAudioSettings"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Robot"",
            ""id"": ""60a023a9-97c2-447c-a173-46bebd1e7610"",
            ""actions"": [
                {
                    ""name"": ""HorizontalMovement"",
                    ""type"": ""Value"",
                    ""id"": ""5cdb8a32-761e-470e-8cec-0f731046f37a"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Throw"",
                    ""type"": ""Button"",
                    ""id"": ""b01d2752-151b-4966-8899-757953b30a5c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveWrench"",
                    ""type"": ""Value"",
                    ""id"": ""d43106d8-6115-46d5-8a6b-ec1c7aa9312a"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""QS"",
                    ""id"": ""ddeea9bc-a1b1-44d2-8f4b-099ccce9ba62"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""4eb8c799-c039-478d-94b8-4edd5ed383d5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""022100c7-de15-4cc3-851f-3188239ce733"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e0981fd7-07d2-44d3-b0b6-df7356ab9d70"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""86ce0846-e5ae-4818-8028-759ea5d27617"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveWrench"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""ea680218-e888-4673-ad3b-8a5ce517abc9"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveWrench"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""841658d8-12eb-49ba-b198-45c77893986c"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveWrench"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Global
        m_Global = asset.FindActionMap("Global", throwIfNotFound: true);
        m_Global_RestartLevel = m_Global.FindAction("RestartLevel", throwIfNotFound: true);
        m_Global_ToggleAudioSettings = m_Global.FindAction("ToggleAudioSettings", throwIfNotFound: true);
        // Robot
        m_Robot = asset.FindActionMap("Robot", throwIfNotFound: true);
        m_Robot_HorizontalMovement = m_Robot.FindAction("HorizontalMovement", throwIfNotFound: true);
        m_Robot_Throw = m_Robot.FindAction("Throw", throwIfNotFound: true);
        m_Robot_MoveWrench = m_Robot.FindAction("MoveWrench", throwIfNotFound: true);
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

    // Global
    private readonly InputActionMap m_Global;
    private IGlobalActions m_GlobalActionsCallbackInterface;
    private readonly InputAction m_Global_RestartLevel;
    private readonly InputAction m_Global_ToggleAudioSettings;
    public struct GlobalActions
    {
        private @Controls m_Wrapper;
        public GlobalActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @RestartLevel => m_Wrapper.m_Global_RestartLevel;
        public InputAction @ToggleAudioSettings => m_Wrapper.m_Global_ToggleAudioSettings;
        public InputActionMap Get() { return m_Wrapper.m_Global; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GlobalActions set) { return set.Get(); }
        public void SetCallbacks(IGlobalActions instance)
        {
            if (m_Wrapper.m_GlobalActionsCallbackInterface != null)
            {
                @RestartLevel.started -= m_Wrapper.m_GlobalActionsCallbackInterface.OnRestartLevel;
                @RestartLevel.performed -= m_Wrapper.m_GlobalActionsCallbackInterface.OnRestartLevel;
                @RestartLevel.canceled -= m_Wrapper.m_GlobalActionsCallbackInterface.OnRestartLevel;
                @ToggleAudioSettings.started -= m_Wrapper.m_GlobalActionsCallbackInterface.OnToggleAudioSettings;
                @ToggleAudioSettings.performed -= m_Wrapper.m_GlobalActionsCallbackInterface.OnToggleAudioSettings;
                @ToggleAudioSettings.canceled -= m_Wrapper.m_GlobalActionsCallbackInterface.OnToggleAudioSettings;
            }
            m_Wrapper.m_GlobalActionsCallbackInterface = instance;
            if (instance != null)
            {
                @RestartLevel.started += instance.OnRestartLevel;
                @RestartLevel.performed += instance.OnRestartLevel;
                @RestartLevel.canceled += instance.OnRestartLevel;
                @ToggleAudioSettings.started += instance.OnToggleAudioSettings;
                @ToggleAudioSettings.performed += instance.OnToggleAudioSettings;
                @ToggleAudioSettings.canceled += instance.OnToggleAudioSettings;
            }
        }
    }
    public GlobalActions @Global => new GlobalActions(this);

    // Robot
    private readonly InputActionMap m_Robot;
    private IRobotActions m_RobotActionsCallbackInterface;
    private readonly InputAction m_Robot_HorizontalMovement;
    private readonly InputAction m_Robot_Throw;
    private readonly InputAction m_Robot_MoveWrench;
    public struct RobotActions
    {
        private @Controls m_Wrapper;
        public RobotActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @HorizontalMovement => m_Wrapper.m_Robot_HorizontalMovement;
        public InputAction @Throw => m_Wrapper.m_Robot_Throw;
        public InputAction @MoveWrench => m_Wrapper.m_Robot_MoveWrench;
        public InputActionMap Get() { return m_Wrapper.m_Robot; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RobotActions set) { return set.Get(); }
        public void SetCallbacks(IRobotActions instance)
        {
            if (m_Wrapper.m_RobotActionsCallbackInterface != null)
            {
                @HorizontalMovement.started -= m_Wrapper.m_RobotActionsCallbackInterface.OnHorizontalMovement;
                @HorizontalMovement.performed -= m_Wrapper.m_RobotActionsCallbackInterface.OnHorizontalMovement;
                @HorizontalMovement.canceled -= m_Wrapper.m_RobotActionsCallbackInterface.OnHorizontalMovement;
                @Throw.started -= m_Wrapper.m_RobotActionsCallbackInterface.OnThrow;
                @Throw.performed -= m_Wrapper.m_RobotActionsCallbackInterface.OnThrow;
                @Throw.canceled -= m_Wrapper.m_RobotActionsCallbackInterface.OnThrow;
                @MoveWrench.started -= m_Wrapper.m_RobotActionsCallbackInterface.OnMoveWrench;
                @MoveWrench.performed -= m_Wrapper.m_RobotActionsCallbackInterface.OnMoveWrench;
                @MoveWrench.canceled -= m_Wrapper.m_RobotActionsCallbackInterface.OnMoveWrench;
            }
            m_Wrapper.m_RobotActionsCallbackInterface = instance;
            if (instance != null)
            {
                @HorizontalMovement.started += instance.OnHorizontalMovement;
                @HorizontalMovement.performed += instance.OnHorizontalMovement;
                @HorizontalMovement.canceled += instance.OnHorizontalMovement;
                @Throw.started += instance.OnThrow;
                @Throw.performed += instance.OnThrow;
                @Throw.canceled += instance.OnThrow;
                @MoveWrench.started += instance.OnMoveWrench;
                @MoveWrench.performed += instance.OnMoveWrench;
                @MoveWrench.canceled += instance.OnMoveWrench;
            }
        }
    }
    public RobotActions @Robot => new RobotActions(this);
    public interface IGlobalActions
    {
        void OnRestartLevel(InputAction.CallbackContext context);
        void OnToggleAudioSettings(InputAction.CallbackContext context);
    }
    public interface IRobotActions
    {
        void OnHorizontalMovement(InputAction.CallbackContext context);
        void OnThrow(InputAction.CallbackContext context);
        void OnMoveWrench(InputAction.CallbackContext context);
    }
}

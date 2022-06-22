//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Input/PlayerInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""5fec1c5a-19b4-4f55-b6e0-a88d57eb1af8"",
            ""actions"": [
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""05469bd6-b708-4c6b-8a9a-fcde7a60f444"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""351b5c09-0d41-4879-8d09-4e35a24c903d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""2cc732ba-0724-42ae-bfb8-dda690251e30"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""08d968c4-1af3-48ff-be3e-72e60390de3a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d395ebda-9235-46fc-9852-90a651d97d5a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""66b7d416-aa8e-4022-885a-376a6ae05220"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2eecdcff-3bc2-4d47-b635-3a87d20fcc4e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""41b38c68-6a70-4d7c-990d-3c7201799bf3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""b11f696e-9dd7-4823-83b6-abea63f0e54e"",
            ""actions"": [
                {
                    ""name"": ""SelectTile1"",
                    ""type"": ""Button"",
                    ""id"": ""ac1c0d0c-0295-44fc-8579-9aae419ca837"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectTile2"",
                    ""type"": ""Button"",
                    ""id"": ""724f17c7-9eb1-4f4b-82fe-0a2d8802fe9b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectTile3"",
                    ""type"": ""Button"",
                    ""id"": ""37c0b47d-d36a-4690-8ebb-5869b14cf88d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectTile4"",
                    ""type"": ""Button"",
                    ""id"": ""75ad46ae-6222-4778-8465-65c114868251"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectTile5"",
                    ""type"": ""Button"",
                    ""id"": ""5000a53e-2df9-4581-bf22-ed4131bfcdb4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4fbb3260-be19-41e1-b5e8-1f8ce021efa5"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectTile1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""98d01014-0ff8-44c1-af9d-d745fe75f361"",
                    ""path"": ""<Keyboard>/numpad1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectTile1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4d91058-3bbc-40a0-a5bd-e9e130feab14"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectTile2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1aa930c5-876e-494f-95b4-5808becb92bd"",
                    ""path"": ""<Keyboard>/numpad2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectTile2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""474c0c79-e3de-4912-8e4c-06a6462d8f60"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectTile3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5d194a9-2933-45a6-b362-1a8d8c7fe34f"",
                    ""path"": ""<Keyboard>/numpad3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectTile3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b927f4f4-8f27-4db9-afe3-e2bf769b21c8"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectTile4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba47844e-9b9e-4e7c-a92d-b4e0f9ab163f"",
                    ""path"": ""<Keyboard>/numpad4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectTile4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1986b6f7-d82e-498e-8d48-822f5bb365de"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectTile5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8fc0c284-c69e-4843-bcca-c335ba82e49c"",
                    ""path"": ""<Keyboard>/numpad5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectTile5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Debug"",
            ""id"": ""333ce204-206c-4df4-955b-6ec3207ab9a3"",
            ""actions"": [
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""636e6fb2-dba6-4fff-ab89-f66b7dc06eca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Copy"",
                    ""type"": ""Button"",
                    ""id"": ""7245fa7c-2672-4c3f-8f0f-0fdf6ff23468"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Load"",
                    ""type"": ""Button"",
                    ""id"": ""88b46b26-d836-451a-8962-3d7833f731ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""69b1e8fa-ee5f-43a3-846a-95c26a05ac7b"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cca48e2c-0e62-4fcc-90ab-23244f08287c"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Copy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d008ec59-94dc-4679-b72a-35698adfb137"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Load"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Up = m_Player.FindAction("Up", throwIfNotFound: true);
        m_Player_Down = m_Player.FindAction("Down", throwIfNotFound: true);
        m_Player_Left = m_Player.FindAction("Left", throwIfNotFound: true);
        m_Player_Right = m_Player.FindAction("Right", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_SelectTile1 = m_Menu.FindAction("SelectTile1", throwIfNotFound: true);
        m_Menu_SelectTile2 = m_Menu.FindAction("SelectTile2", throwIfNotFound: true);
        m_Menu_SelectTile3 = m_Menu.FindAction("SelectTile3", throwIfNotFound: true);
        m_Menu_SelectTile4 = m_Menu.FindAction("SelectTile4", throwIfNotFound: true);
        m_Menu_SelectTile5 = m_Menu.FindAction("SelectTile5", throwIfNotFound: true);
        // Debug
        m_Debug = asset.FindActionMap("Debug", throwIfNotFound: true);
        m_Debug_Restart = m_Debug.FindAction("Restart", throwIfNotFound: true);
        m_Debug_Copy = m_Debug.FindAction("Copy", throwIfNotFound: true);
        m_Debug_Load = m_Debug.FindAction("Load", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Up;
    private readonly InputAction m_Player_Down;
    private readonly InputAction m_Player_Left;
    private readonly InputAction m_Player_Right;
    public struct PlayerActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Up => m_Wrapper.m_Player_Up;
        public InputAction @Down => m_Wrapper.m_Player_Down;
        public InputAction @Left => m_Wrapper.m_Player_Left;
        public InputAction @Right => m_Wrapper.m_Player_Right;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Up.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDown;
                @Left.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRight;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_SelectTile1;
    private readonly InputAction m_Menu_SelectTile2;
    private readonly InputAction m_Menu_SelectTile3;
    private readonly InputAction m_Menu_SelectTile4;
    private readonly InputAction m_Menu_SelectTile5;
    public struct MenuActions
    {
        private @PlayerInput m_Wrapper;
        public MenuActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @SelectTile1 => m_Wrapper.m_Menu_SelectTile1;
        public InputAction @SelectTile2 => m_Wrapper.m_Menu_SelectTile2;
        public InputAction @SelectTile3 => m_Wrapper.m_Menu_SelectTile3;
        public InputAction @SelectTile4 => m_Wrapper.m_Menu_SelectTile4;
        public InputAction @SelectTile5 => m_Wrapper.m_Menu_SelectTile5;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @SelectTile1.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnSelectTile1;
                @SelectTile1.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnSelectTile1;
                @SelectTile1.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnSelectTile1;
                @SelectTile2.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnSelectTile2;
                @SelectTile2.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnSelectTile2;
                @SelectTile2.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnSelectTile2;
                @SelectTile3.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnSelectTile3;
                @SelectTile3.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnSelectTile3;
                @SelectTile3.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnSelectTile3;
                @SelectTile4.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnSelectTile4;
                @SelectTile4.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnSelectTile4;
                @SelectTile4.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnSelectTile4;
                @SelectTile5.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnSelectTile5;
                @SelectTile5.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnSelectTile5;
                @SelectTile5.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnSelectTile5;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SelectTile1.started += instance.OnSelectTile1;
                @SelectTile1.performed += instance.OnSelectTile1;
                @SelectTile1.canceled += instance.OnSelectTile1;
                @SelectTile2.started += instance.OnSelectTile2;
                @SelectTile2.performed += instance.OnSelectTile2;
                @SelectTile2.canceled += instance.OnSelectTile2;
                @SelectTile3.started += instance.OnSelectTile3;
                @SelectTile3.performed += instance.OnSelectTile3;
                @SelectTile3.canceled += instance.OnSelectTile3;
                @SelectTile4.started += instance.OnSelectTile4;
                @SelectTile4.performed += instance.OnSelectTile4;
                @SelectTile4.canceled += instance.OnSelectTile4;
                @SelectTile5.started += instance.OnSelectTile5;
                @SelectTile5.performed += instance.OnSelectTile5;
                @SelectTile5.canceled += instance.OnSelectTile5;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);

    // Debug
    private readonly InputActionMap m_Debug;
    private IDebugActions m_DebugActionsCallbackInterface;
    private readonly InputAction m_Debug_Restart;
    private readonly InputAction m_Debug_Copy;
    private readonly InputAction m_Debug_Load;
    public struct DebugActions
    {
        private @PlayerInput m_Wrapper;
        public DebugActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Restart => m_Wrapper.m_Debug_Restart;
        public InputAction @Copy => m_Wrapper.m_Debug_Copy;
        public InputAction @Load => m_Wrapper.m_Debug_Load;
        public InputActionMap Get() { return m_Wrapper.m_Debug; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DebugActions set) { return set.Get(); }
        public void SetCallbacks(IDebugActions instance)
        {
            if (m_Wrapper.m_DebugActionsCallbackInterface != null)
            {
                @Restart.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnRestart;
                @Restart.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnRestart;
                @Restart.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnRestart;
                @Copy.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnCopy;
                @Copy.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnCopy;
                @Copy.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnCopy;
                @Load.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnLoad;
                @Load.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnLoad;
                @Load.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnLoad;
            }
            m_Wrapper.m_DebugActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Restart.started += instance.OnRestart;
                @Restart.performed += instance.OnRestart;
                @Restart.canceled += instance.OnRestart;
                @Copy.started += instance.OnCopy;
                @Copy.performed += instance.OnCopy;
                @Copy.canceled += instance.OnCopy;
                @Load.started += instance.OnLoad;
                @Load.performed += instance.OnLoad;
                @Load.canceled += instance.OnLoad;
            }
        }
    }
    public DebugActions @Debug => new DebugActions(this);
    public interface IPlayerActions
    {
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnSelectTile1(InputAction.CallbackContext context);
        void OnSelectTile2(InputAction.CallbackContext context);
        void OnSelectTile3(InputAction.CallbackContext context);
        void OnSelectTile4(InputAction.CallbackContext context);
        void OnSelectTile5(InputAction.CallbackContext context);
    }
    public interface IDebugActions
    {
        void OnRestart(InputAction.CallbackContext context);
        void OnCopy(InputAction.CallbackContext context);
        void OnLoad(InputAction.CallbackContext context);
    }
}

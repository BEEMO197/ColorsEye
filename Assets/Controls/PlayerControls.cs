// GENERATED AUTOMATICALLY FROM 'Assets/Controls/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""CharacterControls"",
            ""id"": ""f2631f1e-b8ae-43ef-b26c-e8ed1bb7fa20"",
            ""actions"": [
                {
                    ""name"": ""CameraControls"",
                    ""type"": ""PassThrough"",
                    ""id"": ""35faf981-4b6c-48f8-afa5-004fc4e546bf"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CharacterControls"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d9ecb0a3-fd2b-467e-a27b-43e1b06e6da8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""7171a91e-0e6b-4d92-bd3f-b4bf94184f53"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ColorControls"",
                    ""type"": ""PassThrough"",
                    ""id"": ""052988be-49fd-4a4c-8489-da16385afa6e"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Respawn"",
                    ""type"": ""Button"",
                    ""id"": ""ba379683-dccb-4b65-8588-357739f4a51c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""9b847ac1-7b2b-441b-858f-adbf9e5df0fc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8a0c4602-b085-48f3-a3fd-0e0307caf5d2"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraControls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""00ff64ab-7d04-4863-9e98-f06a427d85c9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CharacterControls"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""812164fa-019e-4935-ba3f-fd3c818d38d8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CharacterControls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f978caf5-76a6-4ad4-b69c-f40abcab3129"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CharacterControls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""10183d13-b2ec-46d2-bc3c-a180c41b2d1d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CharacterControls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ac1ea91e-53e0-4d59-90f4-2d14d5340ae3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CharacterControls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b04e5cca-adbd-4be3-afe8-95188fd1f0cd"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f73c266b-0e8d-40c0-8fd8-8be975fcef9b"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ColorControls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d93ff66a-12d3-4553-9178-4111f57c9694"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Respawn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f45c96d4-4459-45e9-b3d4-6834ad7eaa0b"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c0a395b4-2f19-4fcc-8c1b-9feb25611624"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CharacterControls
        m_CharacterControls = asset.FindActionMap("CharacterControls", throwIfNotFound: true);
        m_CharacterControls_CameraControls = m_CharacterControls.FindAction("CameraControls", throwIfNotFound: true);
        m_CharacterControls_CharacterControls = m_CharacterControls.FindAction("CharacterControls", throwIfNotFound: true);
        m_CharacterControls_Jump = m_CharacterControls.FindAction("Jump", throwIfNotFound: true);
        m_CharacterControls_ColorControls = m_CharacterControls.FindAction("ColorControls", throwIfNotFound: true);
        m_CharacterControls_Respawn = m_CharacterControls.FindAction("Respawn", throwIfNotFound: true);
        m_CharacterControls_Pause = m_CharacterControls.FindAction("Pause", throwIfNotFound: true);
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

    // CharacterControls
    private readonly InputActionMap m_CharacterControls;
    private ICharacterControlsActions m_CharacterControlsActionsCallbackInterface;
    private readonly InputAction m_CharacterControls_CameraControls;
    private readonly InputAction m_CharacterControls_CharacterControls;
    private readonly InputAction m_CharacterControls_Jump;
    private readonly InputAction m_CharacterControls_ColorControls;
    private readonly InputAction m_CharacterControls_Respawn;
    private readonly InputAction m_CharacterControls_Pause;
    public struct CharacterControlsActions
    {
        private @PlayerControls m_Wrapper;
        public CharacterControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @CameraControls => m_Wrapper.m_CharacterControls_CameraControls;
        public InputAction @CharacterControls => m_Wrapper.m_CharacterControls_CharacterControls;
        public InputAction @Jump => m_Wrapper.m_CharacterControls_Jump;
        public InputAction @ColorControls => m_Wrapper.m_CharacterControls_ColorControls;
        public InputAction @Respawn => m_Wrapper.m_CharacterControls_Respawn;
        public InputAction @Pause => m_Wrapper.m_CharacterControls_Pause;
        public InputActionMap Get() { return m_Wrapper.m_CharacterControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterControlsActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterControlsActions instance)
        {
            if (m_Wrapper.m_CharacterControlsActionsCallbackInterface != null)
            {
                @CameraControls.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnCameraControls;
                @CameraControls.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnCameraControls;
                @CameraControls.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnCameraControls;
                @CharacterControls.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnCharacterControls;
                @CharacterControls.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnCharacterControls;
                @CharacterControls.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnCharacterControls;
                @Jump.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnJump;
                @ColorControls.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnColorControls;
                @ColorControls.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnColorControls;
                @ColorControls.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnColorControls;
                @Respawn.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnRespawn;
                @Respawn.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnRespawn;
                @Respawn.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnRespawn;
                @Pause.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_CharacterControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @CameraControls.started += instance.OnCameraControls;
                @CameraControls.performed += instance.OnCameraControls;
                @CameraControls.canceled += instance.OnCameraControls;
                @CharacterControls.started += instance.OnCharacterControls;
                @CharacterControls.performed += instance.OnCharacterControls;
                @CharacterControls.canceled += instance.OnCharacterControls;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @ColorControls.started += instance.OnColorControls;
                @ColorControls.performed += instance.OnColorControls;
                @ColorControls.canceled += instance.OnColorControls;
                @Respawn.started += instance.OnRespawn;
                @Respawn.performed += instance.OnRespawn;
                @Respawn.canceled += instance.OnRespawn;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public CharacterControlsActions @CharacterControls => new CharacterControlsActions(this);
    public interface ICharacterControlsActions
    {
        void OnCameraControls(InputAction.CallbackContext context);
        void OnCharacterControls(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnColorControls(InputAction.CallbackContext context);
        void OnRespawn(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}

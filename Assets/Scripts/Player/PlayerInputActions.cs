// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Player
{
    public class @PlayerInputActions : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""General"",
            ""id"": ""fa28b306-4a62-40b8-85bd-8a9bc78e0218"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0615a0eb-e6e5-488d-abe9-740b9a5a8f60"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Walk"",
                    ""type"": ""Button"",
                    ""id"": ""f5f22f7c-c3ba-45ac-9b87-90396db047eb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HoldInstrument"",
                    ""type"": ""Button"",
                    ""id"": ""61ff8865-4eee-43a1-8402-5535838052a1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""ff7ee67e-e5be-4771-8ed3-080ffe3d0312"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""01b0d4f3-2951-44a4-95bb-00bebce5179e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""503e5c71-46a5-4966-a995-48c4c3ebd37c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""613a69ff-bc41-4908-975d-70889db4b305"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6437d662-2ece-4a58-9957-b91cb3f8e5a2"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left Analogue Stick"",
                    ""id"": ""120a1d93-9b4f-46c1-a26c-024f708352bb"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b361be20-b451-41f0-8a77-000e91be8b47"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c11fe4c8-592b-4f59-9c13-a66cd30d3b02"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""542840c9-4dff-42e3-b1b9-5d587b77535b"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ac96eec3-1a13-4096-8191-4c6ad9c22394"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6dd2bfd6-909c-44b5-a297-ff25dbd8838a"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""456765a5-2c98-40d4-9315-a84327662544"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""HoldInstrument"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7091c36-edc6-4232-af3b-2878c5bdda32"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""HoldInstrument"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""InstrumentOut"",
            ""id"": ""c919f5eb-01b7-41c9-a07e-4c7f4ba11742"",
            ""actions"": [
                {
                    ""name"": ""CNote"",
                    ""type"": ""Button"",
                    ""id"": ""44bf1d64-5816-4026-9c82-61247fead1eb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DNote"",
                    ""type"": ""Button"",
                    ""id"": ""9d2a4416-3f78-464e-b420-ccd4d0f901dd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ENote"",
                    ""type"": ""Button"",
                    ""id"": ""72b0f34b-de5d-4a29-82ce-3f0ee147b1d6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FNote"",
                    ""type"": ""Button"",
                    ""id"": ""cb1f8f5e-1843-48c7-9047-b40a7a87d93b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9247aa67-3722-489b-88cf-b9451b1e132c"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""CNote"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46401efd-6ba8-4647-ad4e-1f78ef8150af"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""CNote"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5f6a00ef-3108-42a5-9f39-690eaf13d110"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""DNote"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ec2fe2f6-980a-4737-8f3b-e449cd98bcd2"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""DNote"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7cc83a0-514f-43b3-8e31-6e921619a555"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""ENote"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ace00e91-3d37-457e-a241-f1fb18b1fb62"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ENote"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab280483-30f4-4cb5-b90e-7adc30f293cf"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""FNote"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2df2fb9-4b1f-441c-b30a-5b65e7665f2a"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FNote"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardAndMouse"",
            ""bindingGroup"": ""KeyboardAndMouse"",
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
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // General
            m_General = asset.FindActionMap("General", throwIfNotFound: true);
            m_General_Movement = m_General.FindAction("Movement", throwIfNotFound: true);
            m_General_Walk = m_General.FindAction("Walk", throwIfNotFound: true);
            m_General_HoldInstrument = m_General.FindAction("HoldInstrument", throwIfNotFound: true);
            // InstrumentOut
            m_InstrumentOut = asset.FindActionMap("InstrumentOut", throwIfNotFound: true);
            m_InstrumentOut_CNote = m_InstrumentOut.FindAction("CNote", throwIfNotFound: true);
            m_InstrumentOut_DNote = m_InstrumentOut.FindAction("DNote", throwIfNotFound: true);
            m_InstrumentOut_ENote = m_InstrumentOut.FindAction("ENote", throwIfNotFound: true);
            m_InstrumentOut_FNote = m_InstrumentOut.FindAction("FNote", throwIfNotFound: true);
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

        // General
        private readonly InputActionMap m_General;
        private IGeneralActions m_GeneralActionsCallbackInterface;
        private readonly InputAction m_General_Movement;
        private readonly InputAction m_General_Walk;
        private readonly InputAction m_General_HoldInstrument;
        public struct GeneralActions
        {
            private @PlayerInputActions m_Wrapper;
            public GeneralActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_General_Movement;
            public InputAction @Walk => m_Wrapper.m_General_Walk;
            public InputAction @HoldInstrument => m_Wrapper.m_General_HoldInstrument;
            public InputActionMap Get() { return m_Wrapper.m_General; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GeneralActions set) { return set.Get(); }
            public void SetCallbacks(IGeneralActions instance)
            {
                if (m_Wrapper.m_GeneralActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnMovement;
                    @Walk.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnWalk;
                    @Walk.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnWalk;
                    @Walk.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnWalk;
                    @HoldInstrument.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnHoldInstrument;
                    @HoldInstrument.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnHoldInstrument;
                    @HoldInstrument.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnHoldInstrument;
                }
                m_Wrapper.m_GeneralActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Walk.started += instance.OnWalk;
                    @Walk.performed += instance.OnWalk;
                    @Walk.canceled += instance.OnWalk;
                    @HoldInstrument.started += instance.OnHoldInstrument;
                    @HoldInstrument.performed += instance.OnHoldInstrument;
                    @HoldInstrument.canceled += instance.OnHoldInstrument;
                }
            }
        }
        public GeneralActions @General => new GeneralActions(this);

        // InstrumentOut
        private readonly InputActionMap m_InstrumentOut;
        private IInstrumentOutActions m_InstrumentOutActionsCallbackInterface;
        private readonly InputAction m_InstrumentOut_CNote;
        private readonly InputAction m_InstrumentOut_DNote;
        private readonly InputAction m_InstrumentOut_ENote;
        private readonly InputAction m_InstrumentOut_FNote;
        public struct InstrumentOutActions
        {
            private @PlayerInputActions m_Wrapper;
            public InstrumentOutActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @CNote => m_Wrapper.m_InstrumentOut_CNote;
            public InputAction @DNote => m_Wrapper.m_InstrumentOut_DNote;
            public InputAction @ENote => m_Wrapper.m_InstrumentOut_ENote;
            public InputAction @FNote => m_Wrapper.m_InstrumentOut_FNote;
            public InputActionMap Get() { return m_Wrapper.m_InstrumentOut; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(InstrumentOutActions set) { return set.Get(); }
            public void SetCallbacks(IInstrumentOutActions instance)
            {
                if (m_Wrapper.m_InstrumentOutActionsCallbackInterface != null)
                {
                    @CNote.started -= m_Wrapper.m_InstrumentOutActionsCallbackInterface.OnCNote;
                    @CNote.performed -= m_Wrapper.m_InstrumentOutActionsCallbackInterface.OnCNote;
                    @CNote.canceled -= m_Wrapper.m_InstrumentOutActionsCallbackInterface.OnCNote;
                    @DNote.started -= m_Wrapper.m_InstrumentOutActionsCallbackInterface.OnDNote;
                    @DNote.performed -= m_Wrapper.m_InstrumentOutActionsCallbackInterface.OnDNote;
                    @DNote.canceled -= m_Wrapper.m_InstrumentOutActionsCallbackInterface.OnDNote;
                    @ENote.started -= m_Wrapper.m_InstrumentOutActionsCallbackInterface.OnENote;
                    @ENote.performed -= m_Wrapper.m_InstrumentOutActionsCallbackInterface.OnENote;
                    @ENote.canceled -= m_Wrapper.m_InstrumentOutActionsCallbackInterface.OnENote;
                    @FNote.started -= m_Wrapper.m_InstrumentOutActionsCallbackInterface.OnFNote;
                    @FNote.performed -= m_Wrapper.m_InstrumentOutActionsCallbackInterface.OnFNote;
                    @FNote.canceled -= m_Wrapper.m_InstrumentOutActionsCallbackInterface.OnFNote;
                }
                m_Wrapper.m_InstrumentOutActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @CNote.started += instance.OnCNote;
                    @CNote.performed += instance.OnCNote;
                    @CNote.canceled += instance.OnCNote;
                    @DNote.started += instance.OnDNote;
                    @DNote.performed += instance.OnDNote;
                    @DNote.canceled += instance.OnDNote;
                    @ENote.started += instance.OnENote;
                    @ENote.performed += instance.OnENote;
                    @ENote.canceled += instance.OnENote;
                    @FNote.started += instance.OnFNote;
                    @FNote.performed += instance.OnFNote;
                    @FNote.canceled += instance.OnFNote;
                }
            }
        }
        public InstrumentOutActions @InstrumentOut => new InstrumentOutActions(this);
        private int m_KeyboardAndMouseSchemeIndex = -1;
        public InputControlScheme KeyboardAndMouseScheme
        {
            get
            {
                if (m_KeyboardAndMouseSchemeIndex == -1) m_KeyboardAndMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardAndMouse");
                return asset.controlSchemes[m_KeyboardAndMouseSchemeIndex];
            }
        }
        private int m_GamepadSchemeIndex = -1;
        public InputControlScheme GamepadScheme
        {
            get
            {
                if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
                return asset.controlSchemes[m_GamepadSchemeIndex];
            }
        }
        public interface IGeneralActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnWalk(InputAction.CallbackContext context);
            void OnHoldInstrument(InputAction.CallbackContext context);
        }
        public interface IInstrumentOutActions
        {
            void OnCNote(InputAction.CallbackContext context);
            void OnDNote(InputAction.CallbackContext context);
            void OnENote(InputAction.CallbackContext context);
            void OnFNote(InputAction.CallbackContext context);
        }
    }
}

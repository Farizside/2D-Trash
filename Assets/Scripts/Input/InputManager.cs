using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    [DefaultExecutionOrder(-100)]
    public class InputManager : MonoBehaviour, InputSystem_Actions.IPlayerActions
    {
        private InputSystem_Actions _inputActions;
        public static InputManager Instance;

        public static Action<Vector2> moveAction;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(Instance);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            _inputActions = new InputSystem_Actions();

            _inputActions.Player.SetCallbacks(this);

            EnablePlayerInput();
        }
        public void EnablePlayerInput()
        {
            _inputActions.Player.Enable();
            _inputActions.UI.Disable();
        }

        public void EnableUIInput()
        {
            _inputActions.Player.Disable();
            _inputActions.UI.Enable();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            moveAction?.Invoke(context.ReadValue<Vector2>());
        }
    }
}

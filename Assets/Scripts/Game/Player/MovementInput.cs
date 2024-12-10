using PlayerInput;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Game.Player
{
    public class MovementInput : InputActions.IPlayerActions, IInitializable, ILateDisposable
    {
        private readonly InputActions _inputActions = new();
        public Vector2 MovementDirection { get; private set; }
        public bool IsMoving { get; private set; }

        public void OnMove(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<Vector2>();
            MovementDirection = new Vector2(value.x, value.y);
            IsMoving = context.phase switch
            {
                InputActionPhase.Started => true,
                InputActionPhase.Canceled => false,
                _ => IsMoving
            };
        }

        public void Initialize()
        {
            _inputActions.Player.Enable();
            _inputActions.Player.SetCallbacks(this);
        }

        public void LateDispose()
        {
            _inputActions.Player.Disable();
            _inputActions.Player.SetCallbacks(this);
        }
    }
}
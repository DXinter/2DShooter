using Core;
using UnityEngine;
using Zenject;

namespace Game.Player
{
    public class PlayerFacade : Dependency, ITickable
    {
        [SerializeField] private GameObject characterAvatar;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float playerSpeed;
        [SerializeField] private Transform gunPosition;
        
        private MovementInput _movementInput;

        public Transform GunPosition => gunPosition;


        [Inject]
        public void Construct(MovementInput movementInput)
        {
            _movementInput = movementInput;
        }

        public void Tick()
        {
            if (!_movementInput.IsMoving)
            {
                rb.velocity = new Vector3(0, _movementInput.MovementDirection.y);
                return;
            }

            rb.velocity = new Vector3(_movementInput.MovementDirection.x * playerSpeed,
                _movementInput.MovementDirection.y);

            transform.localScale = _movementInput.MovementDirection.x switch
            {
                > 0 => new Vector3(1, 1, 1),
                < 0 => new Vector3(-1, 1, 1),
                _ => transform.localScale
            };
        }
    }
}
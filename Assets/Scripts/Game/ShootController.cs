using System;
using Game.Ammo;
using Game.Player;
using PlayerInput;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Game
{
    public class ShootController : InputActions.IFireActions, IInitializable, ILateDisposable, ITickable
    {
        private readonly InputActions _inputActions = new();
        private PlayerFacade _playerFacade;
        private Bullet.Bullet.Pool _pool;
        private Settings _settings;
        private AmmoCounter _ammoCounter;

        private float _lastFireTime;
        private bool _isShooting;

        [Inject]
        public void Construct(Bullet.Bullet.Pool pool, PlayerFacade playerFacade, Settings settings,
            AmmoCounter ammoCounter)
        {
            _pool = pool;
            _playerFacade = playerFacade;
            _settings = settings;
            _ammoCounter = ammoCounter;
        }

        public void Initialize()
        {
            _inputActions.Fire.Enable();
            _inputActions.Fire.SetCallbacks(this);
        }

        public void LateDispose()
        {
            _inputActions.Fire.Disable();
            _inputActions.Fire.SetCallbacks(this);
        }

        public void OnFire(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _isShooting = true;
                TryShoot();
            }

            if (context.canceled)
            {
                _isShooting = false;
            }
        }

        public void Tick()
        {
            if (_isShooting && Time.time >= _lastFireTime + _settings.fireRate)
            {
                TryShoot();
            }
        }

        private void TryShoot()
        {
            if (Time.time < _lastFireTime + _settings.fireRate) return;

            var bullet = _pool.Spawn();
            bullet.transform.position = _playerFacade.GunPosition.position;

            _ammoCounter.SubAmmo();

            var direction = _playerFacade.transform.localScale.x > 0 ? 1 : -1;
            bullet.Rb.velocity = new Vector2(direction * bullet.Speed, 0);

            _lastFireTime = Time.time;
        }

        [Serializable]
        public class Settings
        {
            public float fireRate;
        }
    }
}
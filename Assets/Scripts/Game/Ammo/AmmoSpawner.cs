using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.Ammo
{
    public class AmmoSpawner : MonoBehaviour
    {
        private Settings _settings;
        private Ammo.Pool _pool;
        private AmmoCollectedHandler _ammoCollectedHandler;

        [Inject]
        public void Construct(Settings settings, Ammo.Pool pool, AmmoCollectedHandler ammoCollectedHandler)
        {
            _settings = settings;
            _pool = pool;
            _ammoCollectedHandler = ammoCollectedHandler;
        }

        public void SpawnAmmo(Vector3 position)
        {
            var ammo = _pool.Spawn();
            ammo.transform.position = position;
            ammo.SetAmmo(Random.Range(_settings.minAmmoCount, _settings.maxAmmoCount));
            ammo.OnAmmoCollect += OnAmmoCollected;
        }

        private void OnAmmoCollected(Ammo ammo)
        {
            ammo.OnAmmoCollect -= OnAmmoCollected;
            _ammoCollectedHandler.Collect(ammo);
        }

        [Serializable]
        public class Settings
        {
            public int minAmmoCount;
            public int maxAmmoCount;
        }
    }
}
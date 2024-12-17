using System;
using Zenject;

namespace Game.Ammo
{
    public class AmmoCounter
    {
        private int _totalAmmoCount;
        private Settings _settings;

        public int TotalAmmoCount => _totalAmmoCount;

        public event Action<int> OnAmmoValueChanged;

        [Inject]
        public void Construct(Settings settings)
        {
            _settings = settings;
            _totalAmmoCount = settings.baseAmmoCount;
        }

        public void SubAmmo(int value = 1)
        {
            _totalAmmoCount -= value;
            OnAmmoValueChanged?.Invoke(_totalAmmoCount);
        }

        public void AddAmmo(int value)
        {
            _totalAmmoCount += value;
            OnAmmoValueChanged?.Invoke(_totalAmmoCount);
        }

        [Serializable]
        public class Settings
        {
            public int baseAmmoCount;
        }
    }
}
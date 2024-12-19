using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.Ammo
{
    public class Ammo : MonoBehaviour
    {
        [SerializeField] private TMP_Text ammoText;
        private int _ammoCount;
        public event Action<Ammo> OnAmmoCollect;

        public int AmmoCount => _ammoCount;

        public void SetAmmo(int value)
        {
            ammoText.text = value.ToString();
            _ammoCount = value;
        }

        public void Collect()
        {
            OnAmmoCollect?.Invoke(this);
        }

        public class Pool : MonoMemoryPool<Ammo>
        {
        }
    }
}
using Game.Ammo;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.View
{
    public class AmmoCountView : MonoBehaviour
    {
        [SerializeField] private TMP_Text count;
        private AmmoCounter _ammoCounter;

        [Inject]
        public void Construct(AmmoCounter ammoCounter)
        {
            _ammoCounter = ammoCounter;
        }

        private void Start()
        {
            count.text = _ammoCounter.TotalAmmoCount.ToString();
            _ammoCounter.OnAmmoValueChanged += UpdateText;
        }

        private void UpdateText(int value)
        {
            count.text = value.ToString();
        }
    }
}
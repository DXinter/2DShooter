using Game.Player;
using UnityEngine;

namespace Game.Ammo
{
    public class AmmoTriggerDispatcher : MonoBehaviour
    {
        [SerializeField] private Ammo target;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out PlayerFacade playerFacade))
            {
                return;
            }

            target.Collect();
        }
    }
}
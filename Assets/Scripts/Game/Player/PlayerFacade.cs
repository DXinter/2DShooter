using Core;
using UnityEngine;
using Zenject;

namespace Game.Player
{
    public class PlayerFacade : Dependency, ITickable
    {
        [SerializeField] private GameObject characterAvatar;

        private Transform _transform;
        
        [Inject]
        public void Construct()
        {
        }

        public void Tick()
        {
        }
    }
}
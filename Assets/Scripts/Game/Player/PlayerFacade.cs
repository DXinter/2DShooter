using Core;
using UnityEngine;
using Zenject;

namespace Game.Player
{
    public class PlayerFacade : Dependency, ITickable
    {
        [SerializeField] private GameObject characterAvatar;
        
        [Inject]
        public void Construct()
        {
        }

        public void Tick()
        {
        }
    }
}
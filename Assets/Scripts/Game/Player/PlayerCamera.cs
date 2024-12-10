using Cinemachine;
using Core;
using Zenject;

namespace Game.Player
{
    public class PlayerCamera : Dependency
    {
        private PlayerFacade _playerFacade;
        private CinemachineVirtualCamera _virtualCamera;

        [Inject]
        public void Construct(PlayerFacade playerFacade, CinemachineVirtualCamera virtualCamera)
        {
            _playerFacade = playerFacade;
            _virtualCamera = virtualCamera;

            AddDependency(playerFacade);
        }

        protected override void InternalInit()
        {
            _virtualCamera.Follow = _playerFacade.transform;
            InitializationDone();
        }
    }
}
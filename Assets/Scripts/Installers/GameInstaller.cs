using System;
using System.Collections.Generic;
using Cinemachine;
using Game.Player;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Transform objectsPool;
        [SerializeField] private Transform charactersContainer;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private CinemachineVirtualCamera virtualCamera;

        [Inject] private Settings _settings;

        public override void InstallBindings()
        {
            InstallPlayer();
            InstallManagers();
            InstallServices();
            InstallFactories();
            InstallPools();
        }

        private void InstallPlayer()
        {
            Container.BindInterfacesAndSelfTo<CinemachineVirtualCamera>()
                .FromInstance(virtualCamera);

            Container.BindInterfacesAndSelfTo<Camera>()
                .FromInstance(mainCamera);

            Container.Bind<PlayerCamera>()
                .FromNewComponentOnNewGameObject()
                .AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<PlayerFacade>()
                .FromComponentInNewPrefab(_settings.playerPrefab)
                .UnderTransform(charactersContainer)
                .AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<MovementInput>().AsSingle().NonLazy();
        }

        private void InstallManagers()
        {
            var managers = new List<Type>
            {
            };

            foreach (var manager in managers)
            {
                Container.BindInterfacesAndSelfTo(manager)
                    .FromNewComponentOnNewGameObject().UnderTransformGroup("Managers").AsSingle().NonLazy();
            }
        }

        private void InstallServices()
        {
            var services = new List<Type>
            {
            };

            foreach (var service in services)
            {
                Container.BindInterfacesAndSelfTo(service).AsSingle().NonLazy();
            }
        }


        private void InstallFactories()
        {
        }

        private void InstallPools()
        {
        }

        [Serializable]
        public class Settings
        {
            [Header("Prefabs")] public GameObject playerPrefab;
        }
    }
}
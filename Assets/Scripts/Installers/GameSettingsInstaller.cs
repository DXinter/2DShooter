using Game;
using Game.Ammo;
using Game.Enemy;
using UnityEngine;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(menuName = "Game/Game Settings")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        public GameInstaller.Settings gameSettings;
        public ShootController.Settings shootSettings;
        public EnemySpawner.Settings spawnSettings;
        public AmmoCounter.Settings ammoCounterSettings;
        public AmmoSpawner.Settings ammoSpawnerSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(gameSettings).IfNotBound();
            Container.BindInstance(shootSettings).IfNotBound();
            Container.BindInstance(spawnSettings).IfNotBound();
            Container.BindInstance(ammoCounterSettings).IfNotBound();
            Container.BindInstance(ammoSpawnerSettings).IfNotBound();
        }
    }
}
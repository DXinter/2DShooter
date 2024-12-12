using Game;
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

        public override void InstallBindings()
        {
            Container.BindInstance(gameSettings).IfNotBound();
            Container.BindInstance(shootSettings).IfNotBound();
            Container.BindInstance(spawnSettings).IfNotBound();
        }
    }
}
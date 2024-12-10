using UnityEngine;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(menuName = "Game/Game Settings")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        public GameInstaller.Settings gameSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(gameSettings).IfNotBound();
        }
    }
}
using Game.Ammo;
using Zenject;

namespace Game.Enemy
{
    public class EnemyDeathHandler
    {
        private Enemy.Pool _pool;
        private AmmoSpawner _ammoSpawner;

        [Inject]
        public void Construct(Enemy.Pool pool, AmmoSpawner ammoSpawner)
        {
            _ammoSpawner = ammoSpawner;
            _pool = pool;
        }

        public void Despawn(Enemy target)
        {
            _ammoSpawner.SpawnAmmo(target.EnemyDeadPosition.position);
            _pool.Despawn(target);
        }
    }
}
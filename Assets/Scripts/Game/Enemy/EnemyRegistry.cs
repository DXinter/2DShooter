using System.Collections.Generic;

namespace Game.Enemy
{
    public class EnemyRegistry
    {
        private readonly List<Enemy> _enemies = new();

        public void AddEnemy(Enemy target)
        {
            if (_enemies.Contains(target))
            {
                return;
            }

            _enemies.Add(target);
        }

        public void RemoveEnemy(Enemy target)
        {
            if (!_enemies.Contains(target))
            {
                return;
            }

            _enemies.Remove(target);
        }

        public List<Enemy> GetAllEnemies()
        {
            return _enemies;
        }
    }
}
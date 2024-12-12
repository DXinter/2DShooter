using UnityEngine;
using Zenject;

namespace Game.Bullet
{
    public class BulletTriggerDispatcher : MonoBehaviour
    {
        [SerializeField] private Bullet bullet;
        private Bullet.Pool _pool;

        [Inject]
        public void Construct(Bullet.Pool pool)
        {
            _pool = pool;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out Enemy.Enemy enemy))
            {
                return;
            }

            enemy.Hit();
            
            _pool.Despawn(bullet);
        }
    }
}
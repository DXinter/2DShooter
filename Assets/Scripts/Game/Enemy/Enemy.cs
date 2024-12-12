using Game.Data;
using UnityEngine;
using Zenject;

namespace Game.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer avatar;
        private float _speed;
        private int _health;
        private Pool _pool;

        public float Speed => _speed;

        public int Health => _health;

        [Inject]
        public void Construct(Pool pool)
        {
            _pool = pool;
        }

        public void Init(EnemyData data)
        {
            avatar.sprite = data.sprite;
            _speed = data.speed;
            _health = data.health;
        }


        public void Hit()
        {
            _health--;
            
            if (_health > 0)
            {
                return;
            }

            _pool.Despawn(this);
        }

        public class Pool : MonoMemoryPool<Enemy>
        {
        }
    }
}
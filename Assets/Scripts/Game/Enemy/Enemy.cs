using System;
using Game.Data;
using UnityEngine;
using Zenject;

namespace Game.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer avatar;

        private Pool _pool;
        public float Speed { get; private set; }
        public int Health { get; private set; }
        public event Action OnEnemyHit;
        public event Action OnEnemyInitialized;

        [Inject]
        public void Construct(Pool pool)
        {
            _pool = pool;
        }

        public void Init(EnemyData data)
        {
            avatar.sprite = data.sprite;
            Speed = data.speed;
            Health = data.health;

            OnEnemyInitialized?.Invoke();
        }


        public void Hit()
        {
            Health--;

            OnEnemyHit?.Invoke();

            if (Health > 0)
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
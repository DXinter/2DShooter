using System;
using Game.Data;
using UnityEngine;
using Zenject;

namespace Game.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer avatar;
        private Transform _enemyDeadPosition;
        public float Speed { get; private set; }
        public int Health { get; private set; }
        public Transform EnemyDeadPosition => _enemyDeadPosition;
        public event Action OnEnemyHit;
        public event Action<Enemy> OnEnemyDead;
        public event Action OnEnemyInitialized;
        
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

            _enemyDeadPosition = transform;
            OnEnemyDead?.Invoke(this);
        }

        public class Pool : MonoMemoryPool<Enemy>
        {
        }
    }
}
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

        public float Speed => _speed;

        public int Health => _health;

        public void Init(EnemyData data)
        {
            avatar.sprite = data.sprite;
            _speed = data.speed;
            _health = data.health;
        }

        public class Pool : MonoMemoryPool<Enemy>
        {
        }
    }
}
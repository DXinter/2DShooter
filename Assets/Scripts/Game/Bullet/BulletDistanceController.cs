using UnityEngine;
using Zenject;

namespace Game.Bullet
{
    public class BulletDistanceController : MonoBehaviour
    {
        [SerializeField] private Bullet bullet;
        [SerializeField] private int maxDistance;
        
        private Bullet.Pool _pool;
        private Vector3 _startPos;

        [Inject]
        public void Construct(Bullet.Pool pool)
        {
            _pool = pool;
        }

        private void OnEnable()
        {
            _startPos = transform.position;
        }

        private void Update()
        {
            if (Vector3.Distance(_startPos, transform.position) >= maxDistance)
            {
                _pool.Despawn(bullet);
            }
        }
    }
}
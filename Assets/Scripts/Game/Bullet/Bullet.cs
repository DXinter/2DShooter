using UnityEngine;
using Zenject;

namespace Game.Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Rigidbody rb;

        public float Speed => speed;

        public Rigidbody Rb => rb;

        public class Pool : MonoMemoryPool<Bullet>
        {
            
        }
    }
}
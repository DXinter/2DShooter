using UnityEngine;

namespace Game.Enemy
{
    public class EnemyMovementController : MonoBehaviour
    {
        [SerializeField] private Enemy enemy;

        private void Update()
        {
            var direction = transform.localScale.x > 0 ? 1 : -1;
            transform.position += Vector3.right * direction * enemy.Speed * Time.deltaTime;
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

namespace Game.Enemy
{
    public class EnemyHealthBarController : MonoBehaviour
    {
        [SerializeField] private Enemy enemy;
        [SerializeField] private Slider slider;
        
        private void Init()
        {
            slider.minValue = 0;
            slider.maxValue = enemy.Health;
            slider.value = enemy.Health;
        }

        private void OnEnable()
        {
            enemy.OnEnemyHit += UpdateHealth;
            enemy.OnEnemyInitialized += Init;
        }

        private void OnDisable()
        {
            enemy.OnEnemyHit -= UpdateHealth;
            enemy.OnEnemyInitialized -= Init;
        }

        private void UpdateHealth()
        {
            slider.value = enemy.Health;
        }
    }
}
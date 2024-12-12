using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(menuName = "Enemy/Enemy Data")]
    public class EnemyData : ScriptableObject
    {
        public Sprite sprite;
        public float speed;
        public int health;
    }
}
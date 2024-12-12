using System;
using System.Collections;
using System.Collections.Generic;
using Game.Data;
using Game.Player;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        private List<Transform> _spawnPoints;
        private PlayerFacade _playerFacade;
        private Enemy.Pool _pool;
        private Settings _settings;

        [Inject]
        public void Construct(PlayerFacade playerFacade, List<Transform> spawnPoints,
            Enemy.Pool pool, Settings settings)
        {
            _playerFacade = playerFacade;
            _spawnPoints = spawnPoints;
            _pool = pool;
            _settings = settings;
        }

        private void Start()
        {
            StartCoroutine(SpawnEnemies());
        }

        private IEnumerator SpawnEnemies()
        {
            while (true)
            {
                var spawnPosition = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
                var enemy = _pool.Spawn();
                var enemyIndex = Random.Range(0, _settings.enemies.Count);

                enemy.gameObject.transform.position = spawnPosition.position;

                var direction = _playerFacade.transform.position - enemy.gameObject.transform.position;
                enemy.transform.localScale = direction.x switch
                {
                    > 0 => new Vector3(1, 1, 1),
                    < 0 => new Vector3(-1, 1, 1),
                    _ => transform.localScale
                };
                
                enemy.Init(_settings.enemies[enemyIndex]);
                
                yield return new WaitForSeconds(Random.Range(_settings.minSpawnInterval, _settings.maxSpawnInterval));
            }
        }

        [Serializable]
        public class Settings
        {
            public List<EnemyData> enemies;
            public int minSpawnInterval;
            public int maxSpawnInterval;
        }
    }
}
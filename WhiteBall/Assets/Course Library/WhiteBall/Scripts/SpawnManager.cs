using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<PowerUp> _powerUps = new List<PowerUp>();
    
    [SerializeField] private Enemy _enemy;
    
    [SerializeField] private PlayerController _player;
    
    [SerializeField] private ScoreDisplay _scoreDisplay;
    [SerializeField] private EnemyDisplay _enemyDisplay;
    

    private float _spawnRange = 9;
    private float _defSpawnChance = 0.5f;
    private float _spawnChance = 0.5f;
    private float _chanceStep = 0.1f;
    
    private int _step = 0;
    private int _enemyCount = 1;
    private int _currentWave = 0;
    
    private bool _waveSpawnedThisClear;
    

    private void Update()
    {
        _enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;

        _enemyDisplay.UpdateEnemy(_enemyCount);

        if (_currentWave < 1)
        {
            _currentWave = 1;
        }

        if (_enemyCount > 0)
        {
            _waveSpawnedThisClear = false;
            return;
        }

        if (_waveSpawnedThisClear)
        {
            return;
        }

        _waveSpawnedThisClear = true;

        _scoreDisplay.UpdateScore(_currentWave);

        int enemiesInWave = 0;

        if (Random.value < _spawnChance)
        {
            _spawnChance = _defSpawnChance;
            _step = 0;
        }

        enemiesInWave = _currentWave - _step;

        _spawnChance += _chanceStep;

        SpawnEnemyWave(enemiesInWave);

        SpawnRandomPowerUp();

        _currentWave++;
        _step++;
    }
    
    private void SpawnRandomPowerUp()
    {
        int powerUp = Random.Range(0, _powerUps.Count);

        Vector3 spawnPos = GenerateSpawnPosition();

        Instantiate(_powerUps[powerUp], spawnPos, _powerUps[powerUp].transform.rotation);
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Vector3 spawnPos = GenerateSpawnPosition();

            Enemy enemy = Instantiate(_enemy, spawnPos, _enemy.transform.rotation);

            enemy.Initialized(_player);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float randomPositionX = Random.Range(-_spawnRange, _spawnRange);
        float randomPositionZ = Random.Range(-_spawnRange, _spawnRange);

        return new Vector3(randomPositionX, 0, randomPositionZ);
    }


}

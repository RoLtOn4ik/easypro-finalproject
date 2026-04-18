using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpawnManager : MonoBehaviour
{
    [SerializeField] private Bot _player;
    [SerializeField] private Bot _enemy;

    private Bot Player;
    private Bot Enemy;

    public List<Bot> Enemies = new List<Bot>();

    private float _spawnTime = 0;
    private float _startSpawnTime = 6;

    private float _spawnRange = 7;

    private void Start()
    {
        Player = Instantiate(_player, GenerateRandomPosition(), _player.transform.rotation);
    }

    private void Update()
    {
        if (_spawnTime <= 0)
        {
            Enemy = Instantiate(_enemy, GenerateRandomPosition(), _player.transform.rotation);
            Enemies.Add(Enemy);

            GiveTarget(Enemy, Player);

            _spawnTime = _startSpawnTime;
        }
        else
        {
            _spawnTime -= Time.deltaTime;
        }

        if (Player.transform.position.y <= -5)
        {
            Player.Rigidbod.angularVelocity = Vector3.zero;
            Player.Rigidbod.velocity = Vector3.zero;

            Player.SetTargetNull();
            
            Player.transform.position = GenerateRandomPosition();
            
            int enemyIndex = ChooseRandomEnemyIndex();

            if (Enemies.Count != 0)
                GiveTarget(Player, Enemies[enemyIndex]);
        }

        if (Player.hasNoTarget && Player.onGround)
        {
            Player.Rigidbod.angularVelocity = Vector3.zero;
            Player.Rigidbod.velocity = Vector3.zero;

            int enemyIndex = ChooseRandomEnemyIndex();

            if (Enemies.Count != 0)
                GiveTarget(Player, Enemies[enemyIndex]);
        }

        if (Enemy.hasNoTarget && Enemy.onGround)
        {
            Enemy.Rigidbod.angularVelocity = Vector3.zero;
            Enemy.Rigidbod.velocity = Vector3.zero;

            GiveTarget(Enemy, Player);
        }

        Enemies.RemoveAll(e => e.isDead);
    }

    private void GiveTarget(Bot targeter, Bot target)
    {
        targeter.GetEnemy(target);
    }

    private int ChooseRandomEnemyIndex()
    {
        int indx = Random.Range(0, Enemies.Count);

        return indx;
    }

    private Vector3 GenerateRandomPosition()
    {
        float randomPositionX = Random.Range(-_spawnRange, _spawnRange);
        float randomPositionZ = Random.Range(-_spawnRange, _spawnRange);

        return new Vector3(randomPositionX, 14, randomPositionZ);
    }

    

}

using System.Collections.Generic;
using UnityEngine;

public class PoitionProjectile : MonoBehaviour
{
    [SerializeField] private GameObject _potionModel;
    [SerializeField] private PotionExplosion _explotion;

    private List<Enemy> enemies;
    private Transform target;

    private float _speed = 20;
    private float _rotationSpeed = 1000;

    void Start()
    {
        enemies = new List<Enemy>(Object.FindObjectsByType<Enemy>(FindObjectsSortMode.None));

        int i = Random.Range(0, enemies.Count);

        target = enemies[i].transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Destroy(enemy.gameObject);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        float angle = _rotationSpeed * Time.deltaTime;
        
        _potionModel.transform.rotation *= Quaternion.AngleAxis(angle, Vector3.right);

        Vector3 direction = (target.position - transform.position).normalized;
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    private void Explode()
    {
        Instantiate(_explotion, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
        Destroy(gameObject);
    }

}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rb;
    
    [SerializeField] private PlayerController _player;

    private void Update()
    {
        Vector3 direction = (_player.transform.position - transform.position).normalized;
        _rb.AddForce(direction * _speed);

        if (transform.position.y < -10)
            Destroy(gameObject);
    }

    public void Initialized(PlayerController player)
    {
        _player = player;
    }

}

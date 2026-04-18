using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] private Bot _targetEnemy;
    [SerializeField] private float _speed;
    [SerializeField] private float _deathY;

    public Rigidbody Rigidbod;

    public bool onGround = false;
    public bool hasNoTarget = false;
    public bool isDead = false;

    private void Start()
    {
        Rigidbod = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_targetEnemy == null)
        {
            hasNoTarget = true;
            
            return;
        }

        if (!_targetEnemy.onGround)
        {
            SetTargetNull();

            return;
        }

        if (transform.position.y <= _deathY && !gameObject.CompareTag("Player"))
        {   
            isDead = true;
            
            Destroy(gameObject);
        }

        Vector3 direction = (_targetEnemy.transform.position - transform.position).normalized;
        
        Rigidbod.AddForce(direction * _speed);
    }

    public void GetEnemy(Bot enemy)
    {
        _targetEnemy = enemy;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && transform.position.y <= -0.1)
        {
            onGround = false;
        }
    }
    
    public void SetTargetNull()
    {
        _targetEnemy = null;
        
        hasNoTarget = true;
    }

}

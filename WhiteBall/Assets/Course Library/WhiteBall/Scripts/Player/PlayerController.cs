using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _playerRb;
    [SerializeField] private GameObject _focalePoint;
    [SerializeField] private float _speed;

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        _playerRb.AddForce(_focalePoint.transform.forward * _speed * forwardInput);
    }   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    void Update()
    {
        float _horizontalInput = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up * _horizontalInput * _rotateSpeed * Time.deltaTime);
    }
}

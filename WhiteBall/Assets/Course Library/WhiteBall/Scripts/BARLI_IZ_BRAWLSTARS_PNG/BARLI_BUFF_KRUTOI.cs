using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BARLI_BUFF_KRUTOI : MonoBehaviour
{
    [SerializeField] private PoitionProjectile poition;

    private float _throwCountDown = 0;
    private float _startThrowCountDown = 0.3f;


    void Update()
    {
        if (_throwCountDown <= 0)
        {
            Instantiate(poition, gameObject.transform.position, poition.transform.rotation);
            _throwCountDown = _startThrowCountDown;
        }
        else
            _throwCountDown -= Time.deltaTime;

    }
}

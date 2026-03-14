using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private float amplitude = 0.25f;
    private float frequency = 2f;
    
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        float newY = Mathf.Sin(Time.time * frequency) * amplitude;
        
        transform.position = startPos + new Vector3(0, newY, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerUpgrade>(out PlayerUpgrade player))
        {
            player.GetPowerUp(gameObject.tag);
            Destroy(gameObject);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private Canvas _gameOverScreen;

    private void Start()
    {
        _gameOverScreen.enabled = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
        {
            _gameOverScreen.enabled = true;

            Time.timeScale = 0f;
        }
    }
}

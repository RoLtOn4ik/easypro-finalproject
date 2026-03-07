using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _playerRb;
    [SerializeField] private GameObject _powerUpIndicator;
    [SerializeField] private GameObject _focalePoint;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private float _speed;
    [SerializeField] private float _soundColdown;
    [SerializeField] private float _startSoundColdown;

    private bool _isPowerUp;

    private void Start()
    {
        _isPowerUp = false;
        _powerUpIndicator.gameObject.SetActive(false);
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        _powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);
        _powerUpIndicator.transform.Rotate(0, -90 * Time.deltaTime, 0);
        _playerRb.AddForce(_focalePoint.transform.forward * _speed * forwardInput);

        if (_isPowerUp)
        {
            if (_soundColdown <= 0)
            {
                _audio.PlayOneShot(_audioClip, 0.5f);

                _soundColdown = _startSoundColdown;
            }
            else
            {
                _soundColdown -= Time.deltaTime;
            }
        }
    }   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            if (_isPowerUp)
            {
                Destroy(enemy.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent<PowerUp>(out PowerUp powerup))
        {
            Destroy(powerup.gameObject);
            
            _isPowerUp = true;
            
            _powerUpIndicator.gameObject.SetActive(true);
            
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    private IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        _isPowerUp = false;
        _powerUpIndicator.gameObject.SetActive(false);
    }

}

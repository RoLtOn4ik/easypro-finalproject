using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrade : MonoBehaviour
{
    [SerializeField] private PlayerPlaySound _playerSound;
    [SerializeField] private GameObject _powerUpIndicator;
    [SerializeField] private PoitionProjectile poition;

    private bool _isPowerUp;
    private string _tipeOfUpgrade;

    private void Start()
    {
        _isPowerUp = false;
        
        _powerUpIndicator.gameObject.SetActive(false);
    }

    public void GetPowerUp(string tipeOfUpgrade)
    {
        _tipeOfUpgrade = tipeOfUpgrade;
        
        if(_tipeOfUpgrade != "Potion")
        {
            _isPowerUp = true;

            _powerUpIndicator.gameObject.SetActive(true);

            StartCoroutine(PowerupCountdownRoutine());
        }
        else 
            Instantiate(poition, gameObject.transform.position, poition.transform.rotation);


    }

    private void Update()
    {
        _powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);
        _powerUpIndicator.transform.Rotate(0, -90 * Time.deltaTime, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isPowerUp && _tipeOfUpgrade == "Radiation")
        {
            if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
            {
                Destroy(enemy.gameObject);
            }
        }
    }

    private IEnumerator PowerupCountdownRoutine()
    {
        _playerSound.PlaySound();

        yield return new WaitForSeconds(7);
        
        _isPowerUp = false;
        
        _powerUpIndicator.gameObject.SetActive(false);

        _playerSound.StopSound();
    }


}

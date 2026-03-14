using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlaySound : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip _radiationSound;
    [SerializeField] private float _soundColdown;
    [SerializeField] private float _startSoundColdown;

    public void PlaySound()
    {
        if (_soundColdown <= 0)
        {
            //_audio.PlayOneShot(_radiationSound, 0.5f);

            _soundColdown = _startSoundColdown;
        }
        else
        {
            _soundColdown -= Time.deltaTime;
        }
    }

    public void StopSound()
    {
        _audio.Stop();
    }
}

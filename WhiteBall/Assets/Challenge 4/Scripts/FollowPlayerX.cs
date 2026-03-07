using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    [SerializeField] private PlayerControllerX _player;

    // Update is called once per frame
    void Update()
    {
        transform.position = _player.transform.position;
    }
}

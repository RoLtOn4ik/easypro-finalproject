using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemyCollision : MonoBehaviour
{
    [SerializeField] private ScoreDisplayX _scoreDisplayX;

    public int playerScore = 0;
    public int enemyScore = 0;

    private void Update()
    {
        _scoreDisplayX.UpdateScore(playerScore, enemyScore);
    }
}

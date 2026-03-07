using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplayX : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreDisplay;
    public int PlayerScore = 0;
    public int EnemyScore = 0;
    private char Char = ':';

    public void UpdateScore(int playerScore, int enemScore)
    {
        PlayerScore = playerScore;
        EnemyScore = enemScore;

        _scoreDisplay.text = PlayerScore.ToString() + Char + EnemyScore.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    public void UpdateScore(int score)
    {
        _scoreText.text = score.ToString();
    }
}

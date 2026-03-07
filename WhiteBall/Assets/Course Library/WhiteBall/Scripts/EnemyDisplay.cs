using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _enemyText;

    public void UpdateEnemy(int enemy)
    {
        _enemyText.text = enemy.ToString();
    }
}

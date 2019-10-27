using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEnemy : MonoBehaviour
{
    [SerializeField] private int enemydie = 0;
    [SerializeField] private int MaxEnemyDie = 0;
    [SerializeField] private GameObject Wave1 = null;
    [SerializeField] private GameObject Wave2 = null;
    

    private void Update()
    {
        if (EnemyCount.CountEnemydie == enemydie)
        {
            Wave1.SetActive(true);
            enemydie = MaxEnemyDie;
            Wave1 = Wave2;
            if (EnemyCount.CountEnemydie == enemydie)
            {
                Wave1.SetActive(true);
            }
            
        }
    }
}

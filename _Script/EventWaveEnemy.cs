using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventWaveEnemy : MonoBehaviour
{
    public bool Wave1 = true;
    public bool Wave2 = false;
    public bool Wave3 = false;
    [SerializeField] private int EnemyDieWave1 = 0;
    [SerializeField] private int EnemyDieWave2 = 0;
//    [SerializeField] private int EnemyDieWave3 = 0;
    [SerializeField] private GameObject PivotWave1 = null;
    [SerializeField] private GameObject PivotWave2 = null;
    [SerializeField] private GameObject PivotWave3 = null;

    // Update is called once per frame
    void Update()
    {
        if (Wave1 == true)
        {
            PivotWave1.SetActive(true);
        }
        if (EnemyCount.CountEnemydie == EnemyDieWave1 && Wave1 == true)
        {
            PivotWave2.SetActive(true);
            Wave1 = false;
            Wave2 = true;
        }

        if (EnemyCount.CountEnemydie == EnemyDieWave2 && Wave2 == true)
        {
            PivotWave3.SetActive(true);
            Wave2 = false;
            Wave3 = true;
        }
    }
}

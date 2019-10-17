using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGame : MonoBehaviour
{
    public static int stagegame;
    public static int MaxEnemyDie;
    public static int MaxEnemySpawn;

    // Start is called before the first frame update
    void Start()
    {
        stagegame = 1;
        MaxEnemySpawn = 4;
        MaxEnemyDie = 4;
    }

    // Update is called once per frame
    void Update()
    {

        if (stagegame == 2)
        {
            MaxEnemySpawn = 5;
            MaxEnemyDie = 5;
            GameObject.Find("SpawnEnemy").GetComponent<SpawnEnemy>().enabled = true;
        }
        if (stagegame == 3)
        {
            MaxEnemySpawn = 6;
            MaxEnemyDie = 6;
            GameObject.Find("SpawnEnemy").GetComponent<SpawnEnemy>().enabled = true;
        }
        if (stagegame == 4)
        {
            MaxEnemySpawn = 7;
            MaxEnemyDie = 7;
            GameObject.Find("SpawnEnemy").GetComponent<SpawnEnemy>().enabled = true;
        }
        if (stagegame == 5)
        {
            MaxEnemySpawn = 8;
            MaxEnemyDie = 8;
            GameObject.Find("SpawnEnemy").GetComponent<SpawnEnemy>().enabled = true;
        }
        if (stagegame == 6)
        {
            MaxEnemySpawn = 9;
            MaxEnemyDie = 9;
            GameObject.Find("SpawnEnemy").GetComponent<SpawnEnemy>().enabled = true;
        }
        if (stagegame == 7)
        {
            MaxEnemySpawn = 10;
            MaxEnemyDie = 10;
            GameObject.Find("SpawnEnemy").GetComponent<SpawnEnemy>().enabled = true;
        }
        if (stagegame == 8)
        {
            MaxEnemySpawn = 11;
            MaxEnemyDie = 11;
            GameObject.Find("SpawnEnemy").GetComponent<SpawnEnemy>().enabled = true;
        }
        if (stagegame == 9)
        {
            MaxEnemySpawn = 12;
            MaxEnemyDie = 12;
            GameObject.Find("SpawnEnemy").GetComponent<SpawnEnemy>().enabled = true;
        }
        if (stagegame == 10)
        {
            MaxEnemySpawn = 13;
            MaxEnemyDie = 13;
            GameObject.Find("SpawnEnemy").GetComponent<SpawnEnemy>().enabled = true;
        }
    }
}

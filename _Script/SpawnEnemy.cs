using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
     public GameObject _enemy;
     public Transform _position;
     [SerializeField] public float _spawntime;
     private float i;
     private int countEnemy = 1;
     [SerializeField] private int enemycount;
     
    
    // Start is called before the first frame update
    void Start()
    {
        _spawntime = Random.Range(400,1200);
        enemycount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        i++;
        //print(Time.time);
        //print("i" + i);
        if (i == _spawntime)
        {
            Instantiate(Resources.Load("Skeleton"), _position.position, Quaternion.identity);
            print("Work");
            i = 0;
            _spawntime = Random.Range(150, 1500);
            print("SpawnTime" + _spawntime);
            enemycount = countEnemy + enemycount;
        }

        if (enemycount == StageGame.MaxEnemySpawn)
        {
            GameObject.Find("SpawnEnemy").GetComponent<SpawnEnemy>().enabled = false;
            enemycount = 0;
        }
        
        //StartCoroutine(_SpawnEnemy());
    }

    //IEnumerator _SpawnEnemy()
    //{
        //yield return new WaitForSecondsRealtime(5);
        //Instantiate(_enemy, _position.position, Quaternion.identity);
    //}
}

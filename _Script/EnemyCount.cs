using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour
{
    public static int CountEnemydie;
    [SerializeField] private int EnemyDie = 0;
    //[SerializeField] private Text _stageGame = null;

    private void Start()
    {
        //_stageGame = GameObject.Find("TextStage").GetComponent<Text>();
        StageGame.stagegame = 1;
        //_stageGame.text = ("Stage :" + StageGame.stagegame);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyDie = CountEnemydie;
        //if (EnemyDie == StageGame.MaxEnemyDie)
        //{
            //CountEnemydie = 0;
            //StageGame.stagegame = 1 + StageGame.stagegame;
            //print("StageGame : " + StageGame.stagegame);
            //_stageGame.text = ("Stage :" + StageGame.stagegame);
        //}

        if (PlayerMovement.Hp <= 0)
        {
            EnemyDie = 0;
        }
    }
    
}

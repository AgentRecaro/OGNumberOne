using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventGame : MonoBehaviour
{
    [SerializeField] private string snecename = null;
    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            DontDestroyOnLoad(player.gameObject);
            SceneManager.LoadScene(snecename);
            EnemyCount.CountEnemydie = 0;
            PlayerPrefs.SetString("NameCombo", EventComboGame.NameComBo[EventComboGame.SaveNameCombo]);
        }
    }
}

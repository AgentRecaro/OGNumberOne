using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject _player;
    
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, 3 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider EnemyAttack)
    {
        if (EnemyAttack.gameObject.tag == "Sword")
        {
            GameObject.Find("Player1").GetComponent<Animator>().SetBool("AttackOff", true);
            GameObject.Find("Player1").GetComponent<Animator>().SetBool("AttackOn", false);
            GameObject.Find("Player1").GetComponent<Transform>().rotation = Quaternion.Euler(0,180,0);
            print("Enemydie");
            Destroy(gameObject);
        }
    }

    
}

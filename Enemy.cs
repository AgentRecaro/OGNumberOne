using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{ 

    private bool enemyDie = false;
    [SerializeField] private GameObject _player;
    [SerializeField] private int _score = 0;
    [SerializeField] private float _distancePlay;
    [SerializeField] private Animator _animator = null;
    [SerializeField] private float _speed = 2;
    [SerializeField] private int _Hp;
    [SerializeField] private Vector3 directionToTarget;
    [SerializeField] private Quaternion rotationToTarget;

    private void Start()
    {
        _player = GameObject.Find("Player");
        //_animator = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Enemydie();
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
        _distancePlay = Vector3.Distance(_player.transform.position,transform.position);
        if (_distancePlay <= 2)
        {
            _animator.SetBool("AttackOn", true);
            _animator.SetBool("Run", false);
            _animator.SetBool("Idle",false);
            StartCoroutine(_time());
            _speed = 0;
        }
        else
        {
            GameObject.FindGameObjectWithTag("SwordEnemy").GetComponent<BoxCollider>().enabled = false;
            _animator.SetBool("AttackOn", false);
            _animator.SetBool("Run", true);
            _animator.SetBool("Idle",false);
            StartCoroutine(_timeAttack());
        }

        if (_Hp <= 0)
        {
            GameObject.FindGameObjectWithTag("SwordEnemy").GetComponent<BoxCollider>().enabled = false;
            _animator.SetBool("Die", true);
            _animator.SetBool("AttackOn", false);
            _animator.SetBool("Run", false);
           // GetComponent<BoxCollider>().enabled = false;
            //_player = GameObject.FindGameObjectWithTag("Floor");
            enemyDie = true;
            gameObject.tag = "Untagged";
            Destroy(gameObject, 5);
            _speed = 0;
            EnemyCount.CountEnemydie = EnemyCount.CountEnemydie + 1;
            GetComponent<Enemy>().enabled = false;

        }

        if (PlayerMovement.Hp <= 0)
        {
            _animator.SetBool("Idle", true);
            _animator.SetBool("AttackOn", false);
            _animator.SetBool("Run", false);
            _speed = 0;
        }
    }

    public void OnTriggerEnter(Collider EnemyAttack)
    {
        if (EnemyAttack.gameObject.tag == "Sword")
        {
            //GameObject.Find("Player1").GetComponent<Animator>().SetBool("AttackOff", true);
            //GameObject.Find("Player1").GetComponent<Animator>().SetBool("AttackOn", false);
            //GameObject.Find("Player1").GetComponent<Transform>().rotation = Quaternion.Euler(0,180,0);
            _Hp -= 1;
            //print("Enemydie");
            //Destroy(gameObject);
            _GUI._Score += _score;
        }

        if (EnemyAttack.gameObject.tag == "Arrow")
        {
            _Hp -= 1;
            _GUI._Score += _score;
        }
    }

    IEnumerator _time()
    {
        yield return new WaitForSecondsRealtime(0.9f);
        GameObject.FindGameObjectWithTag("SwordEnemy").GetComponent<BoxCollider>().enabled = true;
        yield return new WaitForSecondsRealtime(0.5f);
        GameObject.FindGameObjectWithTag("SwordEnemy").GetComponent<BoxCollider>().enabled = false;
        //_animator.SetBool("Idle", true);
    }

    IEnumerator _timeAttack()
    {
        yield return new WaitForSecondsRealtime(1.1f);
        _speed = 2;
    }

    void Enemydie()
    {
        if (enemyDie == false)
        {
            directionToTarget = _player.transform.position - transform.position;
            rotationToTarget = Quaternion.LookRotation(directionToTarget);
            transform.rotation = rotationToTarget;
        }
    }
}

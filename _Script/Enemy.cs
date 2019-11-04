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
    [SerializeField] private float _Hp;
    [SerializeField] private Vector3 directionToTarget;
    [SerializeField] private Quaternion rotationToTarget;
    [SerializeField] private float range = 0;
    [SerializeField] private Slider HpEnemy = null;
    [SerializeField] private GameObject SwordEnemy = null;

    private void Start()
    {
        _player = GameObject.Find("Player");
        HpEnemy.maxValue = _Hp;
        HpEnemy.direction = Slider.Direction.RightToLeft;
        //_animator = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HpEnemy.value = _Hp;
        Enemydie();
        if (_distancePlay <= 10)
        {
            enemyDie = false;
            _animator.SetBool("Run", true);
            _animator.SetBool("AttackOn", false);
            _animator.SetBool("Idle",false);
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
        }
        else
        {
            enemyDie = true;
            _animator.SetBool("AttackOn", false);
            _animator.SetBool("Run", false);
            _animator.SetBool("Idle",true);
        }
        
        _distancePlay = Vector3.Distance(_player.transform.position,transform.position);
        if (_distancePlay <= 2)
        {
            _animator.SetBool("AttackOn", true);
            _animator.SetBool("Run", false);
            _animator.SetBool("Idle",false);
        }
        else
        {
            _animator.SetBool("AttackOn", false);
            _animator.SetBool("Run", true);
            
        }

        if (_Hp <= 0)
        {
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
            EnemyCount.CountEnemydieAll = EnemyCount.CountEnemydieAll + 1;
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
            _Hp -= PlayerMovement.Damage;
            //print("Enemydie");
            //Destroy(gameObject);
            _GUI._Score += _score;
            EventComboGame.Combo += 10;
        }
    }

    public void EnableSword()
    {
        SwordEnemy.GetComponent<BoxCollider>().enabled = true;
    }

    public void DisableSword()
    {
        SwordEnemy.GetComponent<BoxCollider>().enabled = false;
    }

    public void Die()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        GetComponent<BoxCollider>().enabled = false;
        SwordEnemy.GetComponent<BoxCollider>().enabled = false;
    }

    public void EnemySpeedLow()
    {
        _animator.SetBool("Run", false);
        _speed = 0;
    }
    public void Run()
    {
        _speed = 2;
        _animator.SetBool("AttackOn", false);
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

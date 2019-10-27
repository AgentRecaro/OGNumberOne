using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcher : MonoBehaviour
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
    [SerializeField] private GameObject spawnArrow = null;
    //[SerializeField] private GameObject arrow = null;

    private void Start()
    {
        _player = GameObject.Find("Player");
        //_animator = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Enemydie();
        if (_distancePlay <= 10)
        {
            enemyDie = false;
            _player = GameObject.Find("Player");
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
        if (_distancePlay <= 7)
        {
            _animator.SetBool("AttackOn", true);
            _animator.SetBool("Run", false);
            _animator.SetBool("Idle",false);
            _speed = 0;
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
            GetComponent<EnemyArcher>().enabled = false;

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
            EventComboGame.Combo += 10;
        }
    }

    public void SpawnArrow()
    {
        Instantiate(Resources.Load("Arrow"), spawnArrow.transform.position,spawnArrow.transform.rotation);
    }
    

    public void Die()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        GetComponent<BoxCollider>().enabled = false;
       // GameObject.FindGameObjectWithTag("SwordEnemy").GetComponent<BoxCollider>().enabled = false;
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
}

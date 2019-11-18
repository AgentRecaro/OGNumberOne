using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{ 

    private bool enemyDie = false;
    private bool speedON = false;
    private bool FireOn = false;
    private bool PrisonOn = false;
    private bool BladeFireOn = false;
    private bool BladePrisonOn = false;
    [SerializeField] private GameObject _player;
    [SerializeField] private int _score = 0;
    [SerializeField] private float _distancePlay;
    [SerializeField] private Animator _animator = null;
    [SerializeField] private float _speed = 0;
    [SerializeField] private float _Hp;
    [SerializeField] private Vector3 directionToTarget;
    [SerializeField] private Quaternion rotationToTarget;
    [SerializeField] private float range = 0;
    [SerializeField] private Slider HpEnemy = null;
    [SerializeField] private GameObject SwordEnemy = null;
    [SerializeField] private float EXPPlayerInGame = 0;

    private void Start()
    {
        _player = GameObject.Find("Player");
        HpEnemy.maxValue = _Hp;
        //HpEnemy.direction = Slider.Direction.RightToLeft;
        speedON = true;
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
            SwordEnemy.GetComponent<BoxCollider>().enabled = false;
            EnemyCount.CountEnemydie = EnemyCount.CountEnemydie + 1;
            EnemyCount.CountEnemydieAll = EnemyCount.CountEnemydieAll + 1;
            GetComponent<Enemy>().enabled = false;
            LevelSyStemInGame.EXPInGame += EXPPlayerInGame;

        }

        if (PlayerMovement.Hp <= 0)
        {
            _animator.SetBool("Idle", true);
            _animator.SetBool("AttackOn", false);
            _animator.SetBool("Run", false);
            _speed = 0;
        }

        if (FireOn == true)
        {
            _Hp -= 0.15f * PlayerMovement.Damage * Time.deltaTime;
            TimeFireOff();
        }

        if (PrisonOn == true)
        {
            _Hp -= 0.3f * PlayerMovement.Damage * Time.deltaTime;
        }

        if (BladeFireOn == true)
        {
            _Hp -= 0.15f * PlayerMovement.Damage * Time.deltaTime;
            TimeBladeFireOff();
        }

        if (BladePrisonOn == true)
        {
            _Hp -= 0.3f * PlayerMovement.Damage * Time.deltaTime;
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

        if (EnemyAttack.gameObject.tag == "FireOrb")
        {
            //print("FireOrbAttackEnemy");
            FireOn = true;
        }

        if (EnemyAttack.gameObject.tag == "PrisonOrb")
        {
            //print("PrisonOrbAttackEnemy");
            PrisonOn = true;
        }

        if (EnemyAttack.gameObject.tag == "ShockOrb")
        {
            //print("ShockOrbAttackEnemy");
            _Hp -= 0.25f * PlayerMovement.Damage;
        }

        if (EnemyAttack.gameObject.tag == "IceOrb")
        {
            speedON = false;
            //print("IceOrbAttackEnemy");
            _speed = 0.5f;
        }
        
        if (EnemyAttack.gameObject.tag == "BladeFireCollider")
        {
            //print("BladeFireColliderAttackEnemy");
            BladeFireOn = true;
        }

        if (EnemyAttack.gameObject.tag == "BladePrisonCollider")
        {
            //print("BladePrisonColliderAttackEnemy");
            BladePrisonOn = true;
        }

        if (EnemyAttack.gameObject.tag == "BladeShockCollider")
        {
            //print("BladeShockColliderAttackEnemy");
            _Hp -= 0.25f * PlayerMovement.Damage;
        }

        if (EnemyAttack.gameObject.tag == "BladeIceCollider")
        {
            speedON = false;
            //print("BladeIceColliderAttackEnemy");
            _speed = 0.5f;
        }
    }

    IEnumerator TimeFireOff()
    {
        yield return  new WaitForSecondsRealtime(7);
        FireOn = false;
    }

    IEnumerator TimeBladeFireOff()
    {
        yield return  new WaitForSecondsRealtime(7);
        BladeFireOn = false;
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
        if (speedON == true)
        {
            _speed = 0;
        }
        _animator.SetBool("Run", false);
    }
    public void Run()
    {
        if (speedON == true)
        {
            _speed = 2;
        }
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

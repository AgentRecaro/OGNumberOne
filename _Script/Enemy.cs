using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public static float DamageFire;
    public static float DamagePoison;
    public static float DamageShock;
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
    [SerializeField] private float _Hp = 0;
    [SerializeField] private float DamageEnemyValue = 0;
    [SerializeField] private Vector3 directionToTarget;
    [SerializeField] private Quaternion rotationToTarget;
    [SerializeField] private float range = 0;
    [SerializeField] private Slider HpEnemy = null;
    [SerializeField] private GameObject SwordEnemy = null;
    [SerializeField] private float EXPPlayerInGame = 0;
    [SerializeField] private GameObject EffectEnemyDie = null;
    [SerializeField] private GameObject EffectAttackEnemy = null;
    [SerializeField] private GameObject PivotEffectAttack = null;
    [SerializeField] private GameObject PivotSpawnDamageText = null;
    [SerializeField] private GameObject FireEffect = null;
    [SerializeField] private GameObject PoisonEffect = null;
    [SerializeField] private GameObject ShockEffest = null;
    [SerializeField] private GameObject IceEffest = null;
    [SerializeField] private AudioClip SoundEnemyDie = null;
    [SerializeField] private AudioClip SoundEnemyHit = null;
    [SerializeField] private Animation AnimationCombo = null;


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
        PlayerMovement.DamageEnemy = DamageEnemyValue;
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
        if (_distancePlay <= 1)
        {
            _animator.SetBool("AttackOn", true);
            _animator.SetBool("Run", false);
            _animator.SetBool("Idle",false);
            speedON = false;
            _speed = 0;
        }
        else
        {
            _animator.SetBool("AttackOn", false);
            _animator.SetBool("Run", true);
            speedON = true;
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
            Destroy(gameObject, 4);
            _speed = 0;
            SwordEnemy.GetComponent<BoxCollider>().enabled = false;
            EnemyCount.CountEnemydie = EnemyCount.CountEnemydie + 1;
            EnemyCount.CountEnemydieAll = EnemyCount.CountEnemydieAll + 1;
            GetComponent<Enemy>().enabled = false;
            LevelSyStemInGame.EXPInGame += EXPPlayerInGame;
            GetComponent<AudioSource>().PlayOneShot(SoundEnemyDie);
            GetComponent<Collider>().enabled = false;
        }

        if (PlayerMovement.Hp <= 0)
        {
            _animator.SetBool("Idle", true);
            _animator.SetBool("AttackOn", false);
            _animator.SetBool("Run", false);
            _speed = 0;
        }

        DamageFire = PlayerMovement.Damage * 0.15f;
        DamagePoison = PlayerMovement.Damage * 0.3f;
        DamageShock = PlayerMovement.Damage * 0.25f;

        if (FireOn == true)
        {
            _Hp -= DamageFire * Time.deltaTime;
            Instantiate(Resources.Load("DamageCanvasFireOrb"), PivotSpawnDamageText.transform.position, Quaternion.identity,transform);
            TimeFireOff();
        }

        if (PrisonOn == true)
        {
            _Hp -= DamagePoison * Time.deltaTime;
            Instantiate(Resources.Load("DamageCanvasPoisonOrb"), PivotSpawnDamageText.transform.position, Quaternion.identity,transform);
        }

        if (BladeFireOn == true)
        {
            _Hp -= DamageFire * Time.deltaTime;
            Instantiate(Resources.Load("DamageCanvasFireOrb"), PivotSpawnDamageText.transform.position, Quaternion.identity,transform);
            //DamageText.DamageFireOn = true;
            TimeBladeFireOff();
        }

        if (BladePrisonOn == true)
        {
            _Hp -= DamagePoison* Time.deltaTime;
            Instantiate(Resources.Load("DamageCanvasPoisonOrb"), PivotSpawnDamageText.transform.position, Quaternion.identity,transform);
            //DamageText.DamagePoisonOn = true;
        }
    }

    public void OnTriggerEnter(Collider EnemyAttack)
    {
        GetComponent<AudioSource>().PlayOneShot(SoundEnemyHit);
        EventComboGame.Combo += 10;
        if (EnemyAttack.gameObject.tag == "Sword")
        {
            //GameObject.Find("Player1").GetComponent<Animator>().SetBool("AttackOff", true);
            //GameObject.Find("Player1").GetComponent<Animator>().SetBool("AttackOn", false);
            //GameObject.Find("Player1").GetComponent<Transform>().rotation = Quaternion.Euler(0,180,0);
            _Hp -= PlayerMovement.Damage;
            //print("Enemydie");
            //Destroy(gameObject);
            _GUI._Score += _score;
//            EventComboGame.Combo += 10;
            Instantiate(EffectAttackEnemy, PivotEffectAttack.transform.position, Quaternion.identity);
            DamageTextOn();
            SoundAttackOn();
            DamageText.DamageSwordOn = true;
            DamageText.DamageFireOn = false;
            DamageText.DamagePoisonOn = false;
            DamageText.DamageShockOn = false;
            AnimationCombo = GameObject.FindGameObjectWithTag("Combo").GetComponent<Animation>();
            AnimationCombo.Play("AnimationCombo");
        }

        if (EnemyAttack.gameObject.tag == "FireOrb")
        {
            //print("FireOrbAttackEnemy");
            FireOn = true;
            DamageText.DamageSwordOn = false;
            DamageText.DamageFireOn = true;
            DamageText.DamagePoisonOn = false;
            DamageText.DamageShockOn = false;
            Instantiate(EffectAttackEnemy, PivotEffectAttack.transform.position, Quaternion.identity);
            FireEffect.SetActive(true);
            SoundAttackOn();
        }

        if (EnemyAttack.gameObject.tag == "PrisonOrb")
        {
            //print("PrisonOrbAttackEnemy");
            PrisonOn = true;
            DamageText.DamageSwordOn = false;
            DamageText.DamageFireOn = false;
            DamageText.DamagePoisonOn = true;
            DamageText.DamageShockOn = false;
            Instantiate(EffectAttackEnemy, PivotEffectAttack.transform.position, Quaternion.identity);
            PoisonEffect.SetActive(true);
            SoundAttackOn();
        }

        if (EnemyAttack.gameObject.tag == "ShockOrb")
        {
            //print("ShockOrbAttackEnemy");
            DamageText.DamageSwordOn = false;
            DamageText.DamageFireOn = false;
            DamageText.DamagePoisonOn = false;
            DamageText.DamageShockOn = true;
            _Hp -= DamageShock;
            Instantiate(EffectAttackEnemy, PivotEffectAttack.transform.position, Quaternion.identity);
            Instantiate(Resources.Load("DamageCanvasShockOrb"), PivotSpawnDamageText.transform.position, Quaternion.identity,transform);
            ShockEffest.SetActive(true);
            SoundAttackOn();
        }

        if (EnemyAttack.gameObject.tag == "IceOrb")
        {
            speedON = false;
            //print("IceOrbAttackEnemy");
            _speed = 0.5f;
            Instantiate(EffectAttackEnemy, PivotEffectAttack.transform.position, Quaternion.identity);
            IceEffest.SetActive(true);
            SoundAttackOn();
        }
        
        if (EnemyAttack.gameObject.tag == "BladeFireCollider")
        {
            //print("BladeFireColliderAttackEnemy");
            BladeFireOn = true;
            Instantiate(EffectAttackEnemy, PivotEffectAttack.transform.position, Quaternion.identity);
            FireEffect.SetActive(true);
            SoundAttackOn();
            //DamageText.DamageFireOn = true;
        }

        if (EnemyAttack.gameObject.tag == "BladePrisonCollider")
        {
            //print("BladePrisonColliderAttackEnemy");
            BladePrisonOn = true;
            Instantiate(EffectAttackEnemy, PivotEffectAttack.transform.position, Quaternion.identity);
            PoisonEffect.SetActive(true);
            SoundAttackOn();
            //DamageText.DamagePoisonOn = true;
        }

        if (EnemyAttack.gameObject.tag == "BladeShockCollider")
        {
            //print("BladeShockColliderAttackEnemy");
            _Hp -= DamageShock * PlayerMovement.Damage;
            Instantiate(EffectAttackEnemy, PivotEffectAttack.transform.position, Quaternion.identity);
            ShockEffest.SetActive(true);
            SoundAttackOn();
            StartCoroutine(SpawnDamageTextShock());
            //DamageText.DamageShockOn = true;

        }

        if (EnemyAttack.gameObject.tag == "BladeIceCollider")
        {
            speedON = false;
            //print("BladeIceColliderAttackEnemy");
            _speed = 0.5f;
            Instantiate(EffectAttackEnemy, PivotEffectAttack.transform.position, Quaternion.identity);
            IceEffest.SetActive(true);
            SoundAttackOn();
        }

        if (EnemyAttack.gameObject.tag == "PivotColiderSkillComBoS")
        {
            _Hp -= AttackPlayer.DamageSkillComBoS;
            SpawnDamageSkillComBoS();
            SoundAttackOn();
            print("AttackEnemy");
        }
    }

    public void SpawnDamageSkillComBoS()
    {
        Instantiate(Resources.Load("DamageSkillComBOSCanvas"), PivotSpawnDamageText.transform.position, Quaternion.identity);
    }

    public void DamageTextOn()
    {
        Instantiate(Resources.Load("DamageCanvas"), PivotSpawnDamageText.transform.position, Quaternion.identity,transform);
    }

    public void EffectEnemyDieOn()
    {
        Instantiate(EffectEnemyDie, SwordEnemy.transform.position, Quaternion.identity);
    }

    public void SoundAttackOn()
    {
        Instantiate(Resources.Load("SpawnSound"), transform.position, Quaternion.identity,transform);
    }

    IEnumerator SpawnDamageTextShock()
    {
        yield return  new WaitForSecondsRealtime(0.2f);
        DamageText.DamageShockOn = true;
        Instantiate(Resources.Load("DamageCanvasShockOrb"), PivotSpawnDamageText.transform.position, Quaternion.identity,transform);
        yield return  new WaitForSecondsRealtime(0.5f);
        DamageText.DamageShockOn = false;
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

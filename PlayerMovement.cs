using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public GameObject _Player;
    public Animator _movement;
    public static int Hp = 100;
    private FixedJoystick _joystick;
    private float turnSmoothVelocity = 0.2f;
    private bool PlayerDie = false;
    private bool movementPlayer = true;
    //private float turnSmoothTime = 0.2f;
    [SerializeField] private GameObject _Sword = null;
    [SerializeField] private GameObject _Archer = null;
    [SerializeField] private GameObject _Arrow = null;
    [SerializeField] private float speedPlayer = 0;
    [SerializeField] private int DamageEnemy = 0;
    [SerializeField] private Slider HealthBarPlayer = null;
    [SerializeField] private Vector3 input;
    [SerializeField] private Transform target;
    [SerializeField] private float range = 0;
    //[SerializeField] private float distanceEnemy = 0;

    private void Start()
    {
        InvokeRepeating("UpdteTargetEnemy",0f,0.5f);
        HealthBarPlayer.maxValue = 100;
        HealthBarPlayer.value = Hp;
    }

    void UpdteTargetEnemy()
    { 
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
            else
            {
                target = null;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        _joystick = GameObject.FindWithTag("Joystick").GetComponent<FixedJoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        _PlayerDie();
        MovementPlayer();
        if (Hp <= 0)
        {
            speedPlayer = 0;
            _movement.SetBool("Die", true);
            PlayerDie = true;
        }
        HealthBarPlayer.value = Hp;
    }

    public void _AttackSword()
    {
        _movement.SetBool("Run",false);
        //_Sword.SetActive(true);
        _Archer.SetActive(false);
        if (_Sword.activeSelf == true)
        {
            _movement.SetBool("AttackSword", true);
            GameObject.Find("Sword").GetComponent<BoxCollider>().enabled = true;
            StartCoroutine(_time());
            _Archer.SetActive(false);
        }
        else
        {
            _movement.SetBool("InpactSword", true);
            _movement.SetBool("AttackSwordOn", true);
            _movement.SetBool("InpactArcher", false);
            _movement.SetBool("IdleF", false);
            _Sword.SetActive(true);
            GameObject.Find("Sword").GetComponent<BoxCollider>().enabled = true;
            StartCoroutine(_time());
        }
        TargetAttack();
        movementPlayer = false;
        //UpdteTargetEnemy();
    }

    public void _AttackArcher()
    {
        GameObject.Find("ArcherButton").GetComponent<Button>().enabled = false;
        _movement.SetBool("Run",false);
        //_Archer.SetActive(true);
        _Sword.SetActive(false);
        if (_Archer.activeSelf == true)
        {
            _movement.SetBool("AttackArcher", true);
            StartCoroutine(_time());
            StartCoroutine(_SpawnArrow());
            _Sword.SetActive(false);
        }
        else
        {
            _movement.SetBool("InpactArcher", true);
            _movement.SetBool("AttackArcherOn", true);
            _movement.SetBool("InpactSword", false);
            _movement.SetBool("IdleF", false);
            StartCoroutine(_SpawnArrow());
            _Archer.SetActive(true);
            StartCoroutine(_time());
        }
        movementPlayer = false;
        TargetAttack();
        //UpdteTargetEnemy();
    }

    IEnumerator _time()
    {
        yield return new WaitForSecondsRealtime(0.4f);
        _Sword.GetComponent<BoxCollider>().enabled = false;
        _movement.SetBool("AttackSword", false);
        _movement.SetBool("AttackArcher", false);
        _movement.SetBool("Idle", true);
        _movement.SetBool("IdleF", true);
        yield return new WaitForSecondsRealtime(0.3f);
        movementPlayer = true;
    }

    IEnumerator _SpawnArrow()
    {
        yield return new WaitForSecondsRealtime(0.7f);
        Instantiate(_Arrow,GameObject.Find("ArrowPivat").gameObject.transform.position,GameObject.Find("ArrowPivat").transform.rotation);
        GameObject.Find("ArcherButton").GetComponent<Button>().enabled = true;
        
    }

    private void OnTriggerEnter(Collider _Enemy)
    {
        if (_Enemy.gameObject.tag == "SwordEnemy")
        {
            Hp = Hp - DamageEnemy;
            Debug.Log("<color=red>PlayerDie GameOver</color>");
        }
    }

    private void _PlayerDie()
    {
        if (PlayerDie == false)
        {
            //input = new Vector3(_joystick.Horizontal, _joystick.Vertical);
            input = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        }
    }

    void TargetAttack()
    {
        // //enemy = GameObject.FindGameObjectWithTag("Enemy");
        
        Vector3 directionToTarget = target.transform.position - transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);
        Vector3 rotation = rotationToTarget.eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y,0f);
        //gameObject.transform.rotation = rotationToTarget;
    }

    void MovementPlayer()
    {
        if (movementPlayer == true)
        {
            Vector3 inputDir = input.normalized;
            if (inputDir != Vector3.zero)
            {
                float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;
                transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, speedPlayer * Time.deltaTime);
                transform.Translate(transform.forward * speedPlayer * Time.deltaTime, Space.World);
                _movement.SetBool("Run", true);
            }
            else
            {
                _movement.SetBool("Run", false);
                _movement.SetBool("Idle", true);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

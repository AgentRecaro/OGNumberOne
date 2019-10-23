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
    private bool roll = false;
    private float defospeed = 0;
    //private bool swordOn = false;
    //private float turnSmoothTime = 0.2f;
    [SerializeField] private GameObject _Sword = null;
    //[SerializeField] private GameObject _Archer = null;
    //[SerializeField] private GameObject _Arrow = null;
    [SerializeField] private float speedPlayer = 0;
    [SerializeField] private int DamageEnemy = 0;
    [SerializeField] private Slider HealthBarPlayer;
    [SerializeField] private Vector3 input;
    //[SerializeField] private float range = 0;
    //[SerializeField] private float distanceEnemy = 0;

    private void Start()
    {
        HealthBarPlayer.maxValue = 100;
        HealthBarPlayer.value = Hp;
        _movement = GameObject.FindGameObjectWithTag("Unicon").GetComponent<Animator>();
        HealthBarPlayer = GameObject.FindGameObjectWithTag("HPBar").GetComponent<Slider>();
        _Sword = GameObject.FindGameObjectWithTag("Sword");
        defospeed = speedPlayer;
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
        _movement.SetBool("Run", false);
       // _movement.SetBool("AttackSword", true);
       _movement.SetTrigger("Attack");
       StartCoroutine(_time());
        //_Sword.GetComponent<BoxCollider>().enabled = true;
        //if (_Sword.activeSelf == true)
        //{
            
        //}
        //else
        //{
            //_movement.SetBool("InpactSword", true);
            //_movement.SetBool("AttackSwordOn", true);
            //_movement.SetBool("InpactArcher", false);
            //_movement.SetBool("IdleF", false);
           // StartCoroutine(_time());
        //}
        movementPlayer = false;
    }
    
    public void _rollPlayer()
    {
        if (roll == true)
        {
            GameObject.Find("Roll").GetComponent<Button>().enabled = false;
            speedPlayer += 5;
            _movement.SetBool("Roll", true);
            StartCoroutine(_timeroll());
        }
    }

    IEnumerator _timeroll()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        _movement.SetBool("Roll", false);
        yield return new WaitForSecondsRealtime(0.4f);
        speedPlayer = defospeed;
        yield return new WaitForSecondsRealtime(0.2f);
        GameObject.Find("Roll").GetComponent<Button>().enabled = true;
    }

    IEnumerator _time()
    {
        yield return new WaitForSecondsRealtime(0.4f);
        //_movement.SetBool("AttackSword", false);
        //_movement.SetBool("Idle", true);
        //_movement.SetBool("IdleF", true);
        //yield return new WaitForSecondsRealtime(0.3f);
        //_Sword.GetComponent<BoxCollider>().enabled = false;
        movementPlayer = true;

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
            input = new Vector3(_joystick.Horizontal, _joystick.Vertical);
            //input = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        }
    }
    void MovementPlayer()
    {
        if (movementPlayer == true)
        {
            Vector3 inputDir = input.normalized;
            if (inputDir != Vector3.zero)
            {
                float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;
                transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation,
                                            ref turnSmoothVelocity, 0 * Time.deltaTime);
                                            transform.Translate(transform.forward * speedPlayer * Time.deltaTime, Space.World);
                _movement.SetBool("Run", true);
                roll = true;
            }
            else
            {
                roll = false;
                _movement.SetBool("Run", false);
                _movement.SetBool("Idle", true);
            }
        }
    }
}



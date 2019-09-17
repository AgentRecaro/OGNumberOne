using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject _Player;
    public Animator _movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void _AttackLeft()
    {
        _movement.SetBool("AttackOff", false);
        _Player.transform.rotation = Quaternion.Euler(0,270,0);
        _movement.SetBool("AttackOn", true);
        StartCoroutine(_time());
    }

    public void _AttackRight()
    {
        _movement.SetBool("AttackOff", false);
        _Player.transform.rotation = Quaternion.Euler(0,90,0);
        _movement.SetBool("AttackOn", true);
        StartCoroutine(_time());
    }

    IEnumerator _time()
    {
        yield return new WaitForSecondsRealtime(0.8f);
        _movement.SetBool("AttackOff", true);
        _movement.SetBool("AttackOn", false);
        _Player.transform.rotation = Quaternion.Euler(0,180,0);
    }
}

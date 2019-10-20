using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _Sword;
    [SerializeField] private Animator movement;
    private void Start()
    { 
        _Sword = GameObject.FindGameObjectWithTag("Sword");
        movement = GameObject.FindGameObjectWithTag("Unicon").GetComponent<Animator>();
    }

    public void SwordOn()
    {
        _Sword.GetComponent<BoxCollider>().enabled = true;
    }

    public void SwordOff()
    {
        _Sword.GetComponent<BoxCollider>().enabled = false;
    }

    public void AtteckswordOff()
    {
        movement.SetBool("AttackSword", false);
    }

    public void Quickroll()
    {
        GameObject.Find("Roll").GetComponent<Button>().enabled = true;
    }
}

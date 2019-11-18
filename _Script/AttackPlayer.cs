using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _Sword;
    [SerializeField] private GameObject FireBladeCollider = null;
    [SerializeField] private GameObject PrisonBladeCollider = null;
    [SerializeField] private GameObject ShockBladeCollider = null;
    [SerializeField] private GameObject IceBladeCollider = null;
    [SerializeField] private Animator movement;
    private void Start()
    { 
        _Sword = GameObject.FindGameObjectWithTag("Sword");
        movement = GameObject.FindGameObjectWithTag("Unicon").GetComponent<Animator>();
    }

    private void Update()
    {
//        FireBladeCollider = GameObject.FindGameObjectWithTag("BladeFireCollider");
//        PrisonBladeCollider = GameObject.FindGameObjectWithTag("BladePrisonCollider");
//        ShockBladeCollider = GameObject.FindGameObjectWithTag("BladeShockCollider");
//        IceBladeCollider = GameObject.FindGameObjectWithTag("BladeIceCollider");
    }

    public void SwordOn()
    {
        _Sword.GetComponent<BoxCollider>().enabled = true;
        FireBladeCollider.GetComponent<BoxCollider>().enabled = true;
        PrisonBladeCollider.GetComponent<BoxCollider>().enabled = true;
        ShockBladeCollider.GetComponent<BoxCollider>().enabled = true;
        IceBladeCollider.GetComponent<BoxCollider>().enabled = true;
    }

    public void SwordOff()
    {
        _Sword.GetComponent<BoxCollider>().enabled = false;
        FireBladeCollider.GetComponent<BoxCollider>().enabled = false;
        PrisonBladeCollider.GetComponent<BoxCollider>().enabled = false;
        ShockBladeCollider.GetComponent<BoxCollider>().enabled = false;
        IceBladeCollider.GetComponent<BoxCollider>().enabled = false;
    }

    public void AtteckswordOff()
    {
       // movement.SetBool("AttackSword", false);
    }

    public void Quickroll()
    {
        GameObject.Find("Roll").GetComponent<Button>().enabled = true;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackPlayer : MonoBehaviour
{
    public static bool FireBladeOn = false;
    public static bool PoisonBladeOn = false;
    public static bool ShockBladeOn = false;
    public static bool IceBladeOn = false;
    public static float DamageSkillComBoS = 500;
    [SerializeField] private GameObject _Sword;
    [SerializeField] private GameObject FireBladeCollider = null;
    [SerializeField] private GameObject PrisonBladeCollider = null;
    [SerializeField] private GameObject ShockBladeCollider = null;
    [SerializeField] private GameObject IceBladeCollider = null;
    [SerializeField] private Animator movement;
    [SerializeField] private AudioClip AttackMiss = null;
    [SerializeField] private AudioClip SoundEffectSkillComBoS = null;
    [SerializeField] private GameObject PivotEffectSkillComBos = null;
    [SerializeField] private GameObject GuitarSkillComBoS = null;
    [SerializeField] private GameObject GuitarPlayer = null;
    private void Start()
    { 
        _Sword = GameObject.FindGameObjectWithTag("Sword");
        movement = GameObject.FindGameObjectWithTag("Unicon").GetComponent<Animator>();
    }

    private void Update()
    {
        if (FireBladeOn == true)
        {
            FireBladeCollider = GameObject.FindGameObjectWithTag("BladeFireCollider");
        }
        else
        {
            FireBladeCollider = GameObject.FindGameObjectWithTag("ColiderBlade");
        }

        if (PoisonBladeOn == true)
        {
            PrisonBladeCollider = GameObject.FindGameObjectWithTag("BladePrisonCollider");
        }
        else
        {
            PrisonBladeCollider = GameObject.FindGameObjectWithTag("ColiderBlade");
        }

        if (ShockBladeOn == true)
        {
            ShockBladeCollider = GameObject.FindGameObjectWithTag("BladeShockCollider");
        }
        else
        {
            ShockBladeCollider = GameObject.FindGameObjectWithTag("ColiderBlade");
        }

        if (IceBladeOn == true)
        {
            IceBladeCollider = GameObject.FindGameObjectWithTag("BladeIceCollider");
        }
        else
        {
            IceBladeCollider = GameObject.FindGameObjectWithTag("ColiderBlade");
        }
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

    public void attackMissOn()
    {
        GetComponent<AudioSource>().PlayOneShot(AttackMiss);
    }

    public void SkillComBoSOn()
    {
        PlayerMovement.speedPlayer = 0;
        PivotEffectSkillComBos.SetActive(true);
        GuitarSkillComBoS.SetActive(true);
        GuitarPlayer.SetActive(false);
        GetComponent<AudioSource>().PlayOneShot(SoundEffectSkillComBoS);
    }

    public void SkillComBoSOff()
    {
        PlayerMovement.MomentSkillComBoSOn = false;
        PlayerMovement.speedPlayer = PlayerMovement.defospeed;
        PivotEffectSkillComBos.SetActive(false);
        GuitarSkillComBoS.SetActive(false);
        GuitarPlayer.SetActive(true);
    }

    public void DamageSkillComBoSOn()
    {
        PivotEffectSkillComBos.GetComponent<Collider>().enabled = true;
        print("ClidertOn");
    }
    
    public void DamageSkillComBoSOff()
    {
        PivotEffectSkillComBos.GetComponent<Collider>().enabled = false;
        print("ClidertOff");
    }
    
}

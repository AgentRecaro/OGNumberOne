using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using System.Linq;

public class spawnSelectabilitySystem : MonoBehaviour
{
    public static bool ButtonFireBlade = true;
    public static bool ButtonPrisonBlade = true;
    public static bool ButtonShockBlade = true;
    public static bool ButtonIceBlade = true;
    public static bool ButtonFireOrb = true;
    public static bool ButtonPrisonOrb = true;
    public static bool ButtonShockOrb = true;
    public static bool ButtonIceOrb = true;
    public static float Glory;
    public static bool CanvasSkill = false;
    public static bool EffectFireBlade = false;
    public static bool EffectPoisonBlade  = false;
    public static bool EffectShockBlade = false;
    public static bool EffectIceBlade = false;
    public static bool EffectFireOrb = false;
    public static bool EffectPrisonOrb = false;
    public static bool EffectShockOrb = false;
    public static bool EffectIceOrb = false;
    private int Number;
    [SerializeField] private GameObject[] ButtonSkill = null;
    //[SerializeField] private GameObject CanvasButton = null;
    [SerializeField] private Transform[] ButtonPivot = null;
    [SerializeField] private List<int> NumberList = new List<int>();
    [SerializeField] private List<GameObject> gameObjectsList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        SpawnEffectSkill();
        SystemspawnButtonFX();
        if (Glory == 1)
        {
            GetComponent<Canvas>().enabled = true;
            Glory = 0;
        }
        else
        {
            GetComponent<Canvas>().enabled = false;
        }
        
//        ButtonFireBlade = PlayerPrefs.HasKey("ButtonFireBlade");
//        PlayerPrefs.GetString("ButtonFireBlade","FireOn");
//        print("FireBladeOn" +ButtonFireBlade);
        ButtonSkill = new GameObject[]
        {
            GameObject.FindGameObjectWithTag("ButtonDamageUp"), 
            GameObject.FindGameObjectWithTag("ButtonCritUp"),
            GameObject.FindGameObjectWithTag("ButtonCrit chance"),
            GameObject.FindGameObjectWithTag("ButtonHPUp"),
            GameObject.FindGameObjectWithTag("ButtonAttackSpeedUp"),
            GameObject.FindGameObjectWithTag("ButtonExtra Life"),
            GameObject.FindGameObjectWithTag("ButtonSmart"),
            GameObject.FindGameObjectWithTag("ButtonFire Blade"),
            GameObject.FindGameObjectWithTag("ButtonPrison Blade"),
            GameObject.FindGameObjectWithTag("ButtonShock Blade"),
            GameObject.FindGameObjectWithTag("ButtonIce Blade"),
            GameObject.FindGameObjectWithTag("ButtonFire Orb"),
            GameObject.FindGameObjectWithTag("ButtonPrison Orb"),
            GameObject.FindGameObjectWithTag("ButtonShock Orb"),
            GameObject.FindGameObjectWithTag("ButtonIce Orb"),
        };
//        Instantiate(Resources.Load("SpawnSkill"),
//            GameObject.FindGameObjectWithTag("CanvasRandomSkill").transform.position, Quaternion.identity,
//            GameObject.FindGameObjectWithTag("CanvasRandomSkill").transform);
        
        NumberList = new List<int>(new int[ButtonPivot.Length]);
        for (int i = 0; i < ButtonPivot.Length; i++)
        {
            Number = Random.Range(0, (ButtonSkill.Length));
            while (NumberList.Contains(Number))
            {
                Number = Random.Range(0, (ButtonSkill.Length));
            }

            NumberList[i] = Number;
            ButtonSkill[NumberList[i]].GetComponent<Transform>().position = ButtonPivot[i].GetComponent<Transform>().position;
            
//                        Instantiate(ButtonSkill[(NumberList[i] - 1)], ButtonPivot[i].transform.position, Quaternion.identity,
//                GameObject.FindGameObjectWithTag("SpawnSkill").transform);
//            ButtonSkill[(NumberList[i] - 1)].SetActive(true);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
//        gameObjectsList = new List<GameObject>(ButtonSkill);
//        gameObjectsList.RemoveAll(gameObject => gameObject == null);
//        ButtonSkill = gameObjectsList.ToArray();
        ButtonSkill = ButtonSkill.Where(x => x != null).ToArray();
    }

    public void Reset()
    {
//        Instantiate(Resources.Load("SpawnSkill"),
//            GameObject.FindGameObjectWithTag("CanvasRandomSkill").transform.position, Quaternion.identity,
//            GameObject.FindGameObjectWithTag("CanvasRandomSkill").transform);
        
        NumberList = new List<int>(new int[ButtonPivot.Length]);
        for (int i = 0; i < ButtonPivot.Length; i++)
        {
            Number = Random.Range(0, (ButtonSkill.Length));
            while (NumberList.Contains(Number))
            {
                Number = Random.Range(0, (ButtonSkill.Length));
            }

            NumberList[i] = Number;
//            Instantiate(ButtonSkill[(NumberList[i] - 1)], ButtonPivot[i].transform.position, Quaternion.identity,
//                GameObject.FindGameObjectWithTag("SpawnSkill").transform);
            ButtonSkill[NumberList[i]].GetComponent<Transform>().position =
                ButtonPivot[i].GetComponent<Transform>().position;
        }
    }

    void SystemspawnButtonFX()
    {
        if (ButtonFireBlade == true)
        {
            Instantiate(Resources.Load("ButtonFire Blade"),
                GameObject.FindGameObjectWithTag("SpawnButtonFx").transform.position, Quaternion.identity,
                GameObject.FindGameObjectWithTag("SpawnButtonFx").transform);
            GameObject.FindGameObjectWithTag("ButtonFire Blade").GetComponent<Button>().onClick.AddListener(SpawnFireBladeOn);
        }
        
        if (ButtonPrisonBlade == true)
        {
            Instantiate(Resources.Load("ButtonPrison Blade"),
                GameObject.FindGameObjectWithTag("SpawnButtonFx").transform.position, Quaternion.identity,
                GameObject.FindGameObjectWithTag("SpawnButtonFx").transform);
            GameObject.FindGameObjectWithTag("ButtonPrison Blade").GetComponent<Button>().onClick.AddListener(SpawnPoisonBladeOn);
        }
        
        if (ButtonShockBlade == true)
        {
            Instantiate(Resources.Load("ButtonShock Blade"),
                GameObject.FindGameObjectWithTag("SpawnButtonFx").transform.position, Quaternion.identity,
                GameObject.FindGameObjectWithTag("SpawnButtonFx").transform);
            GameObject.FindGameObjectWithTag("ButtonShock Blade").GetComponent<Button>().onClick.AddListener(SpawnShockBladeOn);
        }
        
        if (ButtonIceBlade == true)
        {
            Instantiate(Resources.Load("ButtonIce Blade"),
                GameObject.FindGameObjectWithTag("SpawnButtonFx").transform.position, Quaternion.identity,
                GameObject.FindGameObjectWithTag("SpawnButtonFx").transform);
            GameObject.FindGameObjectWithTag("ButtonIce Blade").GetComponent<Button>().onClick.AddListener(SpawnIceBlade);
        }
        
        if (ButtonFireOrb == true)
        {
            Instantiate(Resources.Load("ButtonFire Orb"),
                GameObject.FindGameObjectWithTag("SpawnButtonFx").transform.position, Quaternion.identity,
                GameObject.FindGameObjectWithTag("SpawnButtonFx").transform);
            GameObject.FindGameObjectWithTag("ButtonFire Orb").GetComponent<Button>().onClick.AddListener(SpawnFireOrbOn);
        }
        
        if (ButtonPrisonOrb == true)
        {
            Instantiate(Resources.Load("ButtonPrison Orb"),
                GameObject.FindGameObjectWithTag("SpawnButtonFx").transform.position, Quaternion.identity,
                GameObject.FindGameObjectWithTag("SpawnButtonFx").transform);
            GameObject.FindGameObjectWithTag("ButtonPrison Orb").GetComponent<Button>().onClick.AddListener(SpawnPoisonOrbOn);
        }
        
        if (ButtonShockOrb == true)
        {
            Instantiate(Resources.Load("ButtonShock Orb"),
                GameObject.FindGameObjectWithTag("SpawnButtonFx").transform.position, Quaternion.identity,
                GameObject.FindGameObjectWithTag("SpawnButtonFx").transform);
            GameObject.FindGameObjectWithTag("ButtonShock Orb").GetComponent<Button>().onClick.AddListener(SpawnShockOrbOn);
        }
        
        if (ButtonIceOrb == true)
        {
            Instantiate(Resources.Load("ButtonIce Orb"),
                GameObject.FindGameObjectWithTag("SpawnButtonFx").transform.position, Quaternion.identity,
                GameObject.FindGameObjectWithTag("SpawnButtonFx").transform);
            GameObject.FindGameObjectWithTag("ButtonIce Orb").GetComponent<Button>().onClick.AddListener(SpawnIceOrbOn);
        }
    }

    IEnumerator TimeSpawnSkill()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        for (int i = 0; i < ButtonSkill.Length; i++)
        {
            ButtonSkill[i].GetComponent<Transform>().position = GameObject.FindGameObjectWithTag("SpawnButtonFx")
                .GetComponent<Transform>().position;
        }

//        ButtonFireBlade = true;
//        ButtonPrisonBlade = true;
//        ButtonShockBlade = true;
//        ButtonIceBlade = true;
//        ButtonFireOrb = true;
//        ButtonPrisonOrb= true;
//        ButtonShockOrb = true;
//        ButtonIceOrb = true;

        yield return new WaitForSecondsRealtime(0.5f);
        Reset();
        print("Reset");
    }

    public void DamageUpOn()
    {
        PlayerMovement.Damage += 5;
        CanvasButtonOff();
        StartCoroutine(TimeSpawnSkill());
    }

    public void CritUpOn()
    {
        CanvasButtonOff();
        StartCoroutine(TimeSpawnSkill());
    }

    public void CritChance()
    {
        CanvasButtonOff();
        StartCoroutine(TimeSpawnSkill());
    }

    public void HpUpOn()
    {
        PlayerMovement.Hp += 100;
        PlayerMovement.MaxHp += 100;
        CanvasButtonOff();
        StartCoroutine(TimeSpawnSkill());
    }

    public void AttackSpeedUPOn()
    {
        PlayerMovement.speedPlayer += 0.5f;
        CanvasButtonOff();
        StartCoroutine(TimeSpawnSkill());
    }

    public void ExtraLife()
    {
        CanvasButtonOff();
        StartCoroutine(TimeSpawnSkill());
    }

    public void SmartOn()
    {
        LevelSyStemInGame.EXPInGame += 0.5f;
        CanvasButtonOff();
        StartCoroutine(TimeSpawnSkill());
    }

    public void SpawnFireBladeOn()
    {
        CanvasButtonOff();
        ButtonFireBlade = false;
        EffectFireBlade = true;
        Destroy( GameObject.FindGameObjectWithTag("ButtonFire Blade"), 1);

        Instantiate(Resources.Load("FireBladeCollider"),
            GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.position,
            GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.rotation,
            GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform);
        Instantiate(Resources.Load("FireBlade"),
            GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.position,
            GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.rotation,
            GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform);
        
        if (ButtonFireBlade == false)
        {
            StartCoroutine(TimeSpawnSkill());
        }
    }

    public void SpawnPoisonBladeOn()
    {
        CanvasButtonOff();
        ButtonPrisonBlade = false;
        EffectPoisonBlade = true;
        Destroy( GameObject.FindGameObjectWithTag("ButtonPrison Blade"), 1);
        
        Instantiate(Resources.Load("PrisonBladeCollider"),
            GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.position,
            GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.rotation,
            GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform);
        Instantiate(Resources.Load("PrisonBlade"),
            GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.position,
            GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.rotation,
            GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform);
        
        if (ButtonPrisonBlade == false)
        {
            StartCoroutine(TimeSpawnSkill());
        }
    }

    public void SpawnShockBladeOn()
    {
        CanvasButtonOff();
        ButtonShockBlade = false;
        EffectShockBlade = true;
        Destroy( GameObject.FindGameObjectWithTag("ButtonShock Blade"), 1);
        
        Instantiate(Resources.Load("ShockBladeCollider"),
            GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.position,
            GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.rotation,
            GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform);
        Instantiate(Resources.Load("ShockBlade"),
            GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.position,
            GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.rotation,
            GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform);
        
        if (ButtonShockBlade == false)
        {
            StartCoroutine(TimeSpawnSkill());
        }

    }

    public void SpawnIceBlade()
    {
        CanvasButtonOff();
        ButtonIceBlade = false;
       EffectIceBlade = true;
       Destroy( GameObject.FindGameObjectWithTag("ButtonIce Blade"), 1);
       
       Instantiate(Resources.Load("IceBladeCollider"),
           GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.position,
           GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.rotation,
           GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform);
       Instantiate(Resources.Load("IceBlade"),
           GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.position,
           GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.rotation,
           GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform);
       
       if (ButtonIceBlade == false)
       {
           StartCoroutine(TimeSpawnSkill());
       }
    }

    public void SpawnFireOrbOn()
    {
        CanvasButtonOff();
        ButtonFireOrb = false;
        EffectFireOrb = true;
        Destroy( GameObject.FindGameObjectWithTag("ButtonFire Orb"), 1);
        
        Instantiate(Resources.Load("PivotFireOrb"),
            GameObject.FindGameObjectWithTag("PivotSpawnOrb").transform.position, Quaternion.identity,
            GameObject.FindGameObjectWithTag("PivotSpawnOrb").transform);
        
        if (ButtonFireOrb == false)
        {
            StartCoroutine(TimeSpawnSkill());
        }
    }

    public void SpawnPoisonOrbOn()
    {
        CanvasButtonOff();
        ButtonPrisonOrb = false;
        EffectPrisonOrb = true;
        Destroy( GameObject.FindGameObjectWithTag("ButtonPrison Orb"), 1);
        
        Instantiate(Resources.Load("PivotPrisonOrb"),
            GameObject.FindGameObjectWithTag("PivotSpawnOrb").transform.position, Quaternion.identity,
            GameObject.FindGameObjectWithTag("PivotSpawnOrb").transform);
        
        if (ButtonPrisonOrb == false)
        {
            StartCoroutine(TimeSpawnSkill());
        }
    }

    public void SpawnShockOrbOn()
    {
        CanvasButtonOff();
        ButtonShockOrb = false;
        EffectShockOrb = true;
        Destroy( GameObject.FindGameObjectWithTag("ButtonShock Orb"), 1);
        
        Instantiate(Resources.Load("PivotShockOrb"),
            GameObject.FindGameObjectWithTag("PivotSpawnOrb").transform.position, Quaternion.identity,
            GameObject.FindGameObjectWithTag("PivotSpawnOrb").transform);
        
        if (ButtonShockOrb == false)
        {
            StartCoroutine(TimeSpawnSkill());
        }
    }

    public void SpawnIceOrbOn()
    {
        CanvasButtonOff();
        ButtonIceOrb = false;
        EffectIceOrb = true;
        Destroy( GameObject.FindGameObjectWithTag("ButtonIce Orb"),1);
        
        Instantiate(Resources.Load("PivotIceOrb"),
            GameObject.FindGameObjectWithTag("PivotSpawnOrb").transform.position, Quaternion.identity,
            GameObject.FindGameObjectWithTag("PivotSpawnOrb").transform);
        
        if (ButtonIceOrb == false)
        {
            StartCoroutine(TimeSpawnSkill());
        }
    }

    void CanvasButtonOff()
    {
        //CanvasButton.GetComponent<Canvas>().enabled = false;
        GetComponent<Canvas>().enabled = false;
        DeleteSpawnSkill();
        Time.timeScale = 1f;
    }

    void DeleteSpawnSkill()
    {
        Destroy(GameObject.FindGameObjectWithTag("SpawnSkill"));
    }

    void SpawnEffectSkill()
    {
        if (EffectFireBlade == true)
        {
            Instantiate(Resources.Load("FireBladeCollider"),
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.position,
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.rotation,
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform);
            Instantiate(Resources.Load("FireBlade"),
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.position,
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.rotation,
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform);
        }
        if (EffectPoisonBlade == true)
        {
            Instantiate(Resources.Load("PrisonBladeCollider"),
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.position,
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.rotation,
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform);
            Instantiate(Resources.Load("PrisonBlade"),
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.position,
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.rotation,
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform);
        }
        if (EffectShockBlade == true)
        {
            Instantiate(Resources.Load("ShockBladeCollider"),
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.position,
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.rotation,
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform);
            Instantiate(Resources.Load("ShockBlade"),
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.position,
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.rotation,
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform);
        }
        if (EffectIceBlade == true)
        {
            Instantiate(Resources.Load("IceBladeCollider"),
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.position,
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.rotation,
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform);
            Instantiate(Resources.Load("IceBlade"),
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.position,
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform.rotation,
                GameObject.FindGameObjectWithTag("PivotSpawnBladeCollider").transform);
        }
        if (EffectFireOrb == true)
        {
            Instantiate(Resources.Load("PivotFireOrb"),
                GameObject.FindGameObjectWithTag("PivotSpawnOrb").transform.position, Quaternion.identity,
                GameObject.FindGameObjectWithTag("PivotSpawnOrb").transform);
        }
        if (EffectPrisonOrb == true)
        {
            Instantiate(Resources.Load("PivotPrisonOrb"),
                GameObject.FindGameObjectWithTag("PivotSpawnOrb").transform.position, Quaternion.identity,
                GameObject.FindGameObjectWithTag("PivotSpawnOrb").transform);
        }
        if (EffectShockOrb == true)
        {
            Instantiate(Resources.Load("PivotShockOrb"),
                GameObject.FindGameObjectWithTag("PivotSpawnOrb").transform.position, Quaternion.identity,
                GameObject.FindGameObjectWithTag("PivotSpawnOrb").transform);
        }
        if (EffectIceOrb == true)
        {
            Instantiate(Resources.Load("PivotIceOrb"),
                GameObject.FindGameObjectWithTag("PivotSpawnOrb").transform.position, Quaternion.identity,
                GameObject.FindGameObjectWithTag("PivotSpawnOrb").transform);
        }
    }
}

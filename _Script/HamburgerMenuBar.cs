using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HamburgerMenuBar : MonoBehaviour
{
    public static bool ShowFPS;
    public static int MoneyBear;
    public static int EXPValue;
    public static float XGold;
    public static float XEXP;
    public MainMenu Addmoney;
    public LevelSystem AddEXP;
    public static bool AdReward = false;
    private bool menuBar = false;
    private bool TextReWrad = false;
    [SerializeField] private Text Money = null;
    [SerializeField] private Text EXP = null;
    [SerializeField] private GameObject Menubar = null;
    [SerializeField] private GameObject FPS = null;
    [SerializeField] private GameObject ButtonResume = null;
    [SerializeField] private GameObject ButtonAdReward = null;
    [SerializeField] private GameObject ButtonShare = null;
    [SerializeField] private Image UiHamburgerMenubar = null;
    [SerializeField] private Sprite UiYouDead = null;
    [SerializeField] private Sprite UiPause = null;
    [SerializeField] private Sprite UiComplete = null;

    private void Start()
    {
        //Application.targetFrameRate = 300;
        FPS = GameObject.Find("FPS");
        Menubar.SetActive(false);
        ButtonAdReward.SetActive(false);
        ButtonShare.SetActive(false);
        AdReward = false;
    }

    private void Update()
    {
        
        if (PlayerMovement.Hp <= 0)
        {
            FPS.GetComponent<Text>().enabled = false;
            Money.GetComponent<Text>().enabled = true;
            EXP.GetComponent<Text>().enabled = true;
            if (TextReWrad == false)
            {
                EXPValue = EnemyCount.CountEnemydieAll * (int)XEXP;
                MoneyBear = EnemyCount.CountEnemydieAll * (int)XGold;
                EXP.text = "" + EXPValue;
                Money.text = "" + MoneyBear;
            }
            
            menuBar = true;
            //Time.timeScale = 0f;
            Menubar.SetActive(true);
            ButtonAdReward.SetActive(true);
            ButtonShare.SetActive(true);
            ShowFPS = false;
            UiHamburgerMenubar.sprite = UiYouDead;
        }

        if (AdReward == true)
        {
//            EXPValue = EXPValue * 2;
            MoneyBear = MoneyBear * 2;
            EXP.text = "" + EXPValue;
            Money.text = "" + MoneyBear;
            ButtonAdReward.SetActive(false);
            AdReward = false;
            TextReWrad = true;
        }

        if (EventComplete.CompleteTrue == true)
        {
            EXPValue = EnemyCount.CountEnemydieAll * (int)XEXP;
            MoneyBear = EnemyCount.CountEnemydieAll * (int)XGold;
            FPS.GetComponent<Text>().enabled = false;
            Money.GetComponent<Text>().enabled = true;
            EXP.GetComponent<Text>().enabled = true;
            EXP.text = "" + EXPValue;
            Money.text = "" + MoneyBear;
            menuBar = true;
            Menubar.SetActive(true);
            ButtonShare.SetActive(true);
            ShowFPS = false;
            UiHamburgerMenubar.sprite = UiComplete;
        }

        if (ShowFPS == true)
        {
            FPS.GetComponent<Text>().enabled = true;
        }
        else
        {
            FPS.GetComponent<Text>().enabled = false;
        }
    }

    public void HamburgerMenu()
    {
        UiHamburgerMenubar.sprite = UiPause;
        if (menuBar == true)
        {
            //FPS.GetComponent<Text>().enabled = true;
            if (SettingSystem.showFPSvalue == 1)
            {
                ShowFPS = true;
            }
            menuBar = false;
            Time.timeScale = 1f;
            Menubar.SetActive(false);
            ButtonResume.SetActive(false);
        }
        else 
        {
            //FPS.GetComponent<Text>().enabled = false;
            ShowFPS = false;
            menuBar = true;
            Time.timeScale = 0f;
            Menubar.SetActive(true);
            ButtonResume.SetActive(true);
        }
    }

    public void _Quit()
    {
        Application.Quit();
        print("Quit");
    }

    public void Mainmenu()
    {
        Addmoney.AddMoney(MoneyBear);
        AddEXP.AddEXP(EXPValue);
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
        EnemyCount.CountEnemydie = 0;
        PlayerMovement.Hp = PlayerMovement.MaxHp;
        PlayerPrefs.SetInt("MoneyBear",MainMenu.moneyBear);
        EventComboGame.SaveNameCombo = 0;
        EventComboGame.Combo = 0;
        SpawnCombo.spawn = false;
        Destroy(GameObject.FindGameObjectWithTag("Combo"));
        spawnSelectabilitySystem.ButtonFireBlade = true;
        spawnSelectabilitySystem.ButtonPrisonBlade = true;
        spawnSelectabilitySystem.ButtonShockBlade = true;
        spawnSelectabilitySystem.ButtonIceBlade = true;
        spawnSelectabilitySystem.ButtonFireOrb = true;
        spawnSelectabilitySystem.ButtonPrisonOrb = true;
        spawnSelectabilitySystem.ButtonShockOrb = true;
        spawnSelectabilitySystem.ButtonIceOrb = true;

        spawnSelectabilitySystem.EffectFireBlade = false;
        spawnSelectabilitySystem.EffectPoisonBlade = false;
        spawnSelectabilitySystem.EffectShockBlade = false;
        spawnSelectabilitySystem.EffectIceBlade = false;
        spawnSelectabilitySystem.EffectFireOrb = false;
        spawnSelectabilitySystem.EffectPrisonOrb = false;
        spawnSelectabilitySystem.EffectShockOrb = false;
        spawnSelectabilitySystem.EffectIceOrb = false;

        AttackPlayer.FireBladeOn = false;
        AttackPlayer.PoisonBladeOn = false;
        AttackPlayer.ShockBladeOn = false;
        AttackPlayer.IceBladeOn = false;

        EventComboGame.DamageD = false;
        EventComboGame.DamageC = false;
        EventComboGame.DamageB = false;
        EventComboGame.DamageA = false;
        EventComboGame.DamageS = false;
    }
}

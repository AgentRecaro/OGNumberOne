using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HamburgerMenuBar : MonoBehaviour
{
    public static int MoneyBear;
    public static int EXPValue;
    public static float XGold;
    public static float XEXP;
    public MainMenu Addmoney;
    public LevelSystem AddEXP;
    private bool menuBar = false;
    [SerializeField] private Text Money = null;
    [SerializeField] private Text EXP = null;
    [SerializeField] private GameObject Menubar = null;
    [SerializeField] private GameObject FPS = null;
    

    private void Start()
    {
        Application.targetFrameRate = 300;
        FPS = GameObject.Find("FPS");
        Menubar.SetActive(false);
    }

    private void Update()
    {
        
        if (PlayerMovement.Hp <= 0)
        {
            EXPValue = EnemyCount.CountEnemydieAll * (int)XEXP;
            MoneyBear = EnemyCount.CountEnemydieAll * (int)XGold;
            FPS.GetComponent<Text>().enabled = false;
            Money.GetComponent<Text>().enabled = true;
            EXP.GetComponent<Text>().enabled = true;
            EXP.text = "EXP: " + EXPValue + "  X" + XEXP;
            Money.text = "" + MoneyBear + "  X" + XGold;
            menuBar = true;
            //Time.timeScale = 0f;
            Menubar.SetActive(true);
        }
    }

    public void HamburgerMenu()
    {
        if (menuBar == true)
        {
            FPS.GetComponent<Text>().enabled = true;
            menuBar = false;
            Time.timeScale = 1f;
            Menubar.SetActive(false);
        }
        else 
        {
            FPS.GetComponent<Text>().enabled = false;
            menuBar = true;
            Time.timeScale = 0f;
            Menubar.SetActive(true);
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
        Destroy(GameObject.FindGameObjectWithTag("Combo"));
    }
}

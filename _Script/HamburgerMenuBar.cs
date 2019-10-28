using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HamburgerMenuBar : MonoBehaviour
{
    private bool menuBar = false;
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
            FPS.GetComponent<Text>().enabled = false;
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
        
    public void RestartGame()
    {
        SceneManager.LoadScene("Stage_01");
        Time.timeScale = 1f;
        PlayerMovement.Hp = 100;
        EnemyCount.CountEnemydie = 0;
    }

    public void _Quit()
    {
        Application.Quit();
        print("Quit");
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
        EnemyCount.CountEnemydie = 0;
        PlayerMovement.Hp = 100;
    }
}

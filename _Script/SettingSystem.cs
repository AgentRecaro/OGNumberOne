using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingSystem : MonoBehaviour
{
    public static int showFPSvalue;
    [SerializeField] private Toggle showFPS = null;
    // Start is called before the first frame update
    void Start()
    {
        showFPSvalue = PlayerPrefs.GetInt("ShowFPS", showFPSvalue);
        //print(showFPSvalue);
    }

    // Update is called once per frame
    void Update()
    {
        SaveSetting();
        Checker();
        
    }

    private void Checker()
    {
        if (showFPSvalue == 1)
        {
            showFPS.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            showFPS.GetComponent<Toggle>().isOn = false;
        }
    }

    public void ShowFPS()
    {
        if (showFPS.GetComponent<Toggle>().isOn == true)
        {
            showFPSvalue = 1;
            if (showFPSvalue == 1)
            {
                HamburgerMenuBar.ShowFPS = true;
            }
        }
        else
        {
            showFPSvalue = 0;
            if (showFPSvalue == 0)
            {
                HamburgerMenuBar.ShowFPS = false;
            }
        }
        //print(HamburgerMenuBar.ShowFPS);
        //print(showFPSvalue);
    }

    private void SaveSetting()
    {
        PlayerPrefs.SetInt("ShowFPS", showFPSvalue);
        PlayerPrefs.Save();
    }
}

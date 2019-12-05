using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingSystem : MonoBehaviour
{
    public static int showFPSvalue;
    public static int MusicOnValue;
    public static int SFXOnValue;
    public float MusicValue;
    public float SFXValue;
    [SerializeField] private Toggle showFPS = null;
    [SerializeField] private Toggle Music = null;
    [SerializeField] private Toggle SFX = null;
    [SerializeField] private Slider MusicSlider = null;
    [SerializeField] private Slider SFXSlider = null;
//    [SerializeField] private GameObject SoundManagerOverAll = null;
//    [SerializeField] private GameObject SoundManagerOverAllInGame = null;
    
    
    // Start is called before the first frame update
    void Start()
    {
        showFPSvalue = PlayerPrefs.GetInt("ShowFPS", showFPSvalue);
        MusicOnValue = PlayerPrefs.GetInt("MusicOn", MusicOnValue);
        SFXOnValue = PlayerPrefs.GetInt("SFXOn", SFXOnValue);
        MusicValue = PlayerPrefs.GetFloat("MusicValue", MusicSlider.value);
        SFXValue = PlayerPrefs.GetFloat("SFXValue", SFXSlider.value);
        //print(showFPSvalue);
    }

    private void Awake()
    {
        Music.GetComponent<Toggle>().isOn = true;
        SFX.GetComponent<Toggle>().isOn = true;
        MusicValue = 1;
        SFXValue = 1;
    }

    // Update is called once per frame
    void Update()
    {
        SaveSetting();
        Checker();
        OverAll.SoundValue = MusicSlider.value;
        SoundManager.SoundSFXValue = SFXSlider.value;
        SoundValue.SoundSFXValueOverAll = SFXSlider.value;
        if (Music.GetComponent<Toggle>().isOn == false)
        {
            MusicValue = 0;
            MusicSlider.value = MusicValue;
        }

        if (SFX.GetComponent<Toggle>().isOn == false)
        {
            SFXValue = 0;
            SFXSlider.value = SFXValue;
        }
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

        if (MusicOnValue == 1)
        {
            Music.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            Music.GetComponent<Toggle>().isOn = false;
        }

        if (SFXOnValue == 1)
        {
            SFX.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            SFX.GetComponent<Toggle>().isOn = false;
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

    public void MusicOn()
    {
        
        if (Music.GetComponent<Toggle>().isOn == true)
        {
            MusicOnValue = 1;
            if (MusicOnValue == 1)
            {
                MusicValue = PlayerPrefs.GetFloat("MusicValue", MusicSlider.value);
            }
            MusicSlider.interactable = true;
        }
        else
        {
            PlayerPrefs.SetFloat("MusicValue", MusicSlider.value);
            MusicOnValue = 0;
            if (MusicOnValue == 0)
            {
                MusicValue = 0;
            }
            MusicSlider.interactable = false;
        }
        MusicSlider.value = MusicValue;
    }

    public void SFXOn()
    {
        if (SFX.GetComponent<Toggle>().isOn == true)
        {
            SFXOnValue = 1;
            if (SFXOnValue == 1)
            {
                SFXValue = PlayerPrefs.GetFloat("SFXValue", SFXSlider.value);
            }

            SFXSlider.interactable = true;
        }
        else
        {
            PlayerPrefs.SetFloat("SFXValue", SFXSlider.value);
            SFXOnValue = 0;
            if (SFXOnValue == 0)
            {
                SFXValue = 0;
            }
            SFXSlider.interactable = false;
        }
        SFXSlider.value = SFXValue;
    }

    public void SaveSoundValue()
    {
        OnApplicationQuit();
    }

    private void SaveSetting()
    {
        PlayerPrefs.SetInt("ShowFPS", showFPSvalue);
        PlayerPrefs.SetInt("MusicOn", MusicOnValue);
        PlayerPrefs.SetInt("SFXOn", SFXOnValue);
        PlayerPrefs.Save();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("MusicValue", MusicSlider.value);
        PlayerPrefs.SetFloat("SFXValue", SFXSlider.value);
        PlayerPrefs.Save();
    }
}

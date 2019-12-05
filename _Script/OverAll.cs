using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverAll : MonoBehaviour
{
    public static float TimeSecond;
    public static float TimeMinut;
    public static float SoundValue;
    public static bool TimeTrue = false;
    [SerializeField] private float TimeReStamina = 0;
    [SerializeField] private Text ReStaminaTimeText = null;
    // Start is called before the first frame update
    void Start()
    {
        TimeMinut = PlayerPrefs.GetFloat("TimeMinut", 0);
        TimeSecond = PlayerPrefs.GetFloat("TimeSecond", 0);
        Application.targetFrameRate = 300;
        //OnApplicationFocus();
    }

    private void Awake()
    {
        TimeMinut = 1;
        TimeSecond = 30;
        MainMenu.StaminaValue = 30;
        TimeTrue = false;
    }

    // Update is called once per frame
    void Update()
    {
        ReStaminaTimeText.text = TimeMinut.ToString("00") + TimeSecond.ToString(":00"); 
        GetComponent<AudioSource>().volume = SoundValue;
        if (MainMenu.StaminaValue <= 29)
        {
            ReStaminaTimeText.GetComponent<Text>().enabled = true;
//            TimeSecond -=1f * Time.deltaTime;
            TimeSecond -=1f;
            if (TimeSecond <= 0 && TimeTrue == false)
            {
                TimeMinut = 0;
                TimeSecond = 59;
            }
            
            if (TimeSecond <= TimeReStamina && TimeTrue == true)
            {
                MainMenu.StaminaValue += 1;
                PlayerPrefs.SetFloat("Stamina",MainMenu.StaminaValue);
                //print("Stamina" + MainMenu.StaminaValue);
                TimeMinut = 1;
                TimeSecond = 30;
                TimeTrue = false;
            }

            if (TimeSecond >= 40)
            {
                TimeTrue = true;
            }
        }
        else
        {
            ReStaminaTimeText.GetComponent<Text>().enabled = false;
        }
        //print(TimeInApp);
        OnApplicationFocus();
        //OnApplicationQuit();
        PlayerPrefs.SetFloat("TimeMinut",TimeMinut);
        PlayerPrefs.SetFloat("TimeSecond", TimeSecond);
    }
    
    private void OnApplicationFocus()
    {
//        PlayerPrefs.SetFloat("TimeMinut",TimeMinut);
//        PlayerPrefs.SetFloat("TimeSecond", TimeSecond);
        //DontDestroyOnLoad(gameObject);
        //PlayerPrefs.Save();
    }

    private void OnApplicationQuit()
    {
        if (MainMenu.StaminaValue <= 29)
        {
            ReStaminaTimeText.GetComponent<Text>().enabled = true;
            TimeSecond -=1f * Time.deltaTime;
            if (TimeSecond <= 0 && TimeTrue == false)
            {
                TimeMinut = 0;
                TimeSecond = 59;
            }
            
            if (TimeSecond <= TimeReStamina && TimeTrue == true)
            {
                MainMenu.StaminaValue += 1;
                PlayerPrefs.SetFloat("Stamina",MainMenu.StaminaValue);
                //print("Stamina" + MainMenu.StaminaValue);
                TimeMinut = 1;
                TimeSecond = 30;
                TimeTrue = false;
            }

            if (TimeSecond >= 40)
            {
                TimeTrue = true;
            }
        }
        else
        {
            ReStaminaTimeText.GetComponent<Text>().enabled = false;
        }
//        if (MainMenu.StaminaValue <= 25)
//        {
//            TimeSecond +=1f * Time.deltaTime;
//            if (TimeSecond >= TimeReStamina)
//            {
//                MainMenu.StaminaValue += 1;
//                PlayerPrefs.SetFloat("Stamina",MainMenu.StaminaValue);
//                //print("Stamina" + MainMenu.StaminaValue);
//                TimeSecond = 0;
//            }
//        }
//        PlayerPrefs.SetFloat("TimeMinut",TimeMinut);
//        PlayerPrefs.SetFloat("TimeSecond", TimeSecond);
//        PlayerPrefs.SetFloat("Stamina", MainMenu.StaminaValue);
        PlayerPrefs.SetInt("MoneyBear",MainMenu.moneyBear);
        PlayerPrefs.SetInt("MoneyBear",18400);
        PlayerPrefs.SetInt("ShowFPS", SettingSystem.showFPSvalue);
        PlayerPrefs.Save();
        print("Quit");
    }
}

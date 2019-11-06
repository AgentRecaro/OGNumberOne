using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverAll : MonoBehaviour
{
    public static float TimeInApp;
    [SerializeField] private float TimeReStamina = 0;
    // Start is called before the first frame update
    void Start()
    {
        TimeInApp = PlayerPrefs.GetFloat("TimeInApp", 0);
        //OnApplicationFocus();
    }

    // Update is called once per frame
    void Update()
    {
        if (MainMenu.StaminaValue <= 25)
        {
            TimeInApp +=1f * Time.deltaTime;
            if (TimeInApp >= TimeReStamina)
            {
                MainMenu.StaminaValue += 5;
                PlayerPrefs.SetFloat("Stamina",MainMenu.StaminaValue);
                //print("Stamina" + MainMenu.StaminaValue);
                TimeInApp = 0;
            }
        }
        //print(TimeInApp);
        OnApplicationFocus();
        //OnApplicationQuit();
    }
    
    private void OnApplicationFocus()
    {
        PlayerPrefs.SetFloat("TimeInApp", TimeInApp);
        //DontDestroyOnLoad(gameObject);
        //PlayerPrefs.Save();
    }

    private void OnApplicationQuit()
    {
        if (MainMenu.StaminaValue <= 25)
        {
            TimeInApp +=1f * Time.deltaTime;
            if (TimeInApp >= TimeReStamina)
            {
                MainMenu.StaminaValue += 5;
                PlayerPrefs.SetFloat("Stamina",MainMenu.StaminaValue);
                //print("Stamina" + MainMenu.StaminaValue);
                TimeInApp = 0;
            }
        }
        PlayerPrefs.SetFloat("Stamina", MainMenu.StaminaValue);
        PlayerPrefs.SetInt("MoneyBear",MainMenu.moneyBear);
        //PlayerPrefs.SetInt("MoneyBear",18400);
        PlayerPrefs.Save();
        print("Quit");
    }
}

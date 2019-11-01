using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverAll : MonoBehaviour
{
    public static float TimeInApp;
    // Start is called before the first frame update
    void Start()
    {
        TimeInApp = PlayerPrefs.GetFloat("TimeInApp", 0);
        OnApplicationFocus();
    }

    // Update is called once per frame
    void Update()
    {
        if (MainMenu.StaminaValue <= 25)
        {
            TimeInApp +=1 * Time.deltaTime;
            if (TimeInApp >= 60)
            {
                MainMenu.StaminaValue += 5;
                TimeInApp = 0;
            }
        }
        OnApplicationFocus();
    }
    
    private void OnApplicationFocus()
    {
        PlayerPrefs.SetFloat("TimeInApp", TimeInApp);
        //DontDestroyOnLoad(gameObject);
        //PlayerPrefs.Save();
    }

    private void OnApplicationQuit()
    {
        OnApplicationFocus();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    static int Level = 1;
    static int EXP;
    static int MaxEXP = 50;
    [SerializeField] private Text LevelText = null;
    [SerializeField] private Slider EXPSlider = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LevelText.text = "LV. " + Level;
        if (EXPSlider.value == 50 && Level == 1)
        {
            Level = 2;
            MaxEXP = 75;
            EXP = 0;
        }

        if (EXPSlider.value == 75 && Level == 2)
        {
            Level = 3;
            MaxEXP = 100;
            EXP = 0;
        }
        
        if (EXPSlider.value == 100 && Level == 3)
        {
            Level = 4;
            MaxEXP = 125;
            EXP = 0;
        }
        if (EXPSlider.value == 125 && Level == 4)
        {
            Level = 5;
            MaxEXP = 150;
            EXP = 0;
        }
        if (EXPSlider.value == 150 && Level == 5)
        {
            Level = 6;
            MaxEXP = 175;
            EXP = 0;
        }
        if (EXPSlider.value == 175 && Level == 6)
        {
            Level = 7;
            MaxEXP = 200;
            EXP = 0;
        }
        if (EXPSlider.value == 200 && Level == 7)
        {
            Level = 8;
            MaxEXP = 225;
            EXP = 0;
        }
        if (EXPSlider.value == 225 && Level == 8)
        {
            Level = 9;
            MaxEXP = 250;
            EXP = 0;
        }
        if (EXPSlider.value == 250 && Level == 9)
        {
            Level = 10;
            MaxEXP = 300;
            EXP = 0;
        }
        
        EXPSlider.value = EXP;
        EXPSlider.maxValue = MaxEXP;
    }

    public void AddEXP(int AddEXPPlayer)
    {
        EXP += AddEXPPlayer;
        PlayerPrefs.SetInt("EXPPlayer", EXP);
        PlayerPrefs.SetInt("LevelPlayer", Level);
    }
}

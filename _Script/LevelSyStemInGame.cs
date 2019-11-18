using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSyStemInGame : MonoBehaviour
{
    public static float LevelInGame;
    public static float EXPInGame;
    public static float MaxEXPInGame;
    [SerializeField] private GameObject CanvasSkil = null;
    [SerializeField] private Text LevelInGameText = null;
    [SerializeField] private Slider EXPInGameSlider = null;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LevelInGameText.text = "LV. " + LevelInGame;
        if (EXPInGameSlider.value == 10 && LevelInGame == 1)
        {
            LevelInGame = 2;
            MaxEXPInGame = 16;
            EXPInGame = 0;
            Time.timeScale = 0f;
            spawnSelectabilitySystem.CanvasSkill = true;
            CanvasSkil.GetComponent<Canvas>().enabled = true;
        }

        if (EXPInGameSlider.value == 16 && LevelInGame == 2)
        {
            LevelInGame = 3;
            MaxEXPInGame = 24;
            EXPInGame = 0;
            Time.timeScale = 0f;
            spawnSelectabilitySystem.CanvasSkill = true;
            CanvasSkil.GetComponent<Canvas>().enabled = true;
        }
        
        if (EXPInGameSlider.value == 24 && LevelInGame == 3)
        {
            LevelInGame = 4;
            MaxEXPInGame = 30;
            EXPInGame = 0;
            Time.timeScale = 0f;
            spawnSelectabilitySystem.CanvasSkill = true;
            CanvasSkil.GetComponent<Canvas>().enabled = true;
        }
        if (EXPInGameSlider.value == 30 && LevelInGame == 4)
        {
            LevelInGame = 5;
            MaxEXPInGame = 36;
            EXPInGame = 0;
            Time.timeScale = 0f;
            spawnSelectabilitySystem.CanvasSkill = true;
            CanvasSkil.GetComponent<Canvas>().enabled = true;
        }
        if (EXPInGameSlider.value == 36 && LevelInGame == 5)
        {
            LevelInGame = 6;
            MaxEXPInGame = 40;
            EXPInGame = 0;
            Time.timeScale = 0f;
            spawnSelectabilitySystem.CanvasSkill = true;
            CanvasSkil.GetComponent<Canvas>().enabled = true;
        }
        if (EXPInGameSlider.value == 40 && LevelInGame == 6)
        {
            LevelInGame = 7;
            MaxEXPInGame = 40;
            EXPInGame = 0;
            Time.timeScale = 0f;
            spawnSelectabilitySystem.CanvasSkill = true;
            CanvasSkil.GetComponent<Canvas>().enabled = true;
        }
        if (EXPInGameSlider.value == 40 && LevelInGame == 7)
        {
            LevelInGame = 8;
            MaxEXPInGame = 44;
            EXPInGame = 0;
            Time.timeScale = 0f;
            spawnSelectabilitySystem.CanvasSkill = true;
            CanvasSkil.GetComponent<Canvas>().enabled = true;
        }
        if (EXPInGameSlider.value == 44 && LevelInGame == 8)
        {
            LevelInGame = 9;
            MaxEXPInGame = 44;
            EXPInGame = 0;
            Time.timeScale = 0f;
            spawnSelectabilitySystem.CanvasSkill = true;
            CanvasSkil.GetComponent<Canvas>().enabled = true;
        }
        if (EXPInGameSlider.value == 44 && LevelInGame == 9)
        {
            LevelInGame = 10;
            MaxEXPInGame = 50;
            EXPInGame = 0;
            Time.timeScale = 0f;
            spawnSelectabilitySystem.CanvasSkill = true;
            CanvasSkil.GetComponent<Canvas>().enabled = true;
        }
        
        EXPInGameSlider.value = EXPInGame;
        EXPInGameSlider.maxValue = MaxEXPInGame;
    }
}

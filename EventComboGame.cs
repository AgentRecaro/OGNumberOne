using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventComboGame : MonoBehaviour
{
    public static float Combo;
    private bool C;
    private bool B;
    private bool A;
    private bool S;
    [SerializeField] private Text combotext = null;
    [SerializeField] private Slider comboSlider = null;

    // Start is called before the first frame update
    void Start()
    {
        comboSlider.value = Combo;
        combotext.text = "D";
        C = true;
        B = false;
        A = false;
        S = false;
    }


    void Update()
    {
        comboSlider.value = Combo;
        if (Combo >= 1 && comboSlider.value <= 100)
        {
            Combo -=  2 * Time.deltaTime;
        }
        
        if (comboSlider.value == 100 && C == true)
        {
            combotext.text = "C";
            comboSlider.maxValue = 105;
            Combo = 0;
            C = false;
            B = true;
        }

        if (comboSlider.value == 105 && B == true)
        {
            combotext.text = "B";
            comboSlider.maxValue = 110;
            Combo = 0;
            B = false;
            A = true;
        }

        if (comboSlider.value == 110 && A == true)
        {
            combotext.text = "A";
            comboSlider.maxValue = 115;
            Combo = 0;
            A = false;
            S = true;
        }

        if (comboSlider.value == 115 && S == true)
        {
            combotext.text = "S";
            comboSlider.maxValue = 150;
            Combo = 0;
        }

        

    }
}

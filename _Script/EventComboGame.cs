using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventComboGame : MonoBehaviour
{
    public static float Combo;
    public static Text combotext;
    public static string[] NameComBo;
    public static int SaveNameCombo;
    private bool C;
    private bool B;
    private bool A;
    private bool S;
    //[SerializeField] private string[] NameComBo = null;
    //[SerializeField] private int SaveNameCombo;
    //[SerializeField] private Text combotext = null;
    [SerializeField] private Slider comboSlider = null;

    // Start is called before the first frame update
    void Start()
    {
        NameComBo = new String[] {"D", "C", "B", "A", "S"};
        SaveNameCombo = PlayerPrefs.GetInt("NameCombo", SaveNameCombo);
        combotext = GameObject.FindGameObjectWithTag("ComBoText").GetComponent<Text>();
        comboSlider.value = Combo;
        combotext.text = NameComBo[SaveNameCombo];
        C = true;
        B = false;
        A = false;
        S = false;
    }

    void Update()
    {
        PlayerPrefs.SetString("NameCombo", NameComBo[SaveNameCombo]);
        PlayerPrefs.SetInt("SaveNamecaombo", SaveNameCombo);
        comboSlider.value = Combo;
        if (Combo >= 1 && comboSlider.value <= 100)
        {
            Combo -=  2 * Time.deltaTime;
        }
        
        if (comboSlider.value == 100 && C == true)
        {
            SaveNameCombo++;
            combotext.text = NameComBo[SaveNameCombo];
            //combotext.text = "C";
            comboSlider.maxValue = 150;
            Combo = 0;
            C = false;
            B = true;
        }

        if (comboSlider.value == 150 && B == true)
        {
            SaveNameCombo++;
            combotext.text = NameComBo[SaveNameCombo];
            //combotext.text = "B";
            comboSlider.maxValue = 180;
            Combo = 0;
            B = false;
            A = true;
        }

        if (comboSlider.value == 180 && A == true)
        {
            SaveNameCombo++;
            combotext.text = NameComBo[SaveNameCombo];
            //combotext.text = "A";
            comboSlider.maxValue = 200;
            Combo = 0;
            A = false;
            S = true;
        }

        if (comboSlider.value == 200 && S == true)
        {
            SaveNameCombo++;
            combotext.text = NameComBo[SaveNameCombo];
            //combotext.text = "S";
            comboSlider.maxValue = 250;
            Combo = 0;
        }

        PlayerPrefs.Save();

    }
}

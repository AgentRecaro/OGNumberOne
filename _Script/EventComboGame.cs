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
    public static int MaxValueCombo;
    public static bool DamageOn;
    public static bool DamageD;
    public static bool DamageC;
    public static bool DamageB;
    public static bool DamageA;
    public static bool DamageS;
    public static bool SkillComBoSOn = false;
    public static float TimeReButtonSkillComBoS;
    public static float ValueReTimeButton;
    //[SerializeField] private string[] NameComBo = null;
    //[SerializeField] private int SaveNameCombo;
    //[SerializeField] private Text combotext = null;
    [SerializeField] private Slider comboSlider = null;
    [SerializeField] private Image FillColor = null;
    [SerializeField] private Sprite[] NameComBoImage = null;
    [SerializeField] private Image NameImageCombo = null;
    [SerializeField] private Animation AnimationNameCombo = null;
    [SerializeField] private AudioClip SoundNameCombo = null;
    [SerializeField] private Canvas SkilComBoSCanvas = null;
    

    // Start is called before the first frame update
    void Start()
    {
        NameComBo = new String[] {"D", "C", "B", "A", "S"};
        //PlayerPrefs.GetString("NameCombo", NameComBo[SaveNameCombo]);
//        PlayerPrefs.GetInt("NameCombo", SaveNameCombo);
        //SaveNameCombo = PlayerPrefs.GetInt("SaveNamecaombo", SaveNameCombo);
        combotext = GameObject.FindGameObjectWithTag("ComBoText").GetComponent<Text>();
        NameImageCombo = GameObject.FindGameObjectWithTag("NameComBoImage").GetComponent<Image>();
        comboSlider.value = Combo;
        combotext.text = NameComBo[SaveNameCombo];
        NameImageCombo.sprite = NameComBoImage[SaveNameCombo];
        if (DamageOn == true)
        {
            PlayerMovement.Damage += 10;
            AnimationNameCombo.Play("AnimationNameCombo");
            GetComponent<AudioSource>().PlayOneShot(SoundNameCombo);
        }
    }

    void Update()
    {
        SkilComBoSCanvas = GameObject.FindGameObjectWithTag("CanvasSkillComBoS").GetComponent<Canvas>();
        comboSlider.maxValue = MaxValueCombo;
//        PlayerPrefs.SetString("NameCombo", NameComBo[SaveNameCombo]);
//        PlayerPrefs.SetInt("SaveNamecaombo", SaveNameCombo);
        comboSlider.value = Combo;
        if (Combo >= 1 && comboSlider.value <= 100)
        {
            Combo -=  2 * Time.deltaTime;
        }

        if (SkillComBoSOn == true)
        {
            SkilComBoSCanvas.GetComponent<Canvas>().enabled = true;
            ValueReTimeButton = 0;
        }
        else
        {
            TimeReButtonSkillComBoS += ValueReTimeButton * Time.deltaTime;
            SkilComBoSCanvas.GetComponent<Canvas>().enabled = false;
        }

        if (TimeReButtonSkillComBoS >= 90)
        {
            TimeReButtonSkillComBoS = 0;
            SkillComBoSOn = true;
        }

        if (SaveNameCombo == 0 && NameComBo[SaveNameCombo] == "D")
        {
            DamageD = true;
            DamageC = false;
            DamageB = false;
            DamageA = false;
            DamageS = false;
            DamageOn = false;
            MaxValueCombo = 100;
            FillColor.GetComponent<Image>().color = new Color32(107,30,212,255);
        }
        
        if (SaveNameCombo == 1 && NameComBo[SaveNameCombo] == "C")
        {
            DamageD = false;
            DamageC = true;
            DamageB = false;
            DamageA = false;
            DamageS = false;
            MaxValueCombo = 110;
            FillColor.GetComponent<Image>().color = new Color32(58, 58, 227,255);
        }
        
        if (SaveNameCombo == 2 && NameComBo[SaveNameCombo] == "B")
        {
            DamageD = false;
            DamageC = false;
            DamageB = true;
            DamageA = false;
            DamageS = false;
            MaxValueCombo = 150;
            FillColor.GetComponent<Image>().color = new Color32(72, 227, 72,255);
        }
        
        if (SaveNameCombo == 3 && NameComBo[SaveNameCombo] == "A")
        {
            DamageD = false;
            DamageC = false;
            DamageB = false;
            DamageA = true;
            DamageS = false;
            MaxValueCombo = 180;
            FillColor.GetComponent<Image>().color = new Color32(237, 234, 75,255);
        }
        
        if (SaveNameCombo == 4 && NameComBo[SaveNameCombo] == "S")
        {
            DamageD = false;
            DamageC = false;
            DamageB = false;
            DamageA = false;
            DamageS = true;
            MaxValueCombo = 200;
            FillColor.GetComponent<Image>().color = new Color32(246, 70, 70,255);
        }
        
        if (comboSlider.value == 100 && NameComBo[SaveNameCombo] == "D")
        {
            SaveNameCombo++;
            combotext.text = NameComBo[SaveNameCombo];
            NameImageCombo.sprite = NameComBoImage[SaveNameCombo];
            comboSlider.maxValue = 110;
            Combo = 0;
            PlayerMovement.Damage += 20;
            AnimationNameCombo.Play("AnimationNameCombo");
            GetComponent<AudioSource>().PlayOneShot(SoundNameCombo);
        }

        if (comboSlider.value == 110 && NameComBo[SaveNameCombo] == "C")
        {
            SaveNameCombo++;
            combotext.text = NameComBo[SaveNameCombo];
            NameImageCombo.sprite = NameComBoImage[SaveNameCombo];
            //combotext.text = "C";
            comboSlider.maxValue = 150;
            Combo = 0;
            PlayerMovement.Damage += 30;
            AnimationNameCombo.Play("AnimationNameCombo");
            GetComponent<AudioSource>().PlayOneShot(SoundNameCombo);
        }

        if (comboSlider.value == 150 && NameComBo[SaveNameCombo] == "B")
        {
            SaveNameCombo++;
            combotext.text = NameComBo[SaveNameCombo];
            NameImageCombo.sprite = NameComBoImage[SaveNameCombo];
            //combotext.text = "B";
            comboSlider.maxValue = 180;
            Combo = 0;
            PlayerMovement.Damage += 40;
            AnimationNameCombo.Play("AnimationNameCombo");
            GetComponent<AudioSource>().PlayOneShot(SoundNameCombo);
//            SkillComBoSOn = true;
        }

        if (comboSlider.value == 180 && NameComBo[SaveNameCombo] == "A")
        {
            SaveNameCombo++;
            combotext.text = NameComBo[SaveNameCombo];
            NameImageCombo.sprite = NameComBoImage[SaveNameCombo];
            //combotext.text = "A";
            comboSlider.maxValue = 200;
            Combo = 0;
            PlayerMovement.Damage += 50;
            AnimationNameCombo.Play("AnimationNameCombo");
            GetComponent<AudioSource>().PlayOneShot(SoundNameCombo);
            SkillComBoSOn = true;
        }

        if (comboSlider.value == 200 && NameComBo[SaveNameCombo] == "S")
        {
//            SaveNameCombo++;
//            combotext.text = NameComBo[SaveNameCombo];
//            //combotext.text = "S";
//            comboSlider.maxValue = 250;
//            Combo = 0;
        }

        PlayerPrefs.Save();

    }
}

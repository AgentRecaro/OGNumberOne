using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusSystem : MonoBehaviour
{
    public bool StrenghMax = false;
    public bool DamageMax = false;
    public bool RegenerationMax = false;
    public bool SpeedMax = false;
    public bool AttackSpeedMax = false;
    public bool ArmorMax = false;
    public bool GloryMax = false;
    public bool GoldMax = false;
    public bool EXPMax = false;
    private int[] priceStrength;
    private int[] priceDamage;
    private int[] priceRegeneration;
    private int[] priceSpeed;
    private int[] priceAttackSpeed;
    private int[] priceArmor;
    private int[] priceGlory;
    private int[] priceGold;
    private int[] priceEXP;
    private float[] Strength;
    private float[] Damage;
    private float[] Regeneration;
    private float[] Speed;
    private float[] AttackSpeed;
    private float[] Armor;
    private float[] Glory;
    private float[] Gold;
    private float[] EXP;
    private int priceStrengthValue;
    private int priceDamageValue;
    private int priceRegenerationValue;
    private int priceSpeedValue;
    private int priceAttackSpeedValue;
    private int priceArmorValue;
    private int priceGloryValue;
    private int priceGoldValue;
    private int priceEXPValue;
    private int StrengthValue;
    private int DamageValue;
    private int RegenerationValue;
    private int SpeedValue;
    private int AttackSpeedValue;
    private int ArmorValue;
    private int GloryValue;
    private int GoldValue;
    private int EXPValue;
    [SerializeField] private Slider StrengthSlider = null;
    [SerializeField] private Slider DamageSlider = null;
    [SerializeField] private Slider RegenerationSlider = null;
    [SerializeField] private Slider SpeedSlider = null;
    [SerializeField] private Slider AttackSpeedSlider = null;
    [SerializeField] private Slider ArmorSlider = null;
    [SerializeField] private Slider GlorySlider = null;
    [SerializeField] private Slider GoldSlider = null;
    [SerializeField] private Slider EXPSlider = null;
    [SerializeField] private Text StrengthText = null;
    [SerializeField] private Text DamageText = null;
    [SerializeField] private Text RegenerationText = null;
    [SerializeField] private Text SpeedText = null;
    [SerializeField] private Text AttackSpeedText = null;
    [SerializeField] private Text ArmorText = null;
    [SerializeField] private Text GloryText = null;
    [SerializeField] private Text GoldText = null;
    [SerializeField] private Text EXPText = null;
    [SerializeField] private Button StrengthButtonUI = null;
    [SerializeField] private Button DamageButtonUI = null;
    [SerializeField] private Button RegenerationButtonUI = null;
    [SerializeField] private Button SpeedButtonUI = null;
    [SerializeField] private Button AttackSpeedButtonUI = null;
    [SerializeField] private Button ArmorButtonUI = null;
    [SerializeField] private Button GloryButtonUI= null;
    [SerializeField] private Button GoldButtonUI = null;
    [SerializeField] private Button EXPButtonUI = null;
    [SerializeField] private Text StrengthTextPrice = null;
    [SerializeField] private Text DamageTextPrice = null;
    [SerializeField] private Text RegenerationTextPrice = null;
    [SerializeField] private Text SpeedTextPrice = null;
    [SerializeField] private Text AttackSpeedTextPrice = null;
    [SerializeField] private Text ArmorTextPrice = null;
    [SerializeField] private Text GloryTextPrice = null;
    [SerializeField] private Text GoldTextPrice = null;
    [SerializeField] private Text EXPTextPrice = null;
    [SerializeField] private InputField textConsole = null; 


    // Start is called before the first frame update
    void Start()
    {

        //Price
        priceStrength = new int[]{ 200, 500, 800, 1200, 1800};
        priceDamage = new int[]{ 200, 500, 800, 1200, 1800};
        priceRegeneration = new int[]{ 200, 500, 800, 1200, 1800};
        priceSpeed = new int[]{ 200, 500, 800, 1200, 1800};
        priceAttackSpeed = new int[]{ 200, 500, 800, 1200, 1800};
        priceArmor = new int[]{ 200, 500, 800, 1200, 1800};
        priceGlory = new int[]{ 2000};
        priceGold = new int[]{ 200, 500, 800, 1200, 1800};
        priceEXP = new int[]{ 200, 500, 800, 1200, 1800};

        //MainStatus
        Strength = new float[]{ 100, 150, 220, 300, 400, 550};//Value= 6
        Damage = new float[]{ 100, 110, 130, 160, 200, 250};//Value= 6
        Regeneration = new float[]{ 0, 0.25f, 0.3f, 0.5f, 0.75f, 1f};//Value= 6
        Speed = new float[]{ 5f, 5.25f, 5.55f, 6.05f, 6.8f, 7.8f};//Value= 6
        AttackSpeed = new float[]{ 3, 3.25f, 3.55f, 4.05f, 4.8f, 5.8f};//Value= 6
        Armor = new float[]{ 0, 10, 15, 25, 50, 70};//Value= 6
        Glory = new float[]{ 0, 1};//Value= 2
        Gold = new float[]{ 5f, 5.5f, 6.25f, 7.25f, 8.75f, 10.75f};//Value= 6
        EXP = new float[]{ 2f, 2.25f, 2.55f, 3.05f, 3.8f, 4.8f};//Value= 6
        
        //Price
        PlayerPrefs.GetInt("priceStrength", priceStrength[priceStrengthValue]); 
        PlayerPrefs.GetInt("priceDamage", priceDamage[priceDamageValue]);
        PlayerPrefs.GetInt("priceRegeneration ", priceRegeneration[priceRegenerationValue] );
        PlayerPrefs.GetInt("priceSpeed", priceSpeed[priceSpeedValue]);
        PlayerPrefs.GetInt("priceAttackSpeed", priceAttackSpeed[priceAttackSpeedValue]);
        PlayerPrefs.GetInt("priceArmor", priceArmor[priceArmorValue]);
        PlayerPrefs.GetInt("priceGlory", priceGlory[priceGloryValue]);
        PlayerPrefs.GetInt("priceGold", priceGold[priceGoldValue]);
        PlayerPrefs.GetInt("priceEXP", priceEXP[priceEXPValue]);
        
//        //Status
        PlayerPrefs.GetFloat("Strength",Strength[StrengthValue]);
        PlayerPrefs.GetFloat("Damage",Damage[DamageValue]);
        PlayerPrefs.GetFloat("Regeneration",Regeneration[RegenerationValue]);
        PlayerPrefs.GetFloat("Speed",Speed[SpeedValue]);
        PlayerPrefs.GetFloat("AttackSpeed",AttackSpeed[AttackSpeedValue]);
        PlayerPrefs.GetFloat("Armor",Armor[ArmorValue]);
        PlayerPrefs.GetFloat("Glory",Glory[GloryValue]);
        PlayerPrefs.GetFloat("Gold",Gold[GoldValue]);
        PlayerPrefs.GetFloat("EXP",EXP[EXPValue]);
//        
//        //PriceValue
        priceStrengthValue = PlayerPrefs.GetInt("priceStrengthValue", priceStrengthValue); 
        priceDamageValue = PlayerPrefs.GetInt("priceDamageValue", priceDamageValue);
        priceRegenerationValue = PlayerPrefs.GetInt("priceRegenerationValue ", priceRegenerationValue );
        priceSpeedValue = PlayerPrefs.GetInt("priceSpeedValue", priceSpeedValue);
        priceAttackSpeedValue = PlayerPrefs.GetInt("priceAttackSpeedValue", priceAttackSpeedValue);
        priceArmorValue = PlayerPrefs.GetInt("priceArmorValue", priceArmorValue);
        priceGloryValue = PlayerPrefs.GetInt("priceGloryValue", priceGloryValue);
        priceGoldValue = PlayerPrefs.GetInt("priceGoldValue", priceGoldValue);
        priceEXPValue = PlayerPrefs.GetInt("priceEXPValue", priceEXPValue);
        
//        //StatusValue
        StrengthValue = PlayerPrefs.GetInt("StengthValue", StrengthValue);
        DamageValue = PlayerPrefs.GetInt("DamageValue", DamageValue);
        RegenerationValue = PlayerPrefs.GetInt("RegenerationValue", RegenerationValue);
        SpeedValue = PlayerPrefs.GetInt("SpeedValue", SpeedValue);
        AttackSpeedValue = PlayerPrefs.GetInt("AttackSpeedValue", AttackSpeedValue);
        ArmorValue = PlayerPrefs.GetInt("ArmorValue", ArmorValue);
        GloryValue = PlayerPrefs.GetInt("GloryValue", GloryValue);
        GoldValue = PlayerPrefs.GetInt("GoldValue", GoldValue);
        EXPValue = PlayerPrefs.GetInt("EXPValue", EXPValue);
        
        //MaxValueSlider
        StrengthSlider.maxValue = 5;
        DamageSlider.maxValue = 5;
        RegenerationSlider.maxValue = 5;
        SpeedSlider.maxValue = 5;
        AttackSpeedSlider.maxValue = 5;
        ArmorSlider.maxValue = 5;
        GlorySlider.maxValue = 1;
        GoldSlider.maxValue = 5;
        EXPSlider.maxValue = 5;
        
        //TextValue
        StrengthText.text = "Strength  " + Strength[StrengthValue];
        DamageText.text = "Damage  " + Damage[DamageValue];
        RegenerationText.text = "Regeneration  " + Regeneration[RegenerationValue] + "%";
        SpeedText.text = "Speed  " + Speed[SpeedValue] + "%";
        AttackSpeedText.text = "AttackSpeed  " + AttackSpeed[AttackSpeedValue] + "%";
        ArmorText.text = "Armor  " + Armor[ArmorValue];
        GloryText.text = "Glory  " + Glory[GloryValue];
        GoldText.text = "Gold  " + Gold[GoldValue] + "%";
        EXPText.text = "EXP.  " + EXP[EXPValue] + "%";
        
        //TextPrice
//        GoldTextPrice.text = "" + priceGold[priceGoldValue];
//        EXPTextPrice.text = "" + priceEXP[priceEXPValue];
//        StrengthTextPrice.text = "" + priceStrength[priceStrengthValue];
//        DamageTextPrice.text = "" + priceDamage[priceDamageValue];
//        RegenerationTextPrice.text = "" + priceRegeneration[priceRegenerationValue];
//        SpeedTextPrice.text = "" + priceSpeed[priceSpeedValue];
//        AttackSpeedTextPrice.text = "" + priceAttackSpeed[priceAttackSpeedValue];
//        ArmorTextPrice.text = "" + priceArmor[priceArmorValue];
//        GloryTextPrice.text = "" + priceGlory[priceGloryValue];
    }

    // Update is called once per frame
    void Update()
    {
        //SpeedText.text = "Speed  " + Speed[SpeedValue];
        dataUpdate();
        //UpdateText();
        OnSaveUpStatus();
        ValueSliderUpdate();
        PlayerPrefs.SetInt("MoneyBear",MainMenu.moneyBear);
    }

    public void StrengthButton()
    {
        if (MainMenu.moneyBear >= priceStrength[priceStrengthValue] && StrengthValue < Strength.Length -1)
        {
            MainMenu.moneyBear -= priceStrength[priceStrengthValue];
            priceStrengthValue++;
            if (StrengthValue < Strength.Length)
            {
                StrengthValue++;
                StrengthSlider.value = StrengthValue;
                StrengthText.text = "Strength  " + Strength[StrengthValue];
                //OnSaveUpStatus();
            }

            if (StrengthValue == Strength.Length -1)
            {
                StrengthText.text = "Strength  " + Strength[StrengthValue];
                StrengthTextPrice.text = "Max.";
                StrengthButtonUI.enabled = false;
                return;
            }
            StrengthTextPrice.text = "" + priceStrength[priceStrengthValue];
        }
    }

    public void DamageButton()
    {
        if (MainMenu.moneyBear >= priceDamage[priceDamageValue] && DamageValue < Damage.Length -1)
        {
            MainMenu.moneyBear -= priceDamage[priceDamageValue];
            priceDamageValue++;
            if (DamageValue < Damage.Length)
            {
                DamageValue++;
                DamageSlider.value = DamageValue;
                DamageText.text = "Damage  " + Damage[DamageValue];
                //OnSaveUpStatus();
            }

            if (DamageValue == Damage.Length -1)
            {
                DamageText.text = "Damage  " + Damage[DamageValue];
                DamageTextPrice.text = "Max.";
                DamageButtonUI.enabled = false;
                return;
            }
            DamageTextPrice.text = "" + priceDamage[priceDamageValue];
        }
    }

    public void RegenerationButton()
    {
        if (MainMenu.moneyBear >= priceRegeneration[priceRegenerationValue] && RegenerationValue < Regeneration.Length -1)
        {
            MainMenu.moneyBear -= priceRegeneration[priceRegenerationValue];
            priceRegenerationValue++;
            if (RegenerationValue < Regeneration.Length)
            {
                RegenerationValue++;
                RegenerationSlider.value = RegenerationValue;
                RegenerationText.text = "Regeneration  " + Regeneration[RegenerationValue] + "%";
                //OnSaveUpStatus();
            }

            if (RegenerationValue == Regeneration.Length -1)
            {
                RegenerationText.text = "Regeneration  " + Regeneration[RegenerationValue] + "%";
                RegenerationTextPrice.text = "Max.";
                RegenerationButtonUI.enabled = false;
                return;
            }
            RegenerationTextPrice.text = "" + priceRegeneration[priceRegenerationValue];
        }
    }

   public void SpeedButton()
   {
       if (MainMenu.moneyBear >= priceSpeed[priceSpeedValue] && SpeedValue < Speed.Length -1)
       {
           MainMenu.moneyBear -= priceSpeed[priceSpeedValue];
           priceSpeedValue++;
           if (SpeedValue < Speed.Length)
           {
               SpeedValue++;
               SpeedSlider.value = SpeedValue;
               SpeedText.text = "Speed  " + Speed[SpeedValue] + "%";
               //OnSaveUpStatus();
           }

           if (SpeedValue == Speed.Length -1)
           {
               SpeedText.text = "Speed  " + Speed[SpeedValue] + "%";
               SpeedTextPrice.text = "Max.";
               SpeedButtonUI.enabled = false;
               return;
           }
           SpeedTextPrice.text = "" + priceSpeed[priceSpeedValue];
       }
   }

   public void AttackSpeedButton()
   {
       if (MainMenu.moneyBear >= priceAttackSpeed[priceAttackSpeedValue] && AttackSpeedValue < AttackSpeed.Length -1)
       {
           MainMenu.moneyBear -= priceAttackSpeed[priceAttackSpeedValue];
           priceAttackSpeedValue++;
           if (AttackSpeedValue < AttackSpeed.Length)
           {
               AttackSpeedValue++;
               AttackSpeedSlider.value = AttackSpeedValue;
               AttackSpeedText.text = "AttackSpeed  " + AttackSpeed[AttackSpeedValue] + "%";
               //OnSaveUpStatus();
           }

           if (AttackSpeedValue == AttackSpeed.Length -1)
           {
               AttackSpeedText.text = "AttackSpeed  " + AttackSpeed[AttackSpeedValue] + "%";
               AttackSpeedTextPrice.text = "Max.";
               AttackSpeedButtonUI.enabled = false;
               return;
           }
           AttackSpeedTextPrice.text = "" + priceAttackSpeed[priceAttackSpeedValue];
       }
   }

   public void ArmorButton()
   {
       if (MainMenu.moneyBear >= priceArmor[priceArmorValue] && ArmorValue < Armor.Length -1)
       {
           MainMenu.moneyBear -= priceArmor[priceArmorValue];
           priceArmorValue++;
           if (ArmorValue < Armor.Length)
           {
               ArmorValue++;
               ArmorSlider.value = ArmorValue;
               ArmorText.text = "Armor  " + Armor[ArmorValue];
               //OnSaveUpStatus();
           }

           if (ArmorValue == Armor.Length -1)
           {
               ArmorText.text = "Armor  " + Armor[ArmorValue];
               ArmorTextPrice.text = "Max.";
               ArmorButtonUI.enabled = false;
               return;
           }
           ArmorTextPrice.text = "" + priceArmor[priceArmorValue];
       }
   }

   public void GloryButton()
   {
       if (MainMenu.moneyBear >= priceGlory[priceGloryValue] && GloryValue < Glory.Length -1)
       {
           MainMenu.moneyBear -= priceGlory[priceGloryValue];
           priceGloryValue++;
           if (GloryValue < Glory.Length)
           {
               GloryValue++;
               GlorySlider.value = GloryValue;
               GloryText.text = "Glory  " + Glory[GloryValue];
               //OnSaveUpStatus();
           }

           if (GloryValue == Glory.Length -1)
           {
               GloryText.text = "Glory  " + Glory[GloryValue];
               GloryTextPrice.text = "Max.";
               GloryButtonUI.enabled = false;
               return;
           }
           GloryTextPrice.text = "" + priceGlory[priceGloryValue];
       }
   }

   public void GoldButton()
   {
       if (MainMenu.moneyBear >= priceGold[priceGoldValue] && GoldValue < Gold.Length -1)
       {
           MainMenu.moneyBear -= priceGold[priceGoldValue];
           priceGoldValue++;
           if (GoldValue < Gold.Length)
           {
               GoldValue++;
               GoldSlider.value = GoldValue;
               GoldText.text = "Gold  " + Gold[GoldValue] + "%";
               //OnSaveUpStatus();
           }

           if (GoldValue == Gold.Length -1)
           {
               GoldText.text = "Gold  " + Gold[GoldValue] + "%";
               GoldTextPrice.text = "Max.";
               GoldButtonUI.enabled = false;
               return;
           }
           GoldTextPrice.text = "" + priceGold[priceGoldValue];
       }
   }

   public void EXPButton()
   {
       if (MainMenu.moneyBear >= priceEXP[priceEXPValue] && EXPValue < EXP.Length -1)
       {
           MainMenu.moneyBear -= priceEXP[priceEXPValue];
           priceEXPValue++;
           if (EXPValue < EXP.Length)
           {
               EXPValue++;
               EXPSlider.value = EXPValue;
               EXPText.text = "EXP.  " + EXP[EXPValue] + "%";
               //OnSaveUpStatus();
           }

           if (EXPValue == EXP.Length -1)
           {
            EXPText.text = "EXP.  " + EXP[EXPValue] + "%";
            EXPTextPrice.text = "Max.";
            EXPButtonUI.enabled = false;
            return;
           }
           EXPTextPrice.text = "" + priceEXP[priceEXPValue];
       }
   }

   private void dataUpdate()
   {
       if (StrengthValue == Strength.Length - 1)
       {
           StrengthText.text = "Strength  " + Strength[StrengthValue];
           StrengthTextPrice.text = "Max.";
           StrengthButtonUI.enabled = false;
           StrenghMax = true;
       }
       
       if (DamageValue == Damage.Length -1)
       {
           DamageText.text = "Damage  " + Damage[DamageValue];
           DamageTextPrice.text = "Max.";
           DamageButtonUI.enabled = false;
           DamageMax = true;
       }
       
       if (RegenerationValue == Regeneration.Length -1)
       {
           RegenerationText.text = "Regeneration  " + Regeneration[RegenerationValue] + "%";
           RegenerationTextPrice.text = "Max.";
           RegenerationButtonUI.enabled = false;
           RegenerationMax = true;
       }
       if (SpeedValue == Speed.Length -1)
       {
           SpeedText.text = "Speed  " + Speed[SpeedValue] + "%";
           SpeedTextPrice.text = "Max.";
           SpeedButtonUI.enabled = false;
           SpeedMax = true;
       }
       if (AttackSpeedValue == AttackSpeed.Length -1)
       {
           AttackSpeedText.text = "AttackSpeed  " + AttackSpeed[AttackSpeedValue] + "%";
           AttackSpeedTextPrice.text = "Max.";
           AttackSpeedButtonUI.enabled = false;
           AttackSpeedMax = true;
       }
       if (ArmorValue == Armor.Length -1)
       {
           ArmorText.text = "Armor  " + Armor[ArmorValue];
           ArmorTextPrice.text = "Max.";
           ArmorButtonUI.enabled = false;
           ArmorMax = true;
       }
       if (GloryValue == Glory.Length -1)
       {
           GloryText.text = "Glory  " + Glory[GloryValue];
           GloryTextPrice.text = "Max.";
           GloryButtonUI.enabled = false;
           GloryMax = true;
       }
       if (GoldValue == Gold.Length -1)
       {
           GoldText.text = "Gold  " + Gold[GoldValue] + "%";
           GoldTextPrice.text = "Max.";
           GoldButtonUI.enabled = false;
           GoldMax = true;
       }
       if (EXPValue == EXP.Length -1)
       {
           EXPText.text = "EXP.  " + EXP[EXPValue] + "%";
           EXPTextPrice.text = "Max.";
           EXPButtonUI.enabled = false;
           EXPMax = true;
       }
   }

   void ValueSliderUpdate()
   {
       StrengthSlider.value = StrengthValue;
       DamageSlider.value = DamageValue;
       RegenerationSlider.value = RegenerationValue;
       SpeedSlider.value = SpeedValue;
       AttackSpeedSlider.value = AttackSpeedValue;
       ArmorSlider.value = ArmorValue;
       GlorySlider.value = GloryValue;
       GoldSlider.value = GoldValue;
       EXPSlider.value = EXPValue;
   }

   private void OnSaveUpStatus()
   {
       //Price
//       PlayerPrefs.SetInt("priceStrength", priceStrength[priceStrengthValue]); 
//       PlayerPrefs.SetInt("priceDamage", priceDamage[priceDamageValue]);
//       PlayerPrefs.SetInt("priceRegeneration ", priceRegeneration[priceRegenerationValue] );
//       PlayerPrefs.SetInt("priceSpeed", priceSpeed[priceSpeedValue]);
//       PlayerPrefs.SetInt("priceAttackSpeed", priceAttackSpeed[priceAttackSpeedValue]);
//       PlayerPrefs.SetInt("priceArmor", priceArmor[priceArmorValue]);
//       PlayerPrefs.SetInt("priceGlory", priceGlory[priceGloryValue]);
//       PlayerPrefs.SetInt("priceGold", priceGold[priceGoldValue]);
//       PlayerPrefs.SetInt("priceEXP", priceEXP[priceEXPValue]);
       //PriceValue
       PlayerPrefs.SetInt("priceStrengthValue", priceStrengthValue); 
       PlayerPrefs.SetInt("priceDamageValue", priceDamageValue);
       PlayerPrefs.SetInt("priceRegenerationValue ", priceRegenerationValue );
       PlayerPrefs.SetInt("priceSpeedValue", priceSpeedValue);
       PlayerPrefs.SetInt("priceAttackSpeedValue", priceAttackSpeedValue);
       PlayerPrefs.SetInt("priceArmorValue", priceArmorValue);
       PlayerPrefs.SetInt("priceGloryValue", priceGloryValue);
       PlayerPrefs.SetInt("priceGoldValue", priceGoldValue);
       PlayerPrefs.SetInt("priceEXPValue", priceEXPValue);
       //StatusValue
       PlayerPrefs.SetInt("StengthValue", StrengthValue);
       PlayerPrefs.SetInt("DamageValue", DamageValue);
       PlayerPrefs.SetInt("RegenerationValue", RegenerationValue);
       PlayerPrefs.SetInt("SpeedValue", SpeedValue);
       PlayerPrefs.SetInt("AttackSpeedValue", AttackSpeedValue);
       PlayerPrefs.SetInt("ArmorValue", ArmorValue);
       PlayerPrefs.SetInt("GloryValue", GloryValue);
       PlayerPrefs.SetInt("GoldValue", GoldValue);
       PlayerPrefs.SetInt("EXPValue", EXPValue);
       //MainStatus
       PlayerPrefs.SetFloat("Strength",Strength[StrengthValue]);
       PlayerPrefs.SetFloat("Damage",Damage[DamageValue]);
       PlayerPrefs.SetFloat("Regeneration",Regeneration[RegenerationValue]);
       PlayerPrefs.SetFloat("Speed",Speed[SpeedValue]);
       PlayerPrefs.SetFloat("AttackSpeed",AttackSpeed[AttackSpeedValue]);
       PlayerPrefs.SetFloat("Armor",Armor[ArmorValue]);
       PlayerPrefs.SetFloat("Glory",Glory[GloryValue]);
       PlayerPrefs.SetFloat("Gold",Gold[GoldValue]);
       PlayerPrefs.SetFloat("EXP",EXP[EXPValue]);
       
       //PlayerPrefs.SetFloat("Stamina", MainMenu.moneyBear);
       PlayerPrefs.Save();
   }

   private void OnApplicationQuit()
   {
       OnSaveUpStatus();
   }

   public void UpdateText()
   {
       if (StrenghMax == false)
       {
           StrengthTextPrice.text = "" + priceStrength[priceStrengthValue];
       }
       if (DamageMax == false)
       {
           DamageTextPrice.text = "" + priceDamage[priceDamageValue];
       }
       if (RegenerationMax == false)
       {
           RegenerationTextPrice.text = "" + priceRegeneration[priceRegenerationValue];
       }
       if (SpeedMax == false)
       {
           SpeedTextPrice.text = "" + priceSpeed[priceSpeedValue];
       }
       if (AttackSpeedMax == false)
       {
           AttackSpeedTextPrice.text = "" + priceAttackSpeed[priceAttackSpeedValue];
       }
       if (ArmorMax == false)
       {
           ArmorTextPrice.text = "" + priceArmor[priceArmorValue];
       }
       if (GloryMax == false)
       {
           GloryTextPrice.text = "" + priceGlory[priceGloryValue];
       }
       if (GoldMax == false)
       {
           GoldTextPrice.text = "" + priceGold[priceGoldValue];
       }
       if (EXPMax == false)
       {
           EXPTextPrice.text = "" + priceEXP[priceEXPValue];
       }
   }

   public void UpDateStatus()
   {
       PlayerMovement.Hp = Strength[StrengthValue];
       PlayerMovement.MaxHp = Strength[StrengthValue];
       PlayerMovement.Damage = Damage[DamageValue];
       PlayerMovement.RegenHp = Regeneration[RegenerationValue];
       PlayerMovement.speedPlayer = Speed[SpeedValue];
       PlayerMovement.defospeed = Speed[SpeedValue];
       PlayerMovement.AttackSpeed = AttackSpeed[AttackSpeedValue];
       PlayerMovement.Armor = Armor[ArmorValue];
       spawnSelectabilitySystem.Glory = Glory[GloryValue];
       HamburgerMenuBar.XGold = Gold[GoldValue];
       HamburgerMenuBar.XEXP = EXP[EXPValue];
   }

   public void ResetStatus()
   {
       if (textConsole.text == "Reset")
       { 
           
           Strength[StrengthValue] = Strength[0];
           Damage[DamageValue] = Damage[0];
           Regeneration[RegenerationValue] = Regeneration[0];
           Speed[SpeedValue] = Speed[0];
           AttackSpeed[AttackSpeedValue] = AttackSpeed[0];
           Armor[ArmorValue] = Armor[0];
           Glory[GloryValue] = Glory[0];
           Gold[GoldValue] = Gold[0];
           EXP[EXPValue] = EXP[0];

           StrengthValue = 0;
           DamageValue = 0;
           RegenerationValue = 0;
           SpeedValue = 0;
           AttackSpeedValue = 0;
           ArmorValue = 0;
           GloryValue = 0;
           GoldValue = 0;
           EXPValue = 0;

           priceStrengthValue = 0;
           priceDamageValue = 0;
           priceRegenerationValue = 0;
           priceSpeedValue = 0;
           priceAttackSpeedValue = 0;
           priceArmorValue = 0;
           priceGloryValue = 0;
           priceGoldValue = 0;
           priceEXPValue = 0;

           GoldTextPrice.text = "" + priceGold[priceGoldValue];
           EXPTextPrice.text = "" + priceEXP[priceEXPValue];
           StrengthTextPrice.text = "" + priceStrength[priceStrengthValue];
           DamageTextPrice.text = "" + priceDamage[priceDamageValue];
           RegenerationTextPrice.text = "" + priceRegeneration[priceRegenerationValue];
           SpeedTextPrice.text = "" + priceSpeed[priceSpeedValue];
           AttackSpeedTextPrice.text = "" + priceAttackSpeed[priceAttackSpeedValue];
           ArmorTextPrice.text = "" + priceArmor[priceArmorValue];
           GloryTextPrice.text = "" + priceGlory[priceGloryValue];
       
           //TextValue
           StrengthText.text = "Strength  " + Strength[StrengthValue];
           DamageText.text = "Damage  " + Damage[DamageValue];
           RegenerationText.text = "Regeneration  " + Regeneration[RegenerationValue] + "%";
           SpeedText.text = "Speed  " + Speed[SpeedValue] + "%";
           AttackSpeedText.text = "AttackSpeed  " + AttackSpeed[AttackSpeedValue] + "%";
           ArmorText.text = "Armor  " + Armor[ArmorValue];
           GloryText.text = "Glory  " + Glory[GloryValue];
           GoldText.text = "Gold  " + Gold[GoldValue] + "%";
           EXPText.text = "EXP.  " + EXP[EXPValue] + "%";

           StrenghMax = false;
           DamageMax = false;
           RegenerationMax = false;
           SpeedMax = false;
           AttackSpeedMax = false;
           ArmorMax = false;
           GloryMax = false;
           GoldMax = false;
           EXPMax = false;

           StrengthButtonUI.enabled = true;
           DamageButtonUI.enabled = true;
           RegenerationButtonUI.enabled = true;
           SpeedButtonUI.enabled = true;
           AttackSpeedButtonUI.enabled = true;
           ArmorButtonUI.enabled = true;
           GloryButtonUI.enabled = true;
           GoldButtonUI.enabled = true;
           EXPButtonUI.enabled = true;

           textConsole.text = "";
           OnSaveUpStatus();
       }
      
   }
}

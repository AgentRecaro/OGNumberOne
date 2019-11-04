using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusSystem : MonoBehaviour
{
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
    

    // Start is called before the first frame update
    void Start()
    {
        priceStrength = new int[]{ 200, 250, 350, 500, 750};
        priceDamage = new int[]{ 200, 250, 350, 500, 750};
        priceRegeneration = new int[]{ 200, 250, 350, 500, 750};
        priceSpeed = new int[]{ 200, 250, 350, 500, 750};
        priceAttackSpeed = new int[]{ 200, 250, 350, 500, 750};
        priceArmor = new int[]{ 200, 250, 350, 500, 750};
        priceGlory = new int[]{ 2000};
        priceGold = new int[]{ 200, 250, 350, 500, 750};
        priceEXP = new int[]{ 200, 250, 350, 500, 750};
        Strength = new float[]{ 100, 110, 130, 160, 210, 280};//Value= 6
        Damage = new float[]{ 100, 110, 130, 160, 200, 250};//Value= 6
        Regeneration = new float[]{ 0, 0.25f, 0.3f, 0.5f, 0.75f, 1f};//Value= 6
        Speed = new float[]{ 5f, 5.25f, 5.55f, 6.05f, 6.8f, 7.8f};//Value= 6
        AttackSpeed = new float[]{ 3, 3.25f, 3.55f, 4.05f, 4.8f, 5.8f};//Value= 6
        Armor = new float[]{ 100, 120, 150, 200, 270, 370};//Value= 6
        Glory = new float[]{ 0, 1};//Value= 2
        Gold = new float[]{ 10, 10.5f, 11.25f, 12.25f, 13.75f, 15.75f};//Value= 6
        EXP = new float[]{ 2, 2.25f, 2.55f, 3.05f, 3.8f, 4.8f};//Value= 6 
        //priceValue = PlayerPrefs.GetInt("PriceValue", priceValue);
        StrengthValue = PlayerPrefs.GetInt("StengthValue", StrengthValue);
        DamageValue = PlayerPrefs.GetInt("DamageValue", DamageValue);
        RegenerationValue = PlayerPrefs.GetInt("RegenerationValue", RegenerationValue);
        //SpeedValue = PlayerPrefs.GetInt("SpeedValue", SpeedValue);
        AttackSpeedValue = PlayerPrefs.GetInt("AttackSpeedValue", AttackSpeedValue);
        ArmorValue = PlayerPrefs.GetInt("ArmorValue", ArmorValue);
        //Glory
        GoldValue = PlayerPrefs.GetInt("GoldValue", GoldValue);
        EXPValue = PlayerPrefs.GetInt("EXPValue", EXPValue);
        StrengthSlider.maxValue = 5;
        DamageSlider.maxValue = 5;
        RegenerationSlider.maxValue = 5;
        SpeedSlider.maxValue = 5;
        AttackSpeedSlider.maxValue = 5;
        ArmorSlider.maxValue = 5;
        GlorySlider.maxValue = 1;
        GoldSlider.maxValue = 5;
        EXPSlider.maxValue = 5;
        StrengthText.text = "Strength  " + Strength[StrengthValue];
        DamageText.text = "Damage  " + Damage[DamageValue];
        RegenerationText.text = "Regeneration  " + Regeneration[RegenerationValue] + "%";
        SpeedText.text = "Speed  " + Speed[SpeedValue] + "%";
        AttackSpeedText.text = "AttackSpeed  " + AttackSpeed[AttackSpeedValue] + "%";
        ArmorText.text = "Armor  " + Armor[ArmorValue];
        GloryText.text = "Glory  " + Glory[GloryValue];
        GoldText.text = "Gold  " + Gold[GoldValue] + "%";
        EXPText.text = "EXP.  " + EXP[EXPValue] + "%";
        StrengthTextPrice.text = "" + priceStrength[priceStrengthValue];
        DamageTextPrice.text = "" + priceDamage[priceDamageValue];
        RegenerationTextPrice.text = "" + priceRegeneration[priceRegenerationValue];
        SpeedTextPrice.text = "" + priceSpeed[priceSpeedValue];
        AttackSpeedTextPrice.text = "" + priceAttackSpeed[priceAttackSpeedValue];
        ArmorTextPrice.text = "" + priceArmor[priceArmorValue];
        GloryTextPrice.text = "" + priceGlory[priceGloryValue];
        GoldTextPrice.text = "" + priceGold[priceGoldValue];
        EXPTextPrice.text = "" + priceEXP[priceEXPValue];
    }

    // Update is called once per frame
    void Update()
    {
        //SpeedText.text = "Speed  " + Speed[SpeedValue];
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
       //PlayerPrefs.SetInt("SpeedValue", SpeedValue);
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
}

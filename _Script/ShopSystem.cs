using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    public static bool Soul60 = false;
    public static bool Soul300 = false;
    public static bool Soul680 = false;
    public static bool Soul1280 = false;
    public static bool Soul3280 = false;
    public static bool Soul6480 = false;
    public static bool TeddyBear1500 = false;
    public static bool TeddyBear4500 = false;
    public static bool TeddyBear13500 = false;
    [SerializeField] private Canvas PanelConFirm = null;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Button60SoulON()
    {
        Soul60 = true;
        PanelConFirm.GetComponent<Canvas>().enabled = true;
    }
    
    public void Button300SoulON()
    {
        Soul300 = true;
        PanelConFirm.GetComponent<Canvas>().enabled = true;
    }
    
    public void Button680SoulON()
    {
        Soul680 = true;
        PanelConFirm.GetComponent<Canvas>().enabled = true;
    }
    
    public void Button1280SoulOn()
    {
        Soul1280 = true;
        PanelConFirm.GetComponent<Canvas>().enabled = true;
    }
    
    public void Button3280SoulON()
    {
        Soul3280 = true;
        PanelConFirm.GetComponent<Canvas>().enabled = true;
    }
    
    public void Button6480SoulON()
    {
        Soul6480 = true;
        PanelConFirm.GetComponent<Canvas>().enabled = true;
    }
    
    public void Button1500TeddyBearON()
    {
        TeddyBear1500 = true;
        PanelConFirm.GetComponent<Canvas>().enabled = true;
    }
    
    public void Button4500TeddyBearON()
    {
        TeddyBear4500 = true;
        PanelConFirm.GetComponent<Canvas>().enabled = true;
    }
    
    public void Button13500TeddyBearON()
    {
        TeddyBear13500 = true;
        PanelConFirm.GetComponent<Canvas>().enabled = true;
    }

    public void ButtonConFirmYes()
    {
        if (Soul60 == true)
        {
            MainMenu.Soul += 60;
            ButtonConFirmNo();
        }

        if (Soul300 == true)
        {
            MainMenu.Soul += 300;
            ButtonConFirmNo();
        }

        if (Soul680 == true)
        {
            MainMenu.Soul += 680;
            ButtonConFirmNo();
        }

        if (Soul1280 == true)
        {
            MainMenu.Soul += 1280;
            ButtonConFirmNo();
        }

        if (Soul3280 == true)
        {
            MainMenu.Soul += 3280;
            ButtonConFirmNo();
        }

        if (Soul6480 == true)
        {
            MainMenu.Soul += 6480;
            ButtonConFirmNo();
        }

        if (TeddyBear1500 == true)
        {
            if (MainMenu.Soul >= 300)
            {
                MainMenu.Soul -= 300;
                MainMenu.moneyBear += 1500;
            }
            else
            {
                ButtonConFirmNo();
            }
            ButtonConFirmNo();
        }

        if (TeddyBear4500 == true)
        {
            if (MainMenu.Soul >= 800)
            {
                MainMenu.Soul -= 800;
                MainMenu.moneyBear += 4500;
            }
            else
            {
                ButtonConFirmNo();
            }
            ButtonConFirmNo();
        }

        if (TeddyBear13500 == true)
        {
            if (MainMenu.Soul >= 2000)
            {
                MainMenu.Soul -= 2000;
                MainMenu.moneyBear += 13500;
            }
            else
            {
                ButtonConFirmNo();
            }
            ButtonConFirmNo();
        }
        
//        Soul60 = false;
//        Soul300 = false;
//        Soul680 = false;
//        Soul1280 = false;
//        Soul3280 = false;
//        Soul6480 = false;
//        TeddyBear1500 = false;
//        TeddyBear4500 = false;
//        TeddyBear13500 = false;
//        PanelConFirm.GetComponent<Canvas>().enabled = false;
    }

    public void ButtonConFirmNo()
    {
        Soul60 = false;
        Soul300 = false;
        Soul680 = false;
        Soul1280 = false;
        Soul3280 = false;
        Soul6480 = false;
        TeddyBear1500 = false;
        TeddyBear4500 = false;
        TeddyBear13500 = false;
        PanelConFirm.GetComponent<Canvas>().enabled = false;
    }
}

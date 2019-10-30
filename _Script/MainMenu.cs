using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    static int moneyBear = 0;
    static float StaminaValue = 30;
    public bool Map = false;
    public bool Status = false;
    public bool Inventory = false;
    public bool Shop = false;
    [SerializeField] private GameObject UIMap = null;
    [SerializeField] private GameObject UIStatus = null;
    [SerializeField] private GameObject UIInventory = null;
    [SerializeField] private GameObject UIShop = null;
    [SerializeField] private GameObject UISetting = null;
    [SerializeField] private GameObject ButtonGamePlay = null;
    [SerializeField] private Text MoneyBearText = null;
    [SerializeField] private Text GemText = null;
    [SerializeField] private Text StaminaText = null;
    [SerializeField] private Slider StaminaSlider = null;

    // Start is called before the first frame update
    void Start()
    {
        Map = true;
    }

    // Update is called once per frame
    void Update()
    {
        StaminaSlider.value = StaminaValue;
        MoneyBearText.text = moneyBear.ToString();
        StaminaText.text = StaminaValue + " /30";
        if (Map == true)
        {
            UIMap.SetActive(true);
            GameObject.Find("Button Map").GetComponent<Button>().interactable = false;
        }
        else
        {
            UIMap.SetActive(false);
            GameObject.Find("Button Map").GetComponent<Button>().interactable = true;
        }

        if (Status == true)
        {
            UIStatus.SetActive(true);
            GameObject.Find("Button Status").GetComponent<Button>().interactable = false;
        }
        else
        {
            UIStatus.SetActive(false);
            GameObject.Find("Button Status").GetComponent<Button>().interactable = true;
        }

        if (Inventory == true)
        {
            UIInventory.SetActive(true);
            GameObject.Find("Button Inventory").GetComponent<Button>().interactable = false;
        }
        else
        {
            UIInventory.SetActive(false);
            GameObject.Find("Button Inventory").GetComponent<Button>().interactable = true;
        }

        if (Shop == true)
        {
            UIShop.SetActive(true);
            GameObject.Find("Button Shop").GetComponent<Button>().interactable = false;
        }
        else
        {
            UIShop.SetActive(false);
            GameObject.Find("Button Shop").GetComponent<Button>().interactable = true;
        }

        if (StaminaValue <= 0)
        {
            ButtonGamePlay.GetComponent<Button>().enabled = false;
        }
        else
        {
            ButtonGamePlay.GetComponent<Button>().enabled = true;
        }
    }

    public void AddMoney(int AddMoneyBear)
    {
        moneyBear += AddMoneyBear;
        PlayerPrefs.SetInt("CurrentMoney", moneyBear);
        MoneyBearText.text = "" + moneyBear;
    }

    public void UIMapOn()
    {
        Map = true;
        Status = false;
        Inventory = false;
        Shop = false;
    }

    public void UIStatusOn()
    {
        Map = false;
        Status = true;
        Inventory = false;
        Shop = false;
    }

    public void UIInventoryOn()
    {
        Map = false;
        Status = false;
        Inventory = true;
        Shop = false;
    }

    public void UIShopOn()
    {
        Map = false;
        Status = false;
        Inventory = false;
        Shop = true;
    }

    public void UISttingOn()
    {
        UISetting.SetActive(true);
    }

    public void UISttingOff()
    {
        UISetting.SetActive(false);
    }

    public void GameStart()
    {
        EnemyCount.CountEnemydieAll = 0;
        HamburgerMenuBar.MoneyBear = 0;
        SceneManager.LoadScene("Stage_01");
        StaminaValue -= 5;
    }
    
}

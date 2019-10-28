using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool Map = false;
    public bool Status = false;
    public bool Inventory = false;
    public bool Shop = false;
    [SerializeField] private GameObject UIMap = null;
    [SerializeField] private GameObject UIStatus = null;
    [SerializeField] private GameObject UIInventory = null;
    [SerializeField] private GameObject UIShop = null;
    [SerializeField] private GameObject UISetting = null;
    
    // Start is called before the first frame update
    void Start()
    {
        Map = true;

    }

    // Update is called once per frame
    void Update()
    {
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
        SceneManager.LoadScene("Stage_01");
        GameObject.Find("stamina").GetComponent<Slider>().value -= 5;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ZoneBuy2 : MonoBehaviour
{
    public GameObject ControllerModule;
    private Controller controller;

    public int costForZone2;
    public int costForZone3;
    public int costForZone4;
    public int costForZone5;

    public GameObject[] zone2ToBuy;
    public GameObject[] zone3ToBuy;
    public GameObject[] zone4ToBuy;
    public GameObject[] zone5ToBuy;

    public GameObject[] zone2Visuals;
    public GameObject[] zone3Visuals;
    public GameObject[] zone4Visuals;
    public GameObject[] zone5Visuals;

    public Button zone2Buy;
    public Button zone3Buy;
    public Button zone4Buy;
    public Button zone5Buy;

    public Text zone2BuyCost;
    public Text zone3BuyCost;
    public Text zone4BuyCost;
    public Text zone5BuyCost;

    public GameObject zone02BuyMenu;
    public GameObject zone03BuyMenu;
    public GameObject zone04BuyMenu;
    public GameObject zone05BuyMenu;

    public GameObject zone02Slider;
    public GameObject zone03Slider;
    public GameObject zone04Slider;
    public GameObject zone05Slider;

    public bool zone02Bought;
    public bool zone03Bought;
    public bool zone04Bought;
    public bool zone05Bought;

    public bool started = false;

    public bool challengeMode;

    void Start()
    {
        controller = ControllerModule.GetComponent("Controller") as Controller;
    }

    public void Update()
    {
        costForZone2 = zone2ToBuy.Length * 10;
        costForZone3 = zone3ToBuy.Length * 10;
        costForZone4 = zone4ToBuy.Length * 10;
        costForZone5 = zone5ToBuy.Length * 10;

        if (zone02Bought == false)
        {
            zone2BuyCost.text = ("DownTown " + costForZone2.ToString() + "$");

            if (controller.money < costForZone2)
            {
                zone2Buy.interactable = false;
            }

            if (controller.money > (costForZone2 - 1))
            {
                zone2Buy.interactable = true;
            }
        }

        if (zone03Bought == false)
        {
            zone3BuyCost.text = ("Suburbs " + costForZone3.ToString() + "$");

            if (controller.money < costForZone3)
            {
                zone3Buy.interactable = false;
            }

            if (controller.money > (costForZone3 - 1))
            {
                zone3Buy.interactable = true;
            }
        }




        if (zone04Bought == false)
        {
            zone4BuyCost.text = ("Neighborhood " + costForZone4.ToString() + "$");

            if (controller.money < costForZone4)
            {
                zone4Buy.interactable = false;
            }

            if (controller.money > (costForZone4 - 1))
            {
                zone4Buy.interactable = true;
            }
        }



        if (zone05Bought == false)
        {
            zone5BuyCost.text = ("Rural " + costForZone5.ToString() + "$");

            if (controller.money < costForZone5)
            {
                zone5Buy.interactable = false;
            }

            if (controller.money > (costForZone5 - 1))
            {
                zone5Buy.interactable = true;
            }
        }
    }

    public void GetZoneBuys()
    {
        started = true;
        zone2ToBuy = GameObject.FindGameObjectsWithTag("Zone2ToBuy");
        zone3ToBuy = GameObject.FindGameObjectsWithTag("Zone3ToBuy");
        zone4ToBuy = GameObject.FindGameObjectsWithTag("Zone4ToBuy");
        zone5ToBuy = GameObject.FindGameObjectsWithTag("Zone5ToBuy");

        zone2Visuals = GameObject.FindGameObjectsWithTag("zone2Visuals");
        zone3Visuals = GameObject.FindGameObjectsWithTag("zone3Visuals");
        zone4Visuals = GameObject.FindGameObjectsWithTag("zone4Visuals");
        zone5Visuals = GameObject.FindGameObjectsWithTag("zone5Visuals");

        for (int i = 0; i < zone2ToBuy.Length; i++)
        {
            zone2Visuals[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < zone3ToBuy.Length; i++)
        {
            zone3Visuals[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < zone4ToBuy.Length; i++)
        {
            zone4Visuals[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < zone5ToBuy.Length; i++)
        {
            zone5Visuals[i].gameObject.SetActive(false);
        }

        if (challengeMode == true)
        {
            BuyZone2();
            BuyZone3();
            BuyZone4();
            BuyZone5();
        }
    }

    public void BuyZone2()
    {
        for (int i = 0; i < zone2ToBuy.Length; i++)
        {
            Destroy(zone2ToBuy[i].gameObject);
            zone2Visuals[i].gameObject.SetActive(true);
        }

        zone02Bought = true;
        if (challengeMode == false)
        {
            controller.money -= costForZone2;
        }
        controller.CloseMenus();
        Destroy(zone02BuyMenu);
        zone02Slider.SetActive(true);
    }

    public void BuyZone3()
    {
        for (int i = 0; i < zone3ToBuy.Length; i++)
        {
            Destroy(zone3ToBuy[i].gameObject);
            zone3Visuals[i].gameObject.SetActive(true);
        }

        zone03Bought = true;
        if (challengeMode == false)
        {
            controller.money -= costForZone3;
        }
        controller.CloseMenus();
        Destroy(zone03BuyMenu);
        zone03Slider.SetActive(true);
    }

    public void BuyZone4()
    {
        for (int i = 0; i < zone4ToBuy.Length; i++)
        {
            Destroy(zone4ToBuy[i].gameObject);
            zone4Visuals[i].gameObject.SetActive(true);
        }

        zone04Bought = true;
        if (challengeMode == false)
        {
            controller.money -= costForZone4;
        }
        controller.CloseMenus();
        Destroy(zone04BuyMenu);
        zone04Slider.SetActive(true);
    }

    public void BuyZone5()
    {
        for (int i = 0; i < zone5ToBuy.Length; i++)
        {
            Destroy(zone5ToBuy[i].gameObject);
            zone5Visuals[i].gameObject.SetActive(true);
        }

        zone05Bought = true;
        if (challengeMode == false)
        {
            controller.money -= costForZone5;
        }
        controller.CloseMenus();
        Destroy(zone05BuyMenu);
        zone05Slider.SetActive(true);
    }
}

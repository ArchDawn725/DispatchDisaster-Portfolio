using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ZoneBuy : MonoBehaviour
{
    public GameObject ControllerModule;
    private Controller controller;

    public GameObject zone02BuyMenu;

    public int cost;

    public Button zoneBuy;
    public Text costText;
    public TextMesh costTextOnButton;

    public GameObject thisZone;
    public GameObject zone;


    // Start is called before the first frame update
    void Start()
    {
        controller = ControllerModule.GetComponent("Controller") as Controller;
        StartCoroutine(CostIncrease());
    }

    // Update is called once per frame
    void Update()
    {
        costText.text = ("Zone 1 " + cost.ToString() + "$");
        costTextOnButton.text = ("Zone 1 " + cost.ToString() + "$");

        if (controller.money < cost)
        {
            zoneBuy.interactable = false;
        }

        if (controller.money > (cost - 1))
        {
            zoneBuy.interactable = true;
        }


    }

    public void ClickedOn()
    {
        zone02BuyMenu.SetActive(true);
    }

    public void ClickedOff()
    {
        zone02BuyMenu.SetActive(false);
    }

    public IEnumerator CostIncrease()
    {
        while (cost > 0)
        {
            yield return new WaitForSeconds(1.0f);
            cost++;
        }

    }

    public void ZoneBuyButton()
    {
        controller.money -= cost;
        controller.CloseMenus();
        zone.SetActive(true);
        controller.GetSpawnPoints();
        controller.WaitTimeMax += 5;
        thisZone.SetActive(false);
    }
}

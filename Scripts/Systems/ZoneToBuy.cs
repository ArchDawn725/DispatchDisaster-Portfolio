using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneToBuy : MonoBehaviour
{
    public GameObject zoneControl;
    public ZoneBuy2 zoneBuy2;


    public GameObject color;

    public void Start()
    {
        zoneControl = GameObject.Find("ZoneBuy");
        zoneBuy2 = zoneControl.GetComponent("ZoneBuy2") as ZoneBuy2;
    }

    void Update()
    {
        if (zoneBuy2.started == true)
        {
            color.SetActive(true);
        }
        else
        {
            color.SetActive(false);
        }
    }
}

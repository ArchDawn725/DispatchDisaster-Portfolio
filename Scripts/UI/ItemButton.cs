using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{

    public Button itemButtonPress;

    public GameObject ControllerModule;
    public Invetory invetory;
    public GameObject Unit;

    public Text Name;
    public Text Status;

    public Ambulance ambulance;
    public FireTruck fireTruck;
    public PoliceCar policeCar;

    public Hospital hospital;
    public FireStation fireStation;
    public PoliceStation policeStation;

    public bool isEMS;
    public bool isFire;
    public bool isPolice;

    public bool isHospital;
    public bool isFireStation;
    public bool isPoliceStation;

    // Start is called before the first frame update
    void Start()
    {
        ControllerModule = GameObject.Find("Controller Module");
        invetory = ControllerModule.GetComponent("Invetory") as Invetory;

        invetory.itemButtonPress = itemButtonPress;

        if (invetory.isEMS == true)
        {
            isEMS = true;
        }

        if (invetory.isFire == true)
        {
            isFire = true;
        }

        if (invetory.isPolice == true)
        {
            isPolice = true;
        }

        if (invetory.isHospital == true)
        {
            isHospital = true;
        }

        if (invetory.isFireStation == true)
        {
            isFireStation = true;
        }

        if (invetory.isPoliceStation == true)
        {
            isPoliceStation = true;
        }



        if (isEMS == true)
        {
            Unit = invetory.ambulance;
            ambulance = Unit.GetComponent<Ambulance>();
            Name.text = ambulance.gameObject.ToString();
        }

        if (isFire == true)
        {
            Unit = invetory.ambulance;
            fireTruck = Unit.GetComponent<FireTruck>();
            Name.text = fireTruck.gameObject.ToString();
        }

        if (isPolice == true)
        {
            Unit = invetory.ambulance;
            policeCar = Unit.GetComponent<PoliceCar>();
            Name.text = policeCar.gameObject.ToString();
        }

        if (isHospital == true)
        {
            Unit = invetory.ambulance;
            hospital = Unit.GetComponent<Hospital>();
            Name.text = hospital.gameObject.ToString();
        }

        if (isFireStation == true)
        {
            Unit = invetory.ambulance;
            fireStation = Unit.GetComponent<FireStation>();
            Name.text = fireStation.gameObject.ToString();
        }

        if (isPoliceStation == true)
        {
            Unit = invetory.ambulance;
            policeStation = Unit.GetComponent<PoliceStation>();
            Name.text = policeStation.gameObject.ToString();
        }

        invetory.Reset();

    }

    // Update is called once per frame
    void Update()
    {
        if (isEMS == true)
        {
            if (ambulance.available == true)
            {
                Status.text = ("Available");
            }
            if (ambulance.transporting == true)
            {
                Status.text = ("Transporting");
            }
            if (ambulance.onScene == true)
            {
                Status.text = ("OnScene");
            }
            if (ambulance.atDestintation == true)
            {
                Status.text = ("atDestination");
            }
            if (ambulance.enroute == true)
            {
                Status.text = ("Enroute");
            }
            if (ambulance.isSold == true)
            {
                Destroy(this.gameObject);
            }
        }


        if (isFire == true)
        {
            if (fireTruck.available == true)
            {
                Status.text = ("Available");
            }
            if (fireTruck.transporting == true)
            {
                Status.text = ("Transporting");
            }
            if (fireTruck.onScene == true)
            {
                Status.text = ("OnScene");
            }
            if (fireTruck.atDestintation == true)
            {
                Status.text = ("atDestination");
            }
            if (fireTruck.enroute == true)
            {
                Status.text = ("Enroute");
            }
            if (fireTruck.isSold == true)
            {
                Destroy(this.gameObject);
            }
        }

        if (isPolice == true)
        {
            if (policeCar.available == true)
            {
                Status.text = ("Available");
            }
            if (policeCar.transporting == true)
            {
                Status.text = ("Transporting");
            }
            if (policeCar.onScene == true)
            {
                Status.text = ("OnScene");
            }
            if (policeCar.atDestintation == true)
            {
                Status.text = ("atDestination");
            }
            if (policeCar.enroute == true)
            {
                Status.text = ("Enroute");
            }
            if (policeCar.isSold == true)
            {
                Destroy(this.gameObject);
            }
        }
    }
}

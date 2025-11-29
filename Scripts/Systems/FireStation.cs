using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class FireStation : MonoBehaviour
{
    public Renderer rend;

    public float ambulanceCount = 0;

    private Ambulance ambulanceS;
    private FireTruck fireTruckS;
    private PoliceCar policeCarS;

    public GameObject ControllerModule;
    private Controller controller;

    public GameObject Canvas;
    public GameObject fireStationMenu;

    public GameObject fireRescue;
    public GameObject fireTruck;
    public GameObject ladderTruck;
    public GameObject fireBus;

    public Transform here;

    public Invetory invetory;
    public Sprite ambulanceImage;
    public GameObject itemButton;
    public Button itemButtonPress;
    public Vision cam;

    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.Find("Menus");

        //Assigns the first child of the first child of the Game Object this script is attached to.
        fireStationMenu = Canvas.gameObject.transform.GetChild(2).gameObject;

        rend = GetComponent<Renderer>();

        ControllerModule = GameObject.Find("Controller Module");
        controller = ControllerModule.GetComponent("Controller") as Controller;
        invetory = ControllerModule.GetComponent("Invetory") as Invetory;
        cam = Camera.main.GetComponent("Vision") as Vision;

        Vector3 pos = transform.position;
        pos.y = 0;
        transform.position = pos;

        for (int i = 0; i < invetory.slots.Length; i++)
        {
            if (invetory.isFull[i] == false)
            {
                invetory.isFull[i] = true;
                Instantiate(itemButton, invetory.slots[i].transform, false);
                break;
            }
        }

        invetory.ambulance = this.gameObject;
        invetory.isFire = false;
        invetory.isEMS = false;
        invetory.isPolice = false;
        invetory.isHospital = false;
        invetory.isFireStation = true;
        invetory.isPoliceStation = false;

        Invoke("Sorting", 1);
    }


    public void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "Ambulance" || other.gameObject.tag == "AirAmbulance" || other.gameObject.tag == "FireTruck" || other.gameObject.tag == "PoliceCar"
            || other.gameObject.tag == "EMSFireHybrid" || other.gameObject.tag == "PoliceEMSHybrid" || other.gameObject.tag == "EMSPoliceFireHybrid" || other.gameObject.tag == "FirePoliceHybrid" || other.gameObject.tag == "FireBus"
            || other.gameObject.tag == "PoliceSpotter")
        {
            ambulanceCount++;

            if (ambulanceCount > 0)
            {
                rend.enabled = false;
                gameObject.layer = 0;
            }
        }

        if (other.gameObject.tag == "FireBus")
        {
            if (other.GetComponent<FireTruck>() != null)
            {
                fireTruckS = other.GetComponent<FireTruck>();

                if (fireTruckS.fireBusCalls > 0)
                {
                    ambulanceCount--;
                    fireTruckS.AtDestination();
                }
            }
        }

        if (other.gameObject.tag == "FireTruck" || other.gameObject.tag == "EMSFireHybrid" || other.gameObject.tag == "EMSPoliceFireHybrid" || other.gameObject.tag == "FirePoliceHybrid")
        {
            if (other.GetComponent<Ambulance>() != null)
            {
                ambulanceS = other.GetComponent<Ambulance>();

                if (ambulanceS.CaughtFire == true)
                {
                    if (ambulanceS.transporting == true)
                    {
                        ambulanceCount--;
                        ambulanceS.AtDestinationTimerStart();
                        ambulanceS.AtDestination();
                    }
                }
            }

            if (other.GetComponent<FireTruck>() != null)
            {
                fireTruckS = other.GetComponent<FireTruck>();

                if (fireTruckS.CaughtFire == true)
                {
                    if (fireTruckS.transporting == true)
                    {
                        ambulanceCount--;
                        fireTruckS.AtDestination();
                    }
                }
            }

            if (other.GetComponent<PoliceCar>() != null)
            {
                policeCarS = other.GetComponent<PoliceCar>();

                if (policeCarS.CaughtFire == true)
                {
                    if (policeCarS.transporting == true)
                    {
                        ambulanceCount--;
                        policeCarS.AtDestinationTimerStart();
                        policeCarS.AtDestination();
                    }
                }
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ambulance" || other.gameObject.tag == "AirAmbulance" || other.gameObject.tag == "FireTruck" || other.gameObject.tag == "PoliceCar"
            || other.gameObject.tag == "EMSFireHybrid" || other.gameObject.tag == "PoliceEMSHybrid" || other.gameObject.tag == "EMSPoliceFireHybrid" || other.gameObject.tag == "FirePoliceHybrid" || other.gameObject.tag == "FireBus"
            || other.gameObject.tag == "PoliceSpotter")
        {
            ambulanceCount--;

            if (ambulanceCount == 0)
            {
                rend.enabled = true;
                gameObject.layer = 17;
            }
        }
    }

    public void SpawnFireRescue()
    {
        Instantiate(fireRescue, here.transform.position, Quaternion.identity);
    }

    public void SpawnFireTruck()
    {
        Instantiate(fireTruck, here.transform.position, Quaternion.identity);
    }

    public void SpawnLadderTruck()
    {
        Instantiate(ladderTruck, here.transform.position, Quaternion.identity);
    }

    public void SpawnFireBus()
    {
        Instantiate(fireBus, here.transform.position, Quaternion.identity);
    }

    public void Sorting()
    {
        itemButtonPress = invetory.itemButtonPress;

        itemButtonPress.onClick.AddListener(ItemButtonClicked);
    }

    public void ItemButtonClicked()
    {
        cam.camPos = new Vector3(transform.position.x, Camera.main.transform.position.y, transform.position.z - (Camera.main.transform.position.y / 2.5f));
        controller.CloseMenus();
        controller.fireStationS = this;
        controller.FireStationMenu();
        //        this.isSelected = true;
        //        controller.AmbulanceMenu();
    }
}

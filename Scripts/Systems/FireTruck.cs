using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class FireTruck : MonoBehaviour
{

    public int level;

    public float speed;
    public bool isSlowed;
    public bool isSpeedup;

    private NavMeshAgent navMeshAgent;
    public GameObject ControllerModule;
    private Controller controller;
    public Invetory invetory;

    public bool enroute = false;
    public bool onScene = false;
    public bool transporting = false;
    public bool atDestintation = false;
    public bool available = true;

    public bool isSelected = false;

    public float timer;
    public float onSceneTime = 0;
    public float atDestinationTime = 0;

    public float hoverAmount;

    public GameObject onScenePhrase;
    public GameObject transportingPhrase;
    public GameObject destinationPhrase;
    public GameObject availablePhrase;
    public GameObject enroutePhrase;
    //    public TextMesh levelIndicator;

    public static Vector3[] path = new Vector3[0];

    public LineRenderer linerenderer;

    public int priority;
    public int zone;

    public GameObject Canvas;
    public GameObject selectedUnitMenu;

    public Sprite ambulanceImage;
    public GameObject itemButton;

    public Button itemButtonPress;

    public GameObject highLight;

    public float newSpeed;
    public float newTimer;

    public GameObject isEMS;
    public GameObject isFire;
    public GameObject isPolice;

    public bool CaughtEMS;
    public bool CaughtFire;
    public bool CaughtPolice;

    public GameObject TEMS;
    public GameObject TFire;
    public GameObject TPolice;

    public bool cannotHybrid;

    public bool isFireBus;
    public int fireBusCalls;

    public int callPriority1;
    public int callZone1;
    public int callPriority2;
    public int callZone2;
    public int callPriority3;
    public int callZone3;
    public int callPriority4;
    public int callZone4;
    public int callPriority5;
    public int callZone5;

    public GameObject TFire2;
    public GameObject TFire3;
    public GameObject TFire4;
    public GameObject TFire5;

    public Vision cam;

    public Collider collider;

    public Vector3 curPos;
    public Vector3 lastPos;

    public bool isSold;
    public int sellPrice;
    // Use this for initialization
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        ControllerModule = GameObject.Find("Controller Module");
        controller = ControllerModule.GetComponent("Controller") as Controller;
        invetory = ControllerModule.GetComponent("Invetory") as Invetory;
        cam = Camera.main.GetComponent("Vision") as Vision;

        availablePhrase.SetActive(true);

        linerenderer = GetComponent<LineRenderer>();

        Canvas = GameObject.Find("Menus");

        //Assigns the first child of the first child of the Game Object this script is attached to.
        selectedUnitMenu = Canvas.gameObject.transform.GetChild(0).gameObject;

        if (gameObject.tag == "FireTruck")
        {
            gameObject.name = ("Engine " + controller.fireTruckNumber.ToString());
        }

        if (gameObject.tag == "FireBus")
        {
            gameObject.name = ("Bus " + controller.fireBusNumber.ToString());
            isFireBus = true;
        }

        controller.units.Add(this.gameObject);

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
        invetory.isFire = true;
        invetory.isEMS = false;
        invetory.isPolice = false;
        invetory.isHospital = false;
        invetory.isFireStation = false;
        invetory.isPoliceStation = false;

        Invoke("Sorting", 1);

        navMeshAgent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (available == true || transporting == true)
        {
            linerenderer.enabled = true;

            if (available == true)
            {
                curPos = transform.position;
                if (curPos == lastPos)
                {
                    enroute = false;
                    availablePhrase.SetActive(true);
                    enroutePhrase.SetActive(false);
                }
                else
                {
                    enroute = true;
                    enroutePhrase.SetActive(true);
                    availablePhrase.SetActive(false);
                }
                lastPos = curPos;
            }

            if (isSelected == true)
            {

                highLight.SetActive(true);

                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit, 1000))
                    {
                        navMeshAgent.destination = hit.point;
                        highLight.SetActive(false);
//                        iAmSelected = false;
                        isSelected = false;
                        controller.unitSelected = false;
                    }
                }
            }
        }

        if (navMeshAgent.hasPath)
        {
            linerenderer.positionCount = navMeshAgent.path.corners.Length;
            linerenderer.SetPositions(navMeshAgent.path.corners);
        }
    }

    public void OnScene()
    {
        enroute = false;
        enroutePhrase.SetActive(false);
        navMeshAgent.destination = gameObject.transform.position;
        onScene = true;
        available = false;

        StartCoroutine(OnSceneTimer());
        linerenderer.enabled = false;
    }

    public void Transporting()
    {
        onScene = false;
        transporting = true;

        //transport timer?

        if (CaughtEMS == true)
        {
            TEMS.SetActive(true);
        }

        if (isFireBus == false)
        {
            if (CaughtFire == true)
            {
                TFire.SetActive(true);
            }
        }


        if (CaughtPolice == true)
        {
            TPolice.SetActive(true);
        }
    }

    public void AtDestination()
    {
        collider.enabled = false;
        if (isFireBus == false)
        {
            atDestinationTime = timer;
        }
        if (isFireBus == true)
        {
            atDestinationTime = timer*fireBusCalls;
        }

        navMeshAgent.destination = gameObject.transform.position;
        transporting = false;
        atDestintation = true;
        if (isFireBus == false)
        {
            StartCoroutine(AtDestinationTimer());
        }
        if (isFireBus ==  true)
        {
            StartCoroutine(AtDestinationTimer2());
        }
        linerenderer.enabled = false;
        TEMS.SetActive(false);
        TFire.SetActive(false);
        TPolice.SetActive(false);
    }

    public void Available()
    {
        collider.enabled = true;
        enroute = false;
        onScene = false;
        transporting = false;
        atDestintation = false;
        available = true;
        isSelected = false;
    }

    public IEnumerator OnSceneTimer()
    {
        while (onSceneTime > 0)
        {
            availablePhrase.SetActive(false);
            onScenePhrase.SetActive(true);
            yield return new WaitForSeconds(1.0f);
            onSceneTime--;
        }
        if (onSceneTime <= 0)
        {
            if (isFireBus == false)
            {
                Transporting();
                onScenePhrase.SetActive(false);
                transportingPhrase.SetActive(true);
            }
            if (isFireBus == true)
            {
                onScenePhrase.SetActive(false);

                if (fireBusCalls < 5)
                {
                    Available();
                    availablePhrase.SetActive(true);
                }
                if (fireBusCalls == 5)
                {
                    transportingPhrase.SetActive(true);
                    onScene = false;
                    transporting = true;
                }
            }
        }
    }

    public IEnumerator AtDestinationTimer()
    {
        while (atDestinationTime > 0)
        {
            transportingPhrase.SetActive(false);
            destinationPhrase.SetActive(true);
            yield return new WaitForSeconds(1.0f);
            atDestinationTime--;
        }
        if (atDestinationTime <= 0)
        {
            destinationPhrase.SetActive(false);
            availablePhrase.SetActive(true);


            //change money aspect
//            if (priority > 0)
//            {
//                controller.money += (100 / priority);
//            }

            if (zone == 1)
            {
                controller.zone01Loyalty += 5;
            }

            if (zone == 2)
            {
                controller.zone02Loyalty += 5;
            }

            if (zone == 3)
            {
                controller.zone03Loyalty += 5;
            }

            if (zone == 4)
            {
                controller.zone04Loyalty += 5;
            }

            if (zone == 5)
            {
                controller.zone05Loyalty += 5;
            }
            controller.fireLoyalty += 5;
            controller.allSpawnedCollected--;

            level += 1;
            LevelUp();
            Available();

            CaughtEMS = false;
            CaughtFire = false;
            CaughtPolice = false;
        }
    }

    void OnMouseEnter()
    {
        highLight.SetActive(true);
        //        transform.localScale += Vector3.one * hoverAmount;
    }

    void OnMouseExit()
    {
        highLight.SetActive(false);
        //        transform.localScale -= Vector3.one * hoverAmount;
    }

    public void OnHighway()
    {
        navMeshAgent.speed *= 2;
        isSpeedup = true;
    }

    public void OffHighway()
    {
        navMeshAgent.speed /= 2;
        isSlowed = true;
    }

    public void NormalSpeed()
    {
        navMeshAgent.speed = speed;
        isSlowed = false;
        isSpeedup = false;
    }

    public void LevelUp()
    {
        speed += 0.1f;
        if (timer > 0.2)
        {
            timer -= 0.1f;
        }

        newSpeed = ((Mathf.Round(speed * 10)) / 10);
        newTimer = ((Mathf.Round(timer * 10)) / 10);

        speed = newSpeed;
        timer = newTimer;

        navMeshAgent.speed = speed;
    }

    public void OnSceneTimerStart()
    {
        onSceneTime = timer;
    }

    public void ItemButtonClicked()
    {
        cam.camPos = new Vector3(transform.position.x, Camera.main.transform.position.y, transform.position.z - (Camera.main.transform.position.y / 2.5f));
        isSelected = true;

        //        this.isSelected = true;
        //        controller.AmbulanceMenu();
    }

    public void Sorting()
    {
        itemButtonPress = invetory.itemButtonPress;

        itemButtonPress.onClick.AddListener(ItemButtonClicked);
    }

    public void EMSFireButton()
    {
        if (gameObject.tag == "FireTruck" || gameObject.tag == "AirFireTruck")
        {
            gameObject.tag = "EMSFireHybrid";
            isEMS.SetActive(true);
            isFire.SetActive(true);
        }

        else
        {
            AllIn();
        }
    }

    public void FirePoliceButton()
    {

        if (gameObject.tag == "FireTruck" || gameObject.tag == "AirFireTruck")
        {
            gameObject.tag = "FirePoliceHybrid";
            isFire.SetActive(true);
            isPolice.SetActive(true);
        }

        else
        {
            AllIn();
        }
    }

    /*
    public void PoliceEMSButton()
    {
        gameObject.tag = "PoliceEMSHybrid";
        isEMS.SetActive(true);
        isPolice.SetActive(true);
    }
    */

    public void AllIn()
    {
        gameObject.tag = "EMSPoliceFireHybrid";
        isEMS.SetActive(true);
        isFire.SetActive(true);
        isPolice.SetActive(true);
    }

    public IEnumerator AtDestinationTimer2()
    {
        while (atDestinationTime > 0)
        {
            transportingPhrase.SetActive(false);
            destinationPhrase.SetActive(true);
            availablePhrase.SetActive(false);
            yield return new WaitForSeconds(1.0f);
            atDestinationTime--;
        }
        if (atDestinationTime <= 0)
        {
            destinationPhrase.SetActive(false);
            availablePhrase.SetActive(true);


            //change money aspect
            //            if (priority > 0)
            //            {
            //                controller.money += (100 / priority);
            //            }

            if (callZone1 == 1) {controller.zone01Loyalty += 5;} 
            if (callZone2 == 1) {controller.zone01Loyalty += 5;} 
            if (callZone3 == 1) {controller.zone01Loyalty += 5;} 
            if (callZone4 == 1) {controller.zone01Loyalty += 5;} 
            if (callZone5 == 1) {controller.zone01Loyalty += 5;}

            if (callZone1 == 2) { controller.zone02Loyalty += 5; }
            if (callZone2 == 2) { controller.zone02Loyalty += 5; }
            if (callZone3 == 2) { controller.zone02Loyalty += 5; }
            if (callZone4 == 2) { controller.zone02Loyalty += 5; }
            if (callZone5 == 2) { controller.zone02Loyalty += 5; }

            if (callZone1 == 3) { controller.zone03Loyalty += 5; }
            if (callZone2 == 3) { controller.zone03Loyalty += 5; }
            if (callZone3 == 3) { controller.zone03Loyalty += 5; }
            if (callZone4 == 3) { controller.zone03Loyalty += 5; }
            if (callZone5 == 3) { controller.zone03Loyalty += 5; }

            if (callZone1 == 4) { controller.zone04Loyalty += 5; }
            if (callZone2 == 4) { controller.zone04Loyalty += 5; }
            if (callZone3 == 4) { controller.zone04Loyalty += 5; }
            if (callZone4 == 4) { controller.zone04Loyalty += 5; }
            if (callZone5 == 4) { controller.zone04Loyalty += 5; }

            if (callZone1 == 5) { controller.zone05Loyalty += 5; }
            if (callZone2 == 5) { controller.zone05Loyalty += 5; }
            if (callZone3 == 5) { controller.zone05Loyalty += 5; }
            if (callZone4 == 5) { controller.zone05Loyalty += 5; }
            if (callZone5 == 5) { controller.zone05Loyalty += 5; }

            level += fireBusCalls;
            controller.allSpawnedCollected -= fireBusCalls;

            for (int i = 0; i < fireBusCalls; i++)
            {
                controller.fireLoyalty += 5;
                LevelUp();
            }

            Available();

            callZone1 = 0; callZone2 = 0; callZone3 = 0; callZone4 = 0; callZone5 = 0;
            callPriority1 = 0; callPriority2 = 0; callPriority3 = 0; callPriority4 = 0; callPriority5 = 0;

            CaughtEMS = false;
            CaughtFire = false;
            CaughtPolice = false;
            fireBusCalls = 0;

            TFire.SetActive(false);
            TFire2.SetActive(false);
            TFire3.SetActive(false);
            TFire4.SetActive(false);
            TFire5.SetActive(false);
        }
    }

    public void Sold()
    {
        isSold = true;
        Destroy(this.gameObject, 1);
    }
}
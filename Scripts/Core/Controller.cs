using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {

//    public NavMeshSurface[] surfaces;

    public bool EMSEnabled;
    public bool FireEnabled;
    public bool PoliceEnabled;

    [SerializeField] public int wave;
    public float numSpawn;
    public float WaitTimeMax;
    public float WaitTimeMin;

    public Transform[] SpawnPointTransforms;
    public GameObject[] spawnPoints;
    public GameObject[] Emergencies = new GameObject[1];
    public int count = 0;
    public GameObject EMSEmergencieP1;
    public GameObject EMSEmergencieP2;
    public GameObject EMSEmergencieP3;
    public GameObject FireEmergencieP1;
    public GameObject FireEmergencieP2;
    public GameObject PoliceEmergencieP1;
    public GameObject PoliceEmergencieP2;
    public GameObject PoliceEmergencieP3;
    public GameObject PoliceEmergencieP4;
    public GameObject PoliceEmergencieP5;
    public GameObject[] Units;
    public List<GameObject> units;

    [SerializeField]
    public LayerMask ambulanceLayer;
    public LayerMask fireTruckLayer;
    public LayerMask policeCarLayer;
    public LayerMask fireStationLayer;
    public LayerMask hospitalLayer;
    public LayerMask policeStationLayer;
    public LayerMask zoneBuyLayer;
    public LayerMask environmentLayer;

    public float money;
    public Text moneyDisplay;

    public GameObject ambulance;
    public GameObject lifeFlight;
    public GameObject hospital;
    public GameObject hospitalToPlace;
    public GameObject fireStationToPlace;
    public GameObject policeStationToPlace;



    public Button hospitalButton;
    public Button ambulanceButton;
    public Button paraambulanceButton;
    public Button ambulanceVanButton;
    public Button lifeFlightButton;
    public Button fireStationButton;
    public Button fireRescueButton;
    public Button fireTruckButton;
    public Button ladderTruckButton;
    public Button fireBusButton;
    public Button policePatrolCarButton;
    public Button policeTrooperButton;
    public Button policeStationButton;
    public Button policeSwatButton;
    public Button SpotterButton;

    public int zone01Loyalty;
    public int zone02Loyalty;
    public int zone03Loyalty;
    public int zone04Loyalty;
    public int zone05Loyalty;

    public bool gameover = false;
    public bool gamewin = false;

    public GameObject lose;
    public GameObject Win;

    public GameObject hospitalMenu;
    public GameObject fireStationMenu;
    public GameObject policeStationMenu;
    public GameObject selectedUnitMenu;
    public GameObject startMenu;

    public Image ambulanceImage;
    public Text ambulanceCallsText;
    public Text ambulanceSpeedText;
    public Text ambulanceTimeText;
    public Text ambulanceStatusText;
    public Text ambulanceNameText;
    public Text ambulanceTimerText;

    public Ambulance ambulanceS;
    public FireTruck fireTruckS;
    public PoliceCar policeCarS;
    public Hospital hospitalS;
    public FireStation fireStationS;
    public PoliceStation policeStationS;

    public int ambulanceNumber = 100;
    public int fireTruckNumber = 200;
    public int policeCarNumber = 300;
    public int airAmbulanceNumber = 0;
    public int fireBusNumber = 0;
    public int spotterNumber = 0;

    public Button buyEMS;
    public Button buyFire;
    public Button buyPolice;

    public GameObject zone02BuyMenu;
    public GameObject zone03BuyMenu;
    public GameObject zone04BuyMenu;
    public GameObject zone05BuyMenu;

    public bool isBetaTesting = false;

    public float totalLoyalty;

    public Slider zone01Value;
    public Slider zone02Value;
    public Slider zone03Value;
    public Slider zone04Value;
    public Slider zone05Value;

    public bool ambulanceMenuActive;
    public bool fireMenuActive;
    public bool policeMenuActive;

    public GameObject GetEMS;
    public GameObject GetFire;
    public GameObject GetPolice;

    public int callsPending;
    public Text callsPendingDisplay;

    public bool isSmall;
    public bool isMedium;
    public bool isBig;

    public int unitNmbers;

    public bool earnedAllAchievements;
    public Material eMSColor;
    public Color eMSOldColor;
    public Color eMSAlternateColor;
    public Material fireColor;
    public Color fireOldColor;
    public Color fireAlternateColor;
    public Material policeColor;
    public Color policeOldColor;
    public Color policeAlternateColor;

    public int agenciesEnabled;

    public bool challengeMode;
    public bool singleHeliChallenge;
    public bool spotterSurvivalChallenge;
    public bool busTransitChallenge;
    public bool noMoneyChallenge;
    public bool lotteryChallenge;
    public bool allAtOnceChallenge;
    public bool doubleTroubleChallenge;
    public bool timedChallenge;
    public bool wavesChallenge;
    public bool ultimateChallenge;

    public bool unitSelected;
    public bool unitCleared;
    public bool loseKnow;
    public bool winKnow;

    public Slider eMSLoyaltySlider;
    public Slider fireLoyaltySlider;
    public Slider policeLoyaltySlider;
    public int eMSLoyalty;
    public int fireLoyalty;
    public int policeLoyalty;
    public GameObject eMSLoyalBar;
    public GameObject fireLoyalBar;
    public GameObject policeLoyalBar;
    public GameObject toBuyEMS;
    public GameObject toBuyFire;
    public GameObject toBuyPolice;
    public GameObject uISet;

    public GameObject canGetEMS;
    public GameObject canGetFire;
    public GameObject canGetPolice;

    public GameObject eMSStart;
    public GameObject fireStart;
    public GameObject policeStart;

    public int worldTimer;
    public GameObject worldTimerObject;
    public Text worldTimerText;
    public int survivalTimer;

    public int allSpawnedCollected;

    public float timePlayedCounter;
    public float timePlayed;
    public Text timePlayedText;

    public static extern bool GenerateInBackground();

    void Start () 
    {
        wave = 1;

        zone01Loyalty = 50;
        zone02Loyalty = 50;
        zone03Loyalty = 50;
        zone04Loyalty = 50;
        zone05Loyalty = 50;
        units = new List<GameObject>();

        unitCleared = true;

        if (allAtOnceChallenge == false)
        {
            allSpawnedCollected = 99999;
        }
    }
	

	void Update () {

        moneyDisplay.text = ("$ " + money.ToString());
        callsPendingDisplay.text = ("Calls Pending: " + callsPending.ToString());
        timePlayedText.text = ("Seconds: " + timePlayed.ToString());
        timePlayedCounter += Time.deltaTime;
        timePlayed = Mathf.Round(timePlayedCounter);
        if (callsPending < 0)
        {
            callsPending = 0;
        }
        if (timedChallenge == true)
        {
            worldTimerText.text = ("Timer: " + worldTimer.ToString());
        }
        if (spotterSurvivalChallenge == true)
        {
            worldTimerText.text = ("Timer: " + survivalTimer.ToString());
        }

        /*
        loyalty01Display.text = ("Central " + zone01Loyalty.ToString());
        loyalty02Display.text = ("Zone 2 " + zone02Loyalty.ToString());
        loyalty03Display.text = ("Zone 3 " + zone03Loyalty.ToString());
        loyalty04Display.text = ("Zone 4 " + zone04Loyalty.ToString());
        loyalty05Display.text = ("Zone 5 " + zone05Loyalty.ToString());
        */

        totalLoyalty = (zone01Loyalty + zone02Loyalty + zone03Loyalty + zone04Loyalty + zone05Loyalty) /25;

        zone01Value.value = zone01Loyalty;
        zone02Value.value = zone02Loyalty;
        zone03Value.value = zone03Loyalty;
        zone04Value.value = zone04Loyalty;
        zone05Value.value = zone05Loyalty;

        eMSLoyaltySlider.value = eMSLoyalty;
        fireLoyaltySlider.value = fireLoyalty;
        policeLoyaltySlider.value = policeLoyalty;




        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit rayHit;

            if (unitCleared == true)
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, ambulanceLayer))
                {
                    if (unitSelected == false)
                    {
                        CloseMenus();
                        ambulanceS = rayHit.collider.GetComponent<Ambulance>();
                        AmbulanceMenu();
                        unitSelected = true;
                        unitCleared = false;
                    }

                }

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, fireTruckLayer))
                {
                    if (unitSelected == false)
                    {
                        CloseMenus();
                        fireTruckS = rayHit.collider.GetComponent<FireTruck>();
                        FireTruckMenu();
                        unitSelected = true;
                        unitCleared = false;
                    }

                }

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, policeCarLayer))
                {
                    if (unitSelected == false)
                    {
                        CloseMenus();
                        policeCarS = rayHit.collider.GetComponent<PoliceCar>();
                        PoliceCarMenu();
                        unitSelected = true;
                        unitCleared = false;
                    }

                }

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, hospitalLayer))
                {
                    if (unitSelected == false)
                    {
                        CloseMenus();
                        hospitalS = rayHit.collider.GetComponent<Hospital>();
                        HospitalMenu();
                    }

                }

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, fireStationLayer))
                {
                    if (unitSelected == false)
                    {
                        CloseMenus();
                        fireStationS = rayHit.collider.GetComponent<FireStation>();
                        FireStationMenu();
                    }

                }

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, policeStationLayer))
                {
                    if (unitSelected == false)
                    {
                        CloseMenus();
                        policeStationS = rayHit.collider.GetComponent<PoliceStation>();
                        PoliceStationMenu();
                    }

                }

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, zoneBuyLayer))
                {
                    if (unitSelected == false)
                    {
                        CloseMenus();
                        rayHit.collider.GetComponent<ZoneBuy>().ClickedOn();
                    }

                }

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, environmentLayer))
                {
                    CloseMenus();
                }
            }
            else if (unitSelected == false)
            {
                unitCleared = true;
            }
            
        }

        if (money < 250)
        {
            ambulanceVanButton.interactable = false;
        }
        if (money > 249)
        {
            ambulanceVanButton.interactable = true;
        }

        if (money < 500)
        {
            ambulanceButton.interactable = false;
        }
        if (money > 499)
        {
            ambulanceButton.interactable = true;
        }

        if (money < 750)
        {
            paraambulanceButton.interactable = false;
        }
        if (money > 749)
        {
            paraambulanceButton.interactable = true;
        }

        if (money < 2000)
        {
            hospitalButton.interactable = false;
        }
        if (money > 1999)
        {
            hospitalButton.interactable = true;
        }

        if (money < 1000)
        {
            lifeFlightButton.interactable = false;
        }
        if (money > 999)
        {
            lifeFlightButton.interactable = true;
        }

        if (money < 1000)
        {
            fireStationButton.interactable = false;
        }
        if (money > 999)
        {
            fireStationButton.interactable = true;
        }

        if (money < 300)
        {
            fireRescueButton.interactable = false;
        }
        if (money > 299)
        {
            fireRescueButton.interactable = true;
        }

        if (money < 600)
        {
            fireTruckButton.interactable = false;
        }
        if (money > 599)
        {
            fireTruckButton.interactable = true;
        }

        if (money < 900)
        {
            ladderTruckButton.interactable = false;
        }
        if (money > 899)
        {
            ladderTruckButton.interactable = true;
        }

        if (money < 1000)
        {
            fireBusButton.interactable = false;
        }
        if (money > 999)
        {
            fireBusButton.interactable = true;
        }

        if (money < 1500)
        {
            policeStationButton.interactable = false;
        }
        if (money > 1499)
        {
            policeStationButton.interactable = true;
        }

        if (money < 400)
        {
            policePatrolCarButton.interactable = false;
        }
        if (money > 399)
        {
            policePatrolCarButton.interactable = true;
        }

        if (money < 750)
        {
            policeTrooperButton.interactable = false;
        }
        if (money > 749)
        {
            policeTrooperButton.interactable = true;
        }

        if (money < 1200)
        {
            policeSwatButton.interactable = false;
        }
        if (money > 1199)
        {
            policeSwatButton.interactable = true;
        }

        if (money < 1000)
        {
            SpotterButton.interactable = false;
        }
        if (money > 999)
        {
            SpotterButton.interactable = true;
        }

        if (zone01Loyalty >99 && zone02Loyalty > 99 && zone03Loyalty > 99 && zone04Loyalty > 99 && zone05Loyalty > 99 || allSpawnedCollected == 0 || survivalTimer == 0) //&& EMSEnabled == true && FireEnabled == true && PoliceEnabled == true)
        {
            if (gameover == false)
            {
                if (EMSEnabled == true && FireEnabled == false && PoliceEnabled == false) 
                { 
                    if (eMSLoyalty > 99 || allSpawnedCollected == 0 || survivalTimer == 0)
                    {
                        if (gamewin == false)
                        {
                            GameWon();
                        }
                    }
                }
                if (EMSEnabled == false && FireEnabled == true && PoliceEnabled == false)
                {
                    if (fireLoyalty > 99 || allSpawnedCollected == 0 || survivalTimer == 0)
                    {
                        if (gamewin == false)
                        {
                            GameWon();
                        }
                    }
                }
                if (EMSEnabled == false && FireEnabled == false && PoliceEnabled == true)
                {
                    if (policeLoyalty > 99 || allSpawnedCollected == 0 || survivalTimer == 0)
                    {
                        if (gamewin == false)
                        {
                            GameWon();
                        }
                    }
                }

                if (EMSEnabled == true && FireEnabled == true && PoliceEnabled == false)
                {
                    if (eMSLoyalty > 99 && fireLoyalty > 99 || allSpawnedCollected == 0 || survivalTimer == 0)
                    {
                        if (gamewin == false)
                        {
                            GameWon();
                        }
                    }
                }
                if (EMSEnabled == true && FireEnabled == false && PoliceEnabled == true)
                {
                    if (policeLoyalty > 99 && eMSLoyalty > 99 || allSpawnedCollected == 0 || survivalTimer == 0)
                    {
                        if (gamewin == false)
                        {
                            GameWon();
                        }
                    }
                }
                if (EMSEnabled == false && FireEnabled == true && PoliceEnabled == true)
                {
                    if (policeLoyalty > 99 && fireLoyalty > 99 || allSpawnedCollected == 0 || survivalTimer == 0)
                    {
                        if (gamewin == false)
                        {
                            GameWon();
                        }
                    }
                }
                if (EMSEnabled == true && FireEnabled == true && PoliceEnabled == true)
                {
                    if (policeLoyalty > 99 && eMSLoyalty > 99 && fireLoyalty > 99 || allSpawnedCollected == 0 || survivalTimer == 0)
                    {
                        if (gamewin == false)
                        {
                            GameWon();
                        }
                    }
                }
            }
        }

        if (zone01Loyalty <1 || zone02Loyalty < 1 || zone03Loyalty < 1 || zone04Loyalty < 1 || zone05Loyalty < 1 || worldTimer <= 0 || eMSLoyalty < 1 || fireLoyalty < 1 || policeLoyalty < 1)
        {
            if (loseKnow == false)
            {
                gameover = true;
                lose.SetActive(true);
                loseKnow = true;
            }
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            CloseMenus();
        }

        if (money < 1000)
        {
            buyEMS.interactable = false;
            buyFire.interactable = false;
            buyPolice.interactable = false;
        }

        if (money > 999)
        {
            if (EMSEnabled == false)
            {
                buyEMS.interactable = true;
            }

            if (FireEnabled == false)
            {
                buyFire.interactable = true;
            }

            if (PoliceEnabled == false)
            {
                buyPolice.interactable = true;
            }
        }

        if (ambulanceMenuActive == true)
        {
            if (ambulanceS.available == true)
            {
                ambulanceStatusText.text = ("Available");
                ambulanceTimerText.text = ("");
            }
            if (ambulanceS.enroute == true)
            {
                ambulanceStatusText.text = ("Enroute");
                ambulanceTimerText.text = ("");
            }
            if (ambulanceS.transporting == true)
            {
                ambulanceStatusText.text = ("Transporting");
                ambulanceTimerText.text = ("");
            }
            if (ambulanceS.onScene == true)
            {
                ambulanceStatusText.text = ("OnScene");
                ambulanceTimerText.text = ambulanceS.onSceneTime.ToString();
            }
            if (ambulanceS.atDestintation == true)
            {
                ambulanceStatusText.text = ("atDestination");
                ambulanceTimerText.text = ambulanceS.atDestinationTime.ToString();
            }
        }

        if (fireMenuActive == true)
        {
            if (fireTruckS.available == true)
            {
                ambulanceStatusText.text = ("Available");
                ambulanceTimerText.text = ("");
            }
            if (fireTruckS.enroute == true)
            {
                ambulanceStatusText.text = ("Enroute");
                ambulanceTimerText.text = ("");
            }
            if (fireTruckS.transporting == true)
            {
                ambulanceStatusText.text = ("Transporting");
                ambulanceTimerText.text = ("");
            }
            if (fireTruckS.onScene == true)
            {
                ambulanceStatusText.text = ("OnScene");
                ambulanceTimerText.text = fireTruckS.onSceneTime.ToString();
            }
            if (fireTruckS.atDestintation == true)
            {
                ambulanceStatusText.text = ("atDestination");
                ambulanceTimerText.text = fireTruckS.atDestinationTime.ToString();
            }
        }

        if (policeMenuActive == true)
        {
            if (policeCarS.available == true)
            {
                ambulanceStatusText.text = ("Available");
                ambulanceTimerText.text = ("");
            }
            if (policeCarS.enroute == true)
            {
                ambulanceStatusText.text = ("Enroute");
                ambulanceTimerText.text = ("");
            }
            if (policeCarS.transporting == true)
            {
                ambulanceStatusText.text = ("Transporting");
                ambulanceTimerText.text = ("");
            }
            if (policeCarS.onScene == true)
            {
                ambulanceStatusText.text = ("OnScene");
                ambulanceTimerText.text = policeCarS.onSceneTime.ToString();
            }
            if (policeCarS.atDestintation == true)
            {
                ambulanceStatusText.text = ("atDestination");
                ambulanceTimerText.text = policeCarS.atDestinationTime.ToString();
            }
        }

        if (!hospitalS)
        {
            hospitalMenu.SetActive(false);
        }

        if (!fireStationS)
        {
            fireStationMenu.SetActive(false);
        }

        if (!policeStationS)
        {
            policeStationMenu.SetActive(false);
        }
    }

    IEnumerator coroutineA()
    {
        //if (numSpawn < numSavesNeeded)
        //{

        yield return new WaitForSeconds(Random.Range(WaitTimeMin, WaitTimeMax));
        print("Spawned");
        WaitTimeMax -= WaitTimeMin;
        spawnEmergancies();
        if (doubleTroubleChallenge == true)
        {
            spawnEmergancies();
        }
        yield return StartCoroutine(coroutineA());
       // }
    }

    public void spawnEmergancies()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        int EmerganciesIndex = Random.Range(0, Emergencies.Length);
        Instantiate(Emergencies[EmerganciesIndex], spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.rotation);
    }

    public void PatrolCarButton()
    {
        money -= 400;
        policeCarNumber++;
        policeStationS.SpawnPolicePatrolCar();
        GetUnits();
        CloseMenus();
    }

    public void PatrolTrooperButton()
    {
        money -= 750;
        policeCarNumber++;
        policeStationS.SpawnPoliceTrooper();
        GetUnits();
        CloseMenus();
    }

    public void SwatButton()
    {
        money -= 1200;
        policeCarNumber++;
        policeStationS.SpawnPoliceSwat();
        GetUnits();
        CloseMenus();
    }

    public void PoliceSpotterButton()
    {
        money -= 1000;
        spotterNumber++;
        policeStationS.SpawnPoliceSpotter();
        GetUnits();
        CloseMenus();
    }

    public void AmbulanceButton()
    {
        money -= 500;
        ambulanceNumber++;
        hospitalS.SpawnAmbulance();
        GetUnits();
        CloseMenus();
    }

    public void ParaAmbulanceButton()
    {
        money -= 750;
        ambulanceNumber++;
        hospitalS.SpawnParaAmbulance();
        GetUnits();
        CloseMenus();
    }

    public void AmbulanceVanButton()
    {
        money -= 250;
        ambulanceNumber++;
        hospitalS.SpawnAmbulanceVan();
        GetUnits();
        CloseMenus();
    }

    public void LifeFlightButton()
    {
        money -= 1000;
        airAmbulanceNumber++;
        hospitalS.SpawnAirAmbulance();
        GetUnits();
        CloseMenus();
    }

    public void HospitalButton()
    {
        money -= 2000;
        Instantiate(hospitalToPlace, gameObject.transform.position, gameObject.transform.rotation);
        CloseMenus();
    }

    public void FireStationButton()
    {
        money -= 1000;
        Instantiate(fireStationToPlace, gameObject.transform.position, gameObject.transform.rotation);
        CloseMenus();
    }

    public void PoliceStationButton()
    {
        money -= 1500;
        Instantiate(policeStationToPlace, gameObject.transform.position, gameObject.transform.rotation);
        CloseMenus();
    }

    public void FireRescueButton()
    {
        money -= 300;
        fireTruckNumber++;
        fireStationS.SpawnFireRescue();
        GetUnits();
        CloseMenus();
    }

    public void FireTruckButton()
    {
        money -= 600;
        fireTruckNumber++;
        fireStationS.SpawnFireTruck();
        GetUnits();
        CloseMenus();
    }

    public void LadderTruckButton()
    {
        money -= 900;
        fireTruckNumber++;
        fireStationS.SpawnLadderTruck();
        GetUnits();
        CloseMenus();
    }

    public void FireBusButton()
    {
        money -= 1000;
        fireBusNumber++;
        fireStationS.SpawnFireBus();
        GetUnits();
        CloseMenus();
    }

    public void FreePlay()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void AmbulanceMenu()
    {
        CloseMenus();
        selectedUnitMenu.SetActive(true);
        ambulanceCallsText.text = (ambulanceS.level.ToString());
        ambulanceSpeedText.text = (ambulanceS.speed.ToString());
        ambulanceTimeText.text = (ambulanceS.timer.ToString());
        ambulanceNameText.text = ambulanceS.gameObject.ToString();

        ambulanceImage.sprite = ambulanceS.ambulanceImage;
        GetEMS.SetActive(false);
        canGetEMS.SetActive(true);

        if (ambulanceS.gameObject.tag == "Ambulance" || ambulanceS.gameObject.tag == "AirAmbulance")
        {
            if (ambulanceS.cannotHybrid == false)
            {
                GetFire.SetActive(true);
                GetPolice.SetActive(true);
                canGetFire.SetActive(true);
                canGetPolice.SetActive(true);
            }
            else
            {
                GetFire.SetActive(false);
                GetPolice.SetActive(false);
                canGetFire.SetActive(false);
                canGetPolice.SetActive(false);
            }
        }

        if (ambulanceS.gameObject.tag == "EMSFireHybrid")
        {
            GetPolice.SetActive(true);
            GetFire.SetActive(false);
        }

        if (ambulanceS.gameObject.tag == "PoliceEMSHybrid")
        {
            GetFire.SetActive(true);
            GetPolice.SetActive(false);
        }

        if (ambulanceS.gameObject.tag == "EMSPoliceFireHybrid")
        {
            GetFire.SetActive(false);
            GetPolice.SetActive(false);
        }

        ambulanceMenuActive = true;
        ambulanceS.isSelected = true;
    }

    public void FireTruckMenu()
    {
        CloseMenus();
        selectedUnitMenu.SetActive(true);
        ambulanceCallsText.text = (fireTruckS.level.ToString());
        ambulanceSpeedText.text = (fireTruckS.speed.ToString());
        ambulanceTimeText.text = (fireTruckS.timer.ToString());
        ambulanceNameText.text = fireTruckS.gameObject.ToString();
        fireTruckS.isSelected = true;

        ambulanceImage.sprite = fireTruckS.ambulanceImage;
        GetFire.SetActive(false);
        canGetFire.SetActive(true);

        if (fireTruckS.gameObject.tag == "FireTruck" || fireTruckS.gameObject.tag == "FireBus")
        {
            if (fireTruckS.cannotHybrid == false)
            {
                GetEMS.SetActive(true);
                GetPolice.SetActive(true);
                canGetEMS.SetActive(true);
                canGetPolice.SetActive(true);
            }
            else
            {
                GetEMS.SetActive(false);
                GetPolice.SetActive(false);
                canGetEMS.SetActive(false);
                canGetPolice.SetActive(false);
            }
        }

        if (fireTruckS.gameObject.tag == "EMSFireHybrid")
        {
            GetPolice.SetActive(true);
            GetEMS.SetActive(false);
        }

        if (fireTruckS.gameObject.tag == "FirePoliceHybrid")
        {
            GetEMS.SetActive(true);
            GetPolice.SetActive(false);
        }

        if (fireTruckS.gameObject.tag == "EMSPoliceFireHybrid")
        {
            GetEMS.SetActive(false);
            GetPolice.SetActive(false);
        }

        fireMenuActive = true;
    }

    public void PoliceCarMenu()
    {
        CloseMenus();
        selectedUnitMenu.SetActive(true);
        ambulanceCallsText.text = (policeCarS.level.ToString());
        ambulanceSpeedText.text = (policeCarS.speed.ToString());
        ambulanceTimeText.text = (policeCarS.timer.ToString());
        ambulanceNameText.text = policeCarS.gameObject.ToString();
        policeCarS.isSelected = true;

        ambulanceImage.sprite = policeCarS.ambulanceImage;
        GetPolice.SetActive(false);
        canGetPolice.SetActive(true);

        if (policeCarS.gameObject.tag == "PoliceCar" || policeCarS.gameObject.tag == "PoliceSpotter")
        {
            if (policeCarS.cannotHybrid == false)
            {
                GetEMS.SetActive(true);
                GetFire.SetActive(true);
                canGetEMS.SetActive(true);
                canGetFire.SetActive(true);
            }
            else
            {
                GetEMS.SetActive(false);
                GetFire.SetActive(false);
                canGetEMS.SetActive(false);
                canGetFire.SetActive(false);
            }
        }

        if (policeCarS.gameObject.tag == "PoliceEMSHybrid")
        {
            GetFire.SetActive(true);
            GetEMS.SetActive(false);
        }

        if (policeCarS.gameObject.tag == "FirePoliceHybrid")
        {
            GetEMS.SetActive(true);
            GetFire.SetActive(false);
        }

        if (policeCarS.gameObject.tag == "EMSPoliceFireHybrid")
        {
            GetFire.SetActive(false);
            GetPolice.SetActive(false);
        }

        policeMenuActive = true;
    }

    public void HospitalMenu()
    {
        CloseMenus();
        hospitalMenu.SetActive(true);
    }

    public void FireStationMenu()
    {
        CloseMenus();
        fireStationMenu.SetActive(true);
    }

    public void PoliceStationMenu()
    {
        CloseMenus();
        policeStationMenu.SetActive(true);
    }

    public void CloseMenus()
    {
        hospitalMenu.SetActive(false);
        selectedUnitMenu.SetActive(false);
        fireStationMenu.SetActive(false);
        policeStationMenu.SetActive(false);
        lose.SetActive(false);
        Win.SetActive(false);

        ambulanceMenuActive = false;
        fireMenuActive = false;
        policeMenuActive = false;
    }

    public void GetSpawnPoints()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawner");
    }

    public void GetUnits()
    {
        //       Units = (GameObject.FindGameObjectsWithTag("Ambulance"));
        //          Units.Add = (gameObject.FindGameObjectsWithTag("AirAmbulance"));
        //        Units.AddRange(gameObject.FindGameObjectsWithTag("AirAmbulance"));
        unitNmbers++;
    }

    public void EMSStartButton()
    {
        startMenu.SetActive(false);
        FindEMSEmergancies();
        GetSpawnPoints();
        if (wavesChallenge == true)
        {
            StartCoroutine(Waves());
        }
        else if (allAtOnceChallenge == true)
        {
            StartCoroutine(AllAtOnce());
        }
        else
        {
            StartCoroutine(coroutineA());
        }

        Instantiate(hospitalToPlace, gameObject.transform.position, gameObject.transform.rotation);
        CloseMenus();
        EMSEnabled = true;
        agenciesEnabled++;
        toBuyEMS.SetActive(false);
        eMSLoyalBar.SetActive(true);
        uISet.SetActive(true);
        eMSStart.SetActive(false);
        if (ultimateChallenge == true)
        {
            if (FireEnabled == true && PoliceEnabled == true)
            {
                return;
            }
            else
            {
                startMenu.SetActive(true);
                uISet.SetActive(false);
            }
        }
        if (timedChallenge == true)
        {
            worldTimerObject.SetActive(true);
            StartCoroutine(WorldTimer());
        }
    }

    public void FireStartButton()
    {
        startMenu.SetActive(false);
        FindFireEmergancies();
        GetSpawnPoints();
        if (wavesChallenge == true)
        {
            StartCoroutine(Waves());
        }
        else if (allAtOnceChallenge == true)
        {
            StartCoroutine(AllAtOnce());
        }
        else
        {
            StartCoroutine(coroutineA());
        }
        Instantiate(fireStationToPlace, gameObject.transform.position, gameObject.transform.rotation);
        CloseMenus();
        FireEnabled = true;
        StartCoroutine(coroutineFireIncome());
        agenciesEnabled++;
        toBuyFire.SetActive(false);
        fireLoyalBar.SetActive(true);
        uISet.SetActive(true);
        fireStart.SetActive(false);
        if (ultimateChallenge == true)
        {
            if (EMSEnabled == true && PoliceEnabled == true)
            {
                return;
            }
            else
            {
                startMenu.SetActive(true);
                uISet.SetActive(false);
            }
        }

        if (timedChallenge == true)
        {
            worldTimerObject.SetActive(true);
            StartCoroutine(WorldTimer());
        }
    }

    public void PoliceStartButton()
    {
        startMenu.SetActive(false);
        FindPoliceEmergancies();
        GetSpawnPoints();
        if (wavesChallenge == true)
        {
            StartCoroutine(Waves());
        }
        else if (allAtOnceChallenge == true)
        {
            StartCoroutine(AllAtOnce());
        }
        else
        {
            StartCoroutine(coroutineA());
        }
        Instantiate(policeStationToPlace, gameObject.transform.position, gameObject.transform.rotation);
        CloseMenus();
        PoliceEnabled = true;
        StartCoroutine(coroutinePoliceIncome());
        agenciesEnabled++;
        toBuyPolice.SetActive(false);
        policeLoyalBar.SetActive(true);
        uISet.SetActive(true);
        policeStart.SetActive(false);
        if (ultimateChallenge == true)
        {
            if (EMSEnabled == true && FireEnabled == true)
            {
                return;
            }
            else
            {
                startMenu.SetActive(true);
                uISet.SetActive(false);
            }
        }

        if (timedChallenge == true || spotterSurvivalChallenge == true)
        {
            worldTimerObject.SetActive(true);
            StartCoroutine(WorldTimer());
        }
    }

    public void LoadingDone()
    {
        //        for (int i = 0; i < surfaces.Length; i++)
        //        {
        //            surfaces[i].BuildNavMesh();
        //        }

        Invoke("Set", 2);

    }

    public void Set()
    {
        startMenu.SetActive(true);
    }

    public void FindEMSEmergancies()
    {
        Emergencies[count] = EMSEmergencieP1;
        count++;
        Emergencies[count] = EMSEmergencieP2;
        count++;
        Emergencies[count] = EMSEmergencieP3;
        count++;
        Emergencies[count] = EMSEmergencieP1;
        count++;
        Emergencies[count] = EMSEmergencieP2;
        count++;
    }

    public void FindFireEmergancies()
    {
        Emergencies[count] = FireEmergencieP1;
        count++;
        Emergencies[count] = FireEmergencieP2;
        count++;
        Emergencies[count] = FireEmergencieP1;
        count++;
        Emergencies[count] = FireEmergencieP2;
        count++;
        Emergencies[count] = FireEmergencieP2;
        count++;
    }

    public void FindPoliceEmergancies()
    {
        Emergencies[count] = PoliceEmergencieP1;
        count++;
        Emergencies[count] = PoliceEmergencieP2;
        count++;
        Emergencies[count] = PoliceEmergencieP3;
        count++;
        Emergencies[count] = PoliceEmergencieP4;
        count++;
        Emergencies[count] = PoliceEmergencieP5;
        count++;
    }

    public void BuyEMS()
    {
        CloseMenus();
        money -= 1000;
        FindEMSEmergancies();
        GetSpawnPoints();
        Instantiate(hospitalToPlace, gameObject.transform.position, gameObject.transform.rotation);
        EMSEnabled = true;
        ResetLoyalty();
        agenciesEnabled++;
        toBuyEMS.SetActive(false);
        eMSLoyalBar.SetActive(true);
    }

    public void BuyFire()
    {
        CloseMenus();
        money -= 1000;
        FindFireEmergancies();
        GetSpawnPoints();
        Instantiate(fireStationToPlace, gameObject.transform.position, gameObject.transform.rotation);
        FireEnabled = true;
        StartCoroutine(coroutineFireIncome());
        ResetLoyalty();
        agenciesEnabled++;
        toBuyFire.SetActive(false);
        fireLoyalBar.SetActive(true);
    }

    public void BuyPolice()
    {
        CloseMenus();
        money -= 1000;
        FindPoliceEmergancies();
        GetSpawnPoints();
        Instantiate(policeStationToPlace, gameObject.transform.position, gameObject.transform.rotation);
        PoliceEnabled = true;
        StartCoroutine(coroutinePoliceIncome());
        ResetLoyalty();
        agenciesEnabled++;
        toBuyPolice.SetActive(false);
        policeLoyalBar.SetActive(true);
    }

    IEnumerator coroutineFireIncome()
    {
        if (lotteryChallenge == false)
        {
            yield return new WaitForSeconds(1f);
            money += totalLoyalty;
            StartCoroutine(coroutinePoliceIncome());
        }
    }

    IEnumerator coroutinePoliceIncome()
    {
        if (lotteryChallenge == false)
        {
            yield return new WaitForSeconds(2.5f);
            money += totalLoyalty;
            StartCoroutine(coroutinePoliceIncome());
        }
    }

    public void ResetLoyalty()
    {
        zone01Loyalty = 50;
        zone02Loyalty = 50;
        zone03Loyalty = 50;
        zone04Loyalty = 50;
        zone05Loyalty = 50;
    }

    public void BuyZone2Menu()
    {
        CloseMenus();
        zone02BuyMenu.SetActive(true);
    }

    public void BuyZone3Menu()
    {
        CloseMenus();
        zone03BuyMenu.SetActive(true);
    }

    public void BuyZone4Menu()
    {
        CloseMenus();
        zone04BuyMenu.SetActive(true);
    }

    public void BuyZone5Menu()
    {
        CloseMenus();
        zone05BuyMenu.SetActive(true);
    }

    public void GetEMSButton()
    {
        if (fireMenuActive == true)
        {
            fireTruckS.EMSFireButton();
        }

        if (policeMenuActive == true)
        {
            policeCarS.PoliceEMSButton();
        }

        money -= 100;
        GetEMS.SetActive(false);
    }

    public void GetFireButton()
    {
        if (ambulanceMenuActive == true)
        {
            ambulanceS.EMSFireButton();
        }

        if (policeMenuActive == true)
        {
            policeCarS.FirePoliceButton();
        }

        money -= 100;
        GetFire.SetActive(false);
    }

    public void GetPoliceButton()
    {
        if (ambulanceMenuActive == true)
        {
            ambulanceS.PoliceEMSButton();
        }

        if (fireMenuActive == true)
        {
            fireTruckS.FirePoliceButton();
        }

        money -= 100;
        GetPolice.SetActive(false);
    }

    public void ChangeColor()
    {
        if (earnedAllAchievements == true)
        {
            eMSColor.color = eMSAlternateColor;
            fireColor.color = fireAlternateColor;
            policeColor.color = policeAlternateColor;
        }
        else
        {
            eMSColor.color = eMSOldColor;
            fireColor.color = fireOldColor;
            policeColor.color = policeOldColor;
        }
    }

    public void SellUnit()
    {
        if (ambulanceMenuActive == true)
        {
            money += ambulanceS.sellPrice;
            ambulanceS.Sold();
            CloseMenus();
        }

        if (fireMenuActive == true)
        {
            money += fireTruckS.sellPrice;
            fireTruckS.Sold();
            CloseMenus();
        }

        if (policeMenuActive == true)
        {
            money += policeCarS.sellPrice;
            policeCarS.Sold();
            CloseMenus();
        }
    }

    IEnumerator WorldTimer()
    {
        if (timedChallenge == true)
        {
            worldTimer = 600;
            survivalTimer = 602;
        }
        if(spotterSurvivalChallenge == true)
        {
            worldTimer = 302;
            survivalTimer = 300;
        }

        while (worldTimer > 0 && survivalTimer > 0)
        {
            yield return new WaitForSeconds(1);
            worldTimer--;
            survivalTimer--;
        }
    }

    IEnumerator Waves()
    {
        yield return new WaitForSeconds(WaitTimeMax);
        while (numSpawn < wave)
        {
            spawnEmergancies();
            numSpawn++;
        }
        numSpawn = 0;
        wave++;
        yield return StartCoroutine(Waves());
    }

    IEnumerator AllAtOnce()
    {
        yield return new WaitForSeconds(WaitTimeMax);
        allSpawnedCollected = 25;
        wave = 25;
        while (numSpawn < wave)
        {
            spawnEmergancies();
            numSpawn++;
        }
    }

    public void GameWon()
    {
        gamewin = true;
        if (challengeMode == true)
        {
            if (singleHeliChallenge == true)
            {
                PlayerPrefs.SetInt("completedSingleHeli", 1);
            }
            if (spotterSurvivalChallenge == true)
            {
                PlayerPrefs.SetInt("completedSpotterSurvival", 1);
            }
            if (busTransitChallenge == true)
            {
                PlayerPrefs.SetInt("completedBusTransit", 1);
            }
            if (noMoneyChallenge == true)
            {
                PlayerPrefs.SetInt("completedNoMoney", 1);
            }
            if (lotteryChallenge == true)
            {
                PlayerPrefs.SetInt("completedLottery", 1);
            }
            if (allAtOnceChallenge == true)
            {
                PlayerPrefs.SetInt("completedAllAtOnce", 1);
            }
            if (doubleTroubleChallenge == true)
            {
                PlayerPrefs.SetInt("completedDoubleTrouble", 1);
            }
            if (timedChallenge == true)
            {
                PlayerPrefs.SetInt("completedTimed", 1);
            }
            if (wavesChallenge == true)
            {
                PlayerPrefs.SetInt("completedWaves", 1);
            }
            if (ultimateChallenge == true)
            {
                PlayerPrefs.SetInt("completedUltimate", 1);
            }
        }
        else
        {
            if (isSmall == true)
            {
                if (agenciesEnabled > 1)
                {
                    if (agenciesEnabled == 2)
                    {
                        PlayerPrefs.SetInt("beatOnSmallas2A", 1);
                    }
                    if (agenciesEnabled == 3)
                    {
                        PlayerPrefs.SetInt("beatOnSmallas3A", 1);
                    }
                }
                else
                {
                    if (EMSEnabled == true)
                    {
                        PlayerPrefs.SetInt("beatOnSmallasEMS", 1);
                    }
                    if (FireEnabled == true)
                    {
                        PlayerPrefs.SetInt("beatOnSmallasFire", 1);
                    }
                    if (PoliceEnabled == true)
                    {
                        PlayerPrefs.SetInt("beatOnSmallasPolice", 1);
                    }
                }
            }

            if (isMedium == true)
            {
                if (agenciesEnabled > 1)
                {
                    if (agenciesEnabled == 2)
                    {
                        PlayerPrefs.SetInt("beatOnMediumas2A", 1);
                    }
                    if (agenciesEnabled == 3)
                    {
                        PlayerPrefs.SetInt("beatOnMediumas3A", 1);
                    }
                }
                else
                {
                    if (EMSEnabled == true)
                    {
                        PlayerPrefs.SetInt("beatOnMediumasEMS", 1);
                    }
                    if (FireEnabled == true)
                    {
                        PlayerPrefs.SetInt("beatOnMediumasFire", 1);
                    }
                    if (PoliceEnabled == true)
                    {
                        PlayerPrefs.SetInt("beatOnMediumasPolice", 1);
                    }
                }
            }

            if (isBig == true)
            {
                if (agenciesEnabled > 1)
                {
                    if (agenciesEnabled == 2)
                    {
                        PlayerPrefs.SetInt("beatOnBigas2A", 1);
                    }
                    if (agenciesEnabled == 3)
                    {
                        PlayerPrefs.SetInt("beatOnBigas3A", 1);
                    }
                }
                else
                {
                    if (EMSEnabled == true)
                    {
                        PlayerPrefs.SetInt("beatOnBigasEMS", 1);
                    }
                    if (FireEnabled == true)
                    {
                        PlayerPrefs.SetInt("beatOnBigasFire", 1);
                    }
                    if (PoliceEnabled == true)
                    {
                        PlayerPrefs.SetInt("beatOnBigasPolice", 1);
                    }
                }
            }
        }
        Win.SetActive(true);
    }
}

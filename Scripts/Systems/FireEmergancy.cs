using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class FireEmergancy : MonoBehaviour
{
    public int priority;
    public float toSceneTime;
    public float timer;
    public float ambulanceTimer;

    public TextMesh toSceneTimer;

    public bool unitOnScene = false;

    public GameObject ControllerModule;
    public Controller controller;

    public bool inZone01;
    public bool inZone02;
    public bool inZone03;
    public bool inZone04;
    public bool inZone05;

    public int zone;

    public FirePulsa pulse;

    public GameObject visualization;

    public bool isReal = false;

    private Ambulance ambulance;
    private FireTruck fireTruck;
    private PoliceCar policeCar;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ToSceneTimer());

        ControllerModule = GameObject.Find("Controller Module");
        controller = ControllerModule.GetComponent("Controller") as Controller;

        transform.rotation = new Quaternion(0, 0, 0, 0);

        Invoke("Visualize", 2);
    }

    // Update is called once per frame
    void Update()
    {
        toSceneTimer.text = ambulanceTimer.ToString();

        if (unitOnScene == false)
        {
            ambulanceTimer = toSceneTime;
        }
        if (unitOnScene == true)
        {
            ambulanceTimer = timer;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (unitOnScene == false)
        {
            if (other.gameObject.tag == "FireBus")
            {
                if (other.GetComponent<FireTruck>() != null)
                {
                    fireTruck = other.GetComponent<FireTruck>();

                    if (fireTruck.available == true)
                    {
                        controller.callsPending--;
                        pulse.Freeze();
                        fireTruck.fireBusCalls++;

                        if (fireTruck.fireBusCalls == 1)
                        {
                            fireTruck.TFire.SetActive(true);
                            fireTruck.callPriority1 = priority;
                            fireTruck.callZone1 = zone;

                        }
                        if (fireTruck.fireBusCalls == 2)
                        {
                            fireTruck.TFire2.SetActive(true);
                            fireTruck.callPriority2 = priority;
                            fireTruck.callZone2 = zone;
                        }
                        if (fireTruck.fireBusCalls == 3)
                        {
                            fireTruck.TFire3.SetActive(true);
                            fireTruck.callPriority3 = priority;
                            fireTruck.callZone3 = zone;
                        }
                        if (fireTruck.fireBusCalls == 4)
                        {
                            fireTruck.TFire4.SetActive(true);
                            fireTruck.callPriority4 = priority;
                            fireTruck.callZone4 = zone;
                        }
                        if (fireTruck.fireBusCalls == 5)
                        {
                            fireTruck.TFire5.SetActive(true);
                            fireTruck.callPriority5 = priority;
                            fireTruck.callZone5 = zone;
                        }

                        fireTruck.OnSceneTimerStart();
                        fireTruck.OnScene();
                        toSceneTime += 100;
                        unitOnScene = true;
                        timer = fireTruck.timer;
                        StartCoroutine(OnSceneTimer());
                        Destroy(gameObject, fireTruck.timer);
                    }
                }
            }
        }
        

        if (other.gameObject.tag == "FireTruck" || other.gameObject.tag == "AirFireTruck" || other.gameObject.tag == "EMSFireHybrid" || other.gameObject.tag == "FirePoliceHybrid" || other.gameObject.tag == "EMSPoliceFireHybrid")
        {
            if (unitOnScene == false)
            {
                controller.callsPending--;

                if (other.GetComponent<Ambulance>() != null)
                {
                    ambulance = other.GetComponent<Ambulance>();

                    if (ambulance.available == true)
                    {
                        controller.callsPending--;
                        pulse.Freeze();
                        ambulance.priority = priority;
                        ambulance.zone = zone;
                        ambulance.CaughtFire = true;

                        ambulance.OnSceneTimerStart();
                        ambulance.OnScene();
                        toSceneTime += 100;
                        StartCoroutine(OnSceneTimer());
                        unitOnScene = true;
                        timer = ambulance.timer;
                        Destroy(gameObject, ambulance.timer);
                    }
                }

                if (other.GetComponent<FireTruck>() != null)
                {
                    fireTruck = other.GetComponent<FireTruck>();

                    if (fireTruck.available == true)
                    {
                        controller.callsPending--;
                        pulse.Freeze();
                        fireTruck.priority = priority;
                        fireTruck.zone = zone;
                        fireTruck.CaughtFire = true;

                        fireTruck.OnSceneTimerStart();
                        fireTruck.OnScene();
                        toSceneTime += 100;
                        unitOnScene = true;
                        timer = fireTruck.timer;
                        StartCoroutine(OnSceneTimer());
                        Destroy(gameObject, fireTruck.timer);
                    }
                }

                if (other.GetComponent<PoliceCar>() != null)
                {
                    policeCar = other.GetComponent<PoliceCar>();

                    if (policeCar.available == true)
                    {
                        pulse.Freeze();
                        policeCar.priority = priority;
                        policeCar.zone = zone;
                        policeCar.CaughtFire = true;

                        policeCar.OnSceneTimerStart();
                        policeCar.OnScene();
                        toSceneTime += 100;
                        unitOnScene = true;
                        StartCoroutine(OnSceneTimer());
                        timer = policeCar.timer;
                        Destroy(gameObject, policeCar.timer);
                    }
                }
            }
        }

        if (other.gameObject.tag == "Zone2ToBuy" || other.gameObject.tag == "Zone3ToBuy" || other.gameObject.tag == "Zone4ToBuy" || other.gameObject.tag == "Zone5ToBuy" || other.gameObject.tag == "Emergancy" || other.gameObject.tag == "FireEmergancy" || other.gameObject.tag == "PoliceEmergancy"
            || other.gameObject.tag == "Station")
        {
            if (isReal == false)
            {
                ControllerModule = GameObject.Find("Controller Module");
                controller = ControllerModule.GetComponent("Controller") as Controller;

                controller.spawnEmergancies();
                Destroy(this.gameObject);
            }
        }
    }

    public IEnumerator ToSceneTimer()
    {
        if (unitOnScene == true)
        {
            yield break;
        }
        while (toSceneTime > 0)
        {
            yield return new WaitForSeconds(1.0f);
            toSceneTime--;
        }
        if (toSceneTime <= 0)
        {
            priority = 0;
            if (inZone01 == true)
            {
                controller.zone01Loyalty -= 10;
            }

            if (inZone02 == true)
            {
                controller.zone02Loyalty -= 10;
            }

            if (inZone03 == true)
            {
                controller.zone03Loyalty -= 10;
            }

            if (inZone04 == true)
            {
                controller.zone04Loyalty -= 10;
            }

            if (inZone05 == true)
            {
                controller.zone05Loyalty -= 10;
            }

            controller.fireLoyalty -= 10;
        }
    }


    public IEnumerator OnSceneTimer()
    {
        while (timer > 0)
        {
            yield return new WaitForSeconds(1.0f);
            timer--;
        }
    }

    public void Visualize()
    {
        isReal = true;
        visualization.SetActive(true);
        controller.callsPending++;
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : MonoBehaviour
{
    public bool found;
    public bool turned = false;

    public int findings;

    public GameObject Counterer;

    public CounterManager counter;

    public int zone = 0;
    public int set = 0;

    public GameObject[] spawns;

    public GameObject zone1Filler;

    public GameObject worldGen;

    public WorldGeneration worldGenS;

    public GameObject river;
    public bool isBridge;

    public bool isRiverTurn;
    public bool isSpawned;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(WorldGenZone1());

        Counterer = GameObject.Find("Counterer");

        counter = Counterer.GetComponent("CounterManager") as CounterManager;

        zone1Filler = GameObject.Find("ZoneFillerSpawner");

        zone = counter.zone;
        set = counter.set;


        worldGen = GameObject.Find("WorldGenerator");

        worldGenS = worldGen.GetComponent("WorldGeneration") as WorldGeneration;


        if (zone == 1)
        {
            if (set == 1)
            {
                counter.zone1Set1++;
            }
        }

        if (zone == 2)
        {
            if (set == 1)
            {
                counter.zone2Set1++;
            }
            if (set == 2)
            {
                counter.zone2Set2++;
            }
            if (set == 3)
            {
                counter.zone2Set3++;
            }
            if (set == 4)
            {
                counter.zone2Set4++;
            }
            if (set == 5)
            {
                counter.zone2Set5++;
            }
        }

        if (zone == 3)
        {
            if (set == 1)
            {
                counter.zone3Set1++;
            }
            if (set == 2)
            {
                counter.zone3Set2++;
            }
            if (set == 3)
            {
                counter.zone3Set3++;
            }
            if (set == 4)
            {
                counter.zone3Set4++;
            }
            if (set == 5)
            {
                counter.zone3Set5++;
            }
            if (set == 6)
            {
                counter.zone3Set6++;
            }
        }

        if (zone == 4)
        {
            if (set == 1)
            {
                counter.zone4Set1++;
            }
            if (set == 2)
            {
                counter.zone4Set2++;
            }
            if (set == 3)
            {
                counter.zone4Set3++;
            }
            if (set == 4)
            {
                counter.zone4Set4++;
            }
            if (set == 5)
            {
                counter.zone4Set5++;
            }
            if (set == 6)
            {
                counter.zone4Set6++;
            }
            if (set == 7)
            {
                counter.zone4Set7++;
            }
        }

        if (zone == 5)
        {
            if (set == 1)
            {
                counter.zone5Set1++;
            }
            if (set == 2)
            {
                counter.zone5Set2++;
            }
            if (set == 3)
            {
                counter.zone5Set3++;
            }
            if (set == 4)
            {
                counter.zone5Set4++;
            }
            if (set == 5)
            {
                counter.zone5Set5++;
            }
            if (set == 6)
            {
                counter.zone5Set6++;
            }
            if (set == 7)
            {
                counter.zone5Set7++;
            }
            if (set == 8)
            {
                counter.zone5Set8++;
            }
            if (set == 9)
            {
                counter.zone5Set9++;
            }
            if (set == 10)
            {
                counter.zone5Set10++;
            }
        }

        if (isRiverTurn == true)
        {
            if (worldGenS.riverTurnsSpawned > 0)
            {
                Destroy(this.gameObject, 0.01f);
                Instantiate(river, this.gameObject.transform.position, this.gameObject.transform.rotation);
            }
            worldGenS.riverTurnsSpawned++;
        }

        Invoke("IsSpawned", 0.1f);

    }

    public IEnumerator WorldGenZone1()
    {

        yield return new WaitForSeconds(0.01f);
        if (found == false)
        {
            transform.Rotate(0, 90, 0);
        }
    }

    public void Update()
    {

        if (found == false)
        {
            transform.Rotate(0, 90, 0);
        }


        if (found == true)
        {
            if (turned == false)
            {
                for (int i = 0; i < spawns.Length; i++)
                {
                    spawns[i].SetActive(true);
                }
                turned = true;
            }
        }




        if (zone == 2)
        {
            if (counter.zone2WinnerDecided == true)
            {
                if (set != counter.zone2WinnerZone)
                {
                    if (isBridge == false)
                    {
                        Destroy(this.gameObject, 0.01f);
                        Instantiate(zone1Filler, this.gameObject.transform.position, this.gameObject.transform.rotation);
                    }
                    else
                    {
                        Destroy(this.gameObject, 0.01f);
                        Instantiate(river, this.gameObject.transform.position, this.gameObject.transform.rotation);
                    }
                }
            }
        }

        if (zone == 3)
        {
            if (counter.zone3WinnerDecided == true)
            {
                if (set != counter.zone3WinnerZone)
                {
                    if (isBridge == false)
                    {
                        Destroy(this.gameObject, 0.01f);
                        Instantiate(zone1Filler, this.gameObject.transform.position, this.gameObject.transform.rotation);
                    }
                    else
                    {
                        Destroy(this.gameObject, 0.01f);
                        Instantiate(river, this.gameObject.transform.position, this.gameObject.transform.rotation);
                    }
                }
            }
        }

        if (zone == 4)
        {
            if (counter.zone4WinnerDecided == true)
            {
                if (set != counter.zone4WinnerZone)
                {
                    if (isBridge == false)
                    {
                        Destroy(this.gameObject, 0.01f);
                        Instantiate(zone1Filler, this.gameObject.transform.position, this.gameObject.transform.rotation);
                    }
                    else
                    {
                        Destroy(this.gameObject, 0.01f);
                        Instantiate(river, this.gameObject.transform.position, this.gameObject.transform.rotation);
                    }
                }
            }
        }

        if (zone == 5)
        {
            if (counter.zone5WinnerDecided == true)
            {
                if (set != counter.zone5WinnerZone)
                {
                    if (isBridge == false)
                    {
                        Destroy(this.gameObject, 0.01f);
                        Instantiate(zone1Filler, this.gameObject.transform.position, this.gameObject.transform.rotation);
                    }
                    else
                    {
                        Destroy(this.gameObject, 0.01f);
                        Instantiate(river, this.gameObject.transform.position, this.gameObject.transform.rotation);
                    }
                }
            }
        }

        if (worldGenS.generationFinished == true)
        {
            Vector3 pos = transform.position;
            pos.y = -0.5f;
            transform.position = pos;

            Destroy(this, 1);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Zone1" || other.gameObject.tag == "Zone2" || other.gameObject.tag == "Zone3" || other.gameObject.tag == "Zone4" || other.gameObject.tag == "Zone5"
            || other.gameObject.tag == "River" || other.gameObject.tag == "RiverTurn")
        {
            if (isSpawned == false)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void IsSpawned()
    {
        isSpawned = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class WorldGeneration : MonoBehaviour
{
    public NavMeshSurface[] navMeshSurfaces;

    public int loading;
    public Text loadDisplay;
    public GameObject loadingDisplay;

    public GameObject[] riverSpawners;
    public GameObject[] rivers;

    public GameObject[] preZone1Spawners;

    public GameObject[] zone1Spawners;
    public GameObject[] zone1;
    public GameObject[] zone1Spawned;

    public GameObject[] zone2Spawners;
    public GameObject[] zone2;
    public GameObject[] zone2Spawned;

    public GameObject[] zone3Spawners;
    public GameObject[] zone3;
    public GameObject[] zone3Spawned;

    public GameObject[] zone4Spawners;
    public GameObject[] zone4;
    public GameObject[] zone4Spawned;

    public GameObject[] zone5Spawners;
    public GameObject[] zone5;
    public GameObject[] zone5Spawned;

    public float zone1Spawns;
    public float zone1Set;
    public float zone2Spawns;
    public float zone2Set;
    public float zone3Spawns;
    public float zone3Set;
    public float zone4Spawns;
    public float zone4Set;
    public float zone5Spawns;
    public float zone5Set;

    public float spawnSpeed;

    public bool finished = false;

    public CounterManager counter;

    public bool mapFilled = false;

    public GameObject zone1Filler;
    public GameObject zone2Filler;
    public GameObject zone3Filler;
    public GameObject zone4Filler;
    public GameObject zone5Filler;

    public GameObject[] fillerZ1;
    public GameObject[] fillerZ2;
    public GameObject[] fillerZ3;
    public GameObject[] fillerZ4;
    public GameObject[] fillerZ5;

    public GameObject ControllerModule;
    private Controller controller;

    public bool fillFinished = false;

    public bool generationFinished = false;

    public GameObject zone2Spawn;
    public GameObject zone3Spawn;
    public GameObject zone4Spawn;
    public GameObject zone5Spawn;

    public bool fillerDeletion = false;

    public float timer;
    public float timerSet;

    public ZoneBuy2 zoneBuy2;

    public GameObject InitialRiver;

    public GameObject InitialGroup;
    public GameObject Background;

    public GameObject PreZone1;
    public GameObject InitialZone1Group;

    public bool isTesting;

    public bool Big;
    public bool Medium;
    public bool Small;

    public WorldSize worldSize;

    public int riverTurnsSpawned;

    public Slider isLoading;

    public GameObject error;

    void Start()
    {
        ControllerModule = GameObject.Find("Controller Module");
        controller = ControllerModule.GetComponent("Controller") as Controller;

        loading = 4;
    }

    public void Update()
    {
        GetWorldSpawnPoints();
        //        loadDisplay.text = (loading.ToString() + " %");

        isLoading.value = loading;
    }

    public void GetWorldSpawnPoints()
    {
        riverSpawners = GameObject.FindGameObjectsWithTag("RiverSpawner");
        preZone1Spawners = GameObject.FindGameObjectsWithTag("PreWorldSpawner");
        zone1Spawners = GameObject.FindGameObjectsWithTag("WorldSpawner");
        zone2Spawners = GameObject.FindGameObjectsWithTag("WorldSpawner2");
        zone3Spawners = GameObject.FindGameObjectsWithTag("WorldSpawner3");
        zone4Spawners = GameObject.FindGameObjectsWithTag("WorldSpawner4");
        zone5Spawners = GameObject.FindGameObjectsWithTag("WorldSpawner5");
        zone1Spawned = GameObject.FindGameObjectsWithTag("Zone1");
        zone2Spawned = GameObject.FindGameObjectsWithTag("Zone2");
        zone3Spawned = GameObject.FindGameObjectsWithTag("Zone3");
        zone4Spawned = GameObject.FindGameObjectsWithTag("Zone4");
        zone5Spawned = GameObject.FindGameObjectsWithTag("Zone5");
        fillerZ1 = GameObject.FindGameObjectsWithTag("WorldFillerZ1");
        fillerZ2 = GameObject.FindGameObjectsWithTag("WorldFillerZ2");
        fillerZ3 = GameObject.FindGameObjectsWithTag("WorldFillerZ3");
        fillerZ4 = GameObject.FindGameObjectsWithTag("WorldFillerZ4");
        fillerZ5 = GameObject.FindGameObjectsWithTag("WorldFillerZ5");
    }

    public void ToStart()
    {
        if (Big == true)
        {
            zone1Set *= 1.5f;
            zone2Set *= 1.5f;
            zone3Set *= 1.5f;
            zone4Set *= 1.5f;
            zone5Set *= 1.5f;
            worldSize.Big();
            StartCoroutine(InitialSpawn());
        }
        if (Medium == true)
        {
            StartCoroutine(InitialSpawn());
        }
        if (Small == true)
        {
            zone1Set /= 1.5f;
            zone2Set /= 1.5f;
            zone3Set /= 1.5f;
            zone4Set /= 1.5f;
            zone5Set /= 1.5f;
            worldSize.Small();
            StartCoroutine(InitialSpawn());
        }

        loading = 8;
    }

    public IEnumerator InitialSpawn()
    {
        yield return new WaitForSeconds(spawnSpeed);
        loading = 12;

        int Zone1SpawnersIndex = Random.Range(0, riverSpawners.Length);
        Instantiate(InitialRiver, riverSpawners[Zone1SpawnersIndex].transform.position, riverSpawners[Zone1SpawnersIndex].transform.rotation);

        Destroy(InitialGroup);

        yield return new WaitForSeconds(spawnSpeed);

        loading = 16;
        StartCoroutine(PreWorldGen());
    }

    public IEnumerator PreWorldGen()
    {
        yield return new WaitForSeconds(spawnSpeed);
        loading = 20;

        while (riverSpawners.Length > 0)
        {
            int Zone1SpawnersIndex = Random.Range(0, riverSpawners.Length);
            int Zone1Index = Random.Range(0, rivers.Length);
            Instantiate(rivers[Zone1Index], riverSpawners[Zone1SpawnersIndex].transform.position, riverSpawners[Zone1SpawnersIndex].transform.rotation);

            print("river spawn");
            yield return new WaitForSeconds(spawnSpeed * 5);
        }

        if (riverSpawners.Length == 0)
        {
            loading = 24;
            StartCoroutine(InitialSpawnZone1());
            print("pre done");
        }
    }

    public IEnumerator InitialSpawnZone1()
    {
        yield return new WaitForSeconds(spawnSpeed);
        loading = 28;

        int Zone1SpawnersIndex = Random.Range(0, preZone1Spawners.Length);
        Instantiate(PreZone1, preZone1Spawners[Zone1SpawnersIndex].transform.position, preZone1Spawners[Zone1SpawnersIndex].transform.rotation);

        Destroy(InitialZone1Group);

        yield return new WaitForSeconds(spawnSpeed);

        loading = 32;
        StartCoroutine(WorldGenZone1());
    }

    public IEnumerator WorldGenZone1()
    {
        counter.zone = 1;
        counter.set = 1;
        loading = 36;

        yield return new WaitForSeconds(spawnSpeed);

        while (zone1Spawns < zone1Set)
        {
            yield return new WaitForSeconds(spawnSpeed);

            if (zone1Spawners.Length > 0)
            {
                int Zone1SpawnersIndex = Random.Range(0, zone1Spawners.Length);
                int Zone1Index = Random.Range(0, zone1.Length);
                Instantiate(zone1[Zone1Index], zone1Spawners[Zone1SpawnersIndex].transform.position, zone1Spawners[Zone1SpawnersIndex].transform.rotation);
                zone1Spawns = zone1Spawned.Length;
            }
        }


        if (zone1Spawns >= zone1Set)
        {
            int Zone1SpawnersIndex = Random.Range(0, zone1Spawners.Length);
            Instantiate(zone2Spawn, zone1Spawners[Zone1SpawnersIndex].transform.position, zone1Spawners[Zone1SpawnersIndex].transform.rotation);
            StartCoroutine(WorldGenZone2());
            print("zone 1 done");
            loading = 40;
        }
    }


    public IEnumerator WorldGenZone2()
    {
        counter.zone = 2;
        counter.set = 1;
        loading = 44;

        while (zone2Spawns < zone2Set)
        {
            yield return new WaitForSeconds(spawnSpeed);
            timer++;
            if (zone1Spawners.Length > 0)
            {
                if (zone2Spawners.Length > 0)
                {
                    int Zone1SpawnersIndex = Random.Range(0, zone2Spawners.Length);
                    int Zone1Index = Random.Range(0, zone2.Length);
                    Instantiate(zone2[Zone1Index], zone2Spawners[Zone1SpawnersIndex].transform.position, zone2Spawners[Zone1SpawnersIndex].transform.rotation);
                    zone2Spawns = zone2Spawned.Length;

                    yield return new WaitForSeconds(spawnSpeed);
                }

                else if (timer > timerSet)
                {
                    counter.set++;
                    zone2Set += zone2Spawns;
                    int Zone1SpawnersIndex = Random.Range(0, zone1Spawners.Length);
                    Instantiate(zone2Spawn, zone1Spawners[Zone1SpawnersIndex].transform.position, zone1Spawners[Zone1SpawnersIndex].transform.rotation);
                    print("reset 2 called");
                    timer = 0;
                }
            }
            else
            {
                error.SetActive(true);
                SceneManager.LoadScene(1);
            }

        }

        if (zone2Spawns >= zone2Set)
        {
            int Zone1SpawnersIndex = Random.Range(0, zone1Spawners.Length);
            Instantiate(zone3Spawn, zone1Spawners[Zone1SpawnersIndex].transform.position, zone1Spawners[Zone1SpawnersIndex].transform.rotation);
            StartCoroutine(WorldGenZone3());
            print("zone 2 done");
            loading = 48;
        }
    }


    public IEnumerator WorldGenZone3()
    {
        counter.zone = 3;
        counter.set = 1;
        timer = 0;
        loading = 52;

        while (zone3Spawns < zone3Set)
        {
            yield return new WaitForSeconds(spawnSpeed);
            timer++;
            if (zone1Spawners.Length > 0)
            {
                if (zone3Spawners.Length > 0)
                {
                    int Zone1SpawnersIndex = Random.Range(0, zone3Spawners.Length);
                    int Zone1Index = Random.Range(0, zone3.Length);
                    Instantiate(zone3[Zone1Index], zone3Spawners[Zone1SpawnersIndex].transform.position, zone3Spawners[Zone1SpawnersIndex].transform.rotation);
                    zone3Spawns = zone3Spawned.Length;

                    yield return new WaitForSeconds(spawnSpeed);
                }

                else if (timer > timerSet)
                {
                    counter.set++;
                    zone3Set += zone3Spawns;
                    int Zone1SpawnersIndex = Random.Range(0, zone1Spawners.Length);
                    Instantiate(zone3Spawn, zone1Spawners[Zone1SpawnersIndex].transform.position, zone1Spawners[Zone1SpawnersIndex].transform.rotation);
                    print("reset 3 called");
                    timer = 0;
                }
            }
            else
            {
                error.SetActive(true);
                SceneManager.LoadScene(1);
            }
        }

        if (zone3Spawns >= zone3Set)
        {
            int Zone1SpawnersIndex = Random.Range(0, zone1Spawners.Length);
            Instantiate(zone4Spawn, zone1Spawners[Zone1SpawnersIndex].transform.position, zone1Spawners[Zone1SpawnersIndex].transform.rotation);
            StartCoroutine(WorldGenZone4());
            print("zone 3 done");
            loading = 56;
        }
    }


    public IEnumerator WorldGenZone4()
    {
        counter.zone = 4;
        counter.set = 1;
        timer = 0;
        loading = 60;

        while (zone4Spawns < zone4Set)
        {
            yield return new WaitForSeconds(spawnSpeed);
            timer++;

            if (zone1Spawners.Length > 0)
            {
                if (zone4Spawners.Length > 0)
                {
                    int Zone1SpawnersIndex = Random.Range(0, zone4Spawners.Length);
                    int Zone1Index = Random.Range(0, zone4.Length);
                    Instantiate(zone4[Zone1Index], zone4Spawners[Zone1SpawnersIndex].transform.position, zone4Spawners[Zone1SpawnersIndex].transform.rotation);
                    zone4Spawns = zone4Spawned.Length;

                    yield return new WaitForSeconds(spawnSpeed);
                }

                else if (timer > timerSet)
                {
                    counter.set++;
                    zone4Set += zone4Spawns;
                    int Zone1SpawnersIndex = Random.Range(0, zone1Spawners.Length);
                    Instantiate(zone4Spawn, zone1Spawners[Zone1SpawnersIndex].transform.position, zone1Spawners[Zone1SpawnersIndex].transform.rotation);
                    print("reset 4 called");
                    timer = 0;
                }
            }
            else
            {
                error.SetActive(true);
                SceneManager.LoadScene(1);
            }
        }

        if (zone4Spawns >= zone4Set)
        {
            int Zone1SpawnersIndex = Random.Range(0, zone1Spawners.Length);
            Instantiate(zone5Spawn, zone1Spawners[Zone1SpawnersIndex].transform.position, zone1Spawners[Zone1SpawnersIndex].transform.rotation);
            StartCoroutine(WorldGenZone5());
            print("zone 4 done");
            loading = 64;
        }
    }


    public IEnumerator WorldGenZone5()
    {
        counter.zone = 5;
        counter.set = 1;
        timer = 0;
        loading = 68;

        while (zone5Spawns < zone5Set)
        {
            yield return new WaitForSeconds(spawnSpeed);
            timer++;

            if (zone1Spawners.Length > 0)
            {
                if (zone5Spawners.Length > 0)
                {
                    int Zone1SpawnersIndex = Random.Range(0, zone5Spawners.Length);
                    int Zone1Index = Random.Range(0, zone5.Length);
                    Instantiate(zone5[Zone1Index], zone5Spawners[Zone1SpawnersIndex].transform.position, zone5Spawners[Zone1SpawnersIndex].transform.rotation);
                    zone5Spawns = zone5Spawned.Length;

                    yield return new WaitForSeconds(spawnSpeed);
                }

                else if (timer > timerSet)
                {
                    counter.set++;
                    zone5Set += zone5Spawns;
                    int Zone1SpawnersIndex = Random.Range(0, zone1Spawners.Length);
                    Instantiate(zone5Spawn, zone1Spawners[Zone1SpawnersIndex].transform.position, zone1Spawners[Zone1SpawnersIndex].transform.rotation);
                    print("reset 5 called");
                    timer = 0;
                }
            }
            else
            {
                error.SetActive(true);
                SceneManager.LoadScene(1);
            }
        }

        if (zone5Spawns >= zone5Set)
        {
            StartCoroutine(Sorting());
            print("zone 5 done");
            loading = 72;
        }
    }

    public IEnumerator Sorting()
    {
        yield return new WaitForSeconds(spawnSpeed);
        counter.Sort();
        yield return new WaitForSeconds(spawnSpeed * 10);
        StartCoroutine(WorldGenFiller());
        loading = 76;
    }


    public IEnumerator WorldGenFiller()
    {
        loading = 80;


        while (fillFinished == false)
        {
            yield return new WaitForSeconds(spawnSpeed);

            if (zone1Spawners.Length > 0)
            {
                int Zone1SpawnersIndex = Random.Range(0, zone1Spawners.Length);
                int Zone1Index = Random.Range(0, zone1.Length);
                Instantiate(zone1[Zone1Index], zone1Spawners[Zone1SpawnersIndex].transform.position, zone1Spawners[Zone1SpawnersIndex].transform.rotation);
                zone1Spawns = zone1Spawned.Length;
            }

            if (zone2Spawners.Length > 0)
            {
                yield return new WaitForSeconds(spawnSpeed);
                int Zone1SpawnersIndex = Random.Range(0, zone2Spawners.Length);
                int Zone1Index = Random.Range(0, zone2.Length);
                Instantiate(zone2[Zone1Index], zone2Spawners[Zone1SpawnersIndex].transform.position, zone2Spawners[Zone1SpawnersIndex].transform.rotation);
                zone2Spawns = zone2Spawned.Length;
            }

            if (zone3Spawners.Length > 0)
            {
                yield return new WaitForSeconds(spawnSpeed);
                int Zone1SpawnersIndex = Random.Range(0, zone3Spawners.Length);
                int Zone1Index = Random.Range(0, zone3.Length);
                Instantiate(zone3[Zone1Index], zone3Spawners[Zone1SpawnersIndex].transform.position, zone3Spawners[Zone1SpawnersIndex].transform.rotation);
                zone3Spawns = zone3Spawned.Length;
            }

            if (zone4Spawners.Length > 0)
            {
                yield return new WaitForSeconds(spawnSpeed);
                int Zone1SpawnersIndex = Random.Range(0, zone4Spawners.Length);
                int Zone1Index = Random.Range(0, zone4.Length);
                Instantiate(zone4[Zone1Index], zone4Spawners[Zone1SpawnersIndex].transform.position, zone4Spawners[Zone1SpawnersIndex].transform.rotation);
                zone4Spawns = zone4Spawned.Length;
            }

            if (zone5Spawners.Length > 0)
            {
                yield return new WaitForSeconds(spawnSpeed);
                int Zone1SpawnersIndex = Random.Range(0, zone5Spawners.Length);
                int Zone1Index = Random.Range(0, zone5.Length);
                Instantiate(zone5[Zone1Index], zone5Spawners[Zone1SpawnersIndex].transform.position, zone5Spawners[Zone1SpawnersIndex].transform.rotation);
                zone5Spawns = zone5Spawned.Length;
            }

            if (zone1Spawners.Length == 0 && zone2Spawners.Length == 0 && zone3Spawners.Length == 0 && zone4Spawners.Length == 0 && zone5Spawners.Length == 0)
            {
                fillFinished = true;
                print("Gen Fill Done");
                StartCoroutine(Fill());
                loading = 90;
            }

        }
    }


    public IEnumerator Fill()
    {
        fillerDeletion = true;
        loading = 95;

        while (mapFilled == false)
        {
            yield return new WaitForSeconds(spawnSpeed);
            if (fillerZ1.Length > 0)
            {
                int Zone1SpawnersIndex = Random.Range(0, fillerZ1.Length);
                Instantiate(zone1Filler, fillerZ1[Zone1SpawnersIndex].transform.position, fillerZ1[Zone1SpawnersIndex].transform.rotation);
                zone1Spawns = zone1Spawned.Length;
            }

            yield return new WaitForSeconds(spawnSpeed);
            if (fillerZ2.Length > 0)
            {
                int Zone1SpawnersIndex = Random.Range(0, fillerZ2.Length);
                Instantiate(zone2Filler, fillerZ2[Zone1SpawnersIndex].transform.position, fillerZ2[Zone1SpawnersIndex].transform.rotation);
                zone1Spawns = zone1Spawned.Length;
            }

            yield return new WaitForSeconds(spawnSpeed);
            if (fillerZ3.Length > 0)
            {
                int Zone1SpawnersIndex = Random.Range(0, fillerZ3.Length);
                Instantiate(zone3Filler, fillerZ3[Zone1SpawnersIndex].transform.position, fillerZ3[Zone1SpawnersIndex].transform.rotation);
                zone1Spawns = zone1Spawned.Length;
            }

            yield return new WaitForSeconds(spawnSpeed);
            if (fillerZ4.Length > 0)
            {
                int Zone1SpawnersIndex = Random.Range(0, fillerZ4.Length);
                Instantiate(zone4Filler, fillerZ4[Zone1SpawnersIndex].transform.position, fillerZ4[Zone1SpawnersIndex].transform.rotation);
                zone1Spawns = zone1Spawned.Length;
            }

            yield return new WaitForSeconds(spawnSpeed);
            if (fillerZ5.Length > 0)
            {
                int Zone1SpawnersIndex = Random.Range(0, fillerZ5.Length);
                Instantiate(zone5Filler, fillerZ5[Zone1SpawnersIndex].transform.position, fillerZ5[Zone1SpawnersIndex].transform.rotation);
                zone1Spawns = zone1Spawned.Length;
            }

            if (fillerZ1.Length == 0 && fillerZ2.Length == 0 && fillerZ3.Length == 0 && fillerZ4.Length == 0 && fillerZ5.Length == 0)
            {
                mapFilled = true;
            }
        }

        loading = 100;
        generationFinished = true;
        GenDone();
        controller.LoadingDone();
        loadingDisplay.SetActive(false);
        Background.SetActive(false);
        Invoke("GetMapping", 1);
    }

    public void Testing()
    {
        spawnSpeed = 0.02f;
    }

    public void GetMapping()
    {
        for (int i = 0; i < navMeshSurfaces.Length; i++)
        {
            navMeshSurfaces[i].BuildNavMesh();
        }
        Background.SetActive(true);
        zoneBuy2.GetZoneBuys();
        print("fill finished");
        Destroy(this.gameObject, 2);
    }

    public void GenDone()
    {

    }
}

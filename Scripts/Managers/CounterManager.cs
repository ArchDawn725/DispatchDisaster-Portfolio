using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterManager : MonoBehaviour
{

    public int zone = 0;
    public int set = 0;

    public int zone1Set1 = 0;

    public int zone2Set1 = 0;
    public int zone2Set2 = 0;
    public int zone2Set3 = 0;
    public int zone2Set4 = 0;
    public int zone2Set5 = 0;

    public int zone2Winner;
    public int zone2WinnerZone;
    public bool zone2WinnerDecided = false;

    public int zone3Set1 = 0;
    public int zone3Set2 = 0;
    public int zone3Set3 = 0;
    public int zone3Set4 = 0;
    public int zone3Set5 = 0;  
    public int zone3Set6 = 0;

    public int zone3Winner;
    public int zone3WinnerZone;
    public bool zone3WinnerDecided = false;

    public int zone4Set1 = 0;
    public int zone4Set2 = 0;
    public int zone4Set3 = 0;
    public int zone4Set4 = 0;
    public int zone4Set5 = 0;
    public int zone4Set6 = 0; 
    public int zone4Set7 = 0;

    public int zone4Winner;
    public int zone4WinnerZone;
    public bool zone4WinnerDecided = false;

    public int zone5Set1 = 0;
    public int zone5Set2 = 0;
    public int zone5Set3 = 0;
    public int zone5Set4 = 0;
    public int zone5Set5 = 0;
    public int zone5Set6 = 0;
    public int zone5Set7 = 0;
    public int zone5Set8 = 0;
    public int zone5Set9 = 0;
    public int zone5Set10 = 0;

    public int zone5Winner;
    public int zone5WinnerZone;
    public bool zone5WinnerDecided = false;


    public GameObject worldGen;

    public WorldGeneration worldGenS;

    public bool sortingDone;

    void Start()
    {

        worldGen = GameObject.Find("WorldGenerator");

        worldGenS = worldGen.GetComponent("WorldGeneration") as WorldGeneration;
    }

        public void Sort()
    {

        print("sort called");
        worldGenS.GetWorldSpawnPoints();

        zone2Winner = Mathf.Max(zone2Set1, zone2Set2, zone2Set3, zone2Set4, zone2Set5);

        if (zone2Winner == zone2Set1)
        {
            zone2WinnerZone = 1;
        }
        if (zone2Winner == zone2Set2)
        {
            zone2WinnerZone = 2;
        }
        if (zone2Winner == zone2Set3)
        {
            zone2WinnerZone = 3;
        }
        if (zone2Winner == zone2Set4)
        {
            zone2WinnerZone = 4;
        }
        if (zone2Winner == zone2Set5)
        {
            zone2WinnerZone = 5;
        }


        zone3Winner = Mathf.Max(zone3Set1, zone3Set2, zone3Set3, zone3Set4, zone3Set5, zone3Set6);

        if (zone3Winner == zone3Set1)
        {
            zone3WinnerZone = 1;
        }
        if (zone3Winner == zone3Set2)
        {
            zone3WinnerZone = 2;
        }
        if (zone3Winner == zone3Set3)
        {
            zone3WinnerZone = 3;
        }
        if (zone3Winner == zone3Set4)
        {
            zone3WinnerZone = 4;
        }
        if (zone3Winner == zone3Set5)
        {
            zone3WinnerZone = 5;
        }
        if (zone3Winner == zone3Set6)
        {
            zone3WinnerZone = 6;
        }


        zone4Winner = Mathf.Max(zone4Set1, zone4Set2, zone4Set3, zone4Set4, zone4Set5, zone4Set6, zone4Set7);

        if (zone4Winner == zone4Set1)
        {
            zone4WinnerZone = 1;
        }
        if (zone4Winner == zone4Set2)
        {
            zone4WinnerZone = 2;
        }
        if (zone4Winner == zone4Set3)
        {
            zone4WinnerZone = 3;
        }
        if (zone4Winner == zone4Set4)
        {
            zone4WinnerZone = 4;
        }
        if (zone4Winner == zone4Set5)
        {
            zone4WinnerZone = 5;
        }
        if (zone4Winner == zone4Set6)
        {
            zone4WinnerZone = 6;
        }
        if (zone4Winner == zone4Set7)
        {
            zone4WinnerZone = 7;
        }


        zone5Winner = Mathf.Max(zone5Set1, zone5Set2, zone5Set3, zone5Set4, zone5Set5, zone5Set6, zone5Set7, zone5Set8, zone5Set9, zone5Set10);

        if (zone5Winner == zone5Set1)
        {
            zone5WinnerZone = 1;
        }
        if (zone5Winner == zone5Set2)
        {
            zone5WinnerZone = 2;
        }
        if (zone5Winner == zone5Set3)
        {
            zone5WinnerZone = 3;
        }
        if (zone5Winner == zone5Set4)
        {
            zone5WinnerZone = 4;
        }
        if (zone5Winner == zone5Set5)
        {
            zone5WinnerZone = 5;
        }
        if (zone5Winner == zone5Set6)
        {
            zone5WinnerZone = 6;
        }
        if (zone5Winner == zone5Set7)
        {
            zone5WinnerZone = 7;
        }
        if (zone5Winner == zone5Set8)
        {
            zone5WinnerZone = 8;
        }
        if (zone5Winner == zone5Set9)
        {
            zone5WinnerZone = 9;
        }
        if (zone5Winner == zone5Set10)
        {
            zone5WinnerZone = 10;
        }

        zone2WinnerDecided = true;
        zone3WinnerDecided = true;
        zone4WinnerDecided = true;
        zone5WinnerDecided = true;

        worldGenS.GetWorldSpawnPoints();
        sortingDone = true;
    }

    public void Update()
    {
        if (worldGenS.generationFinished == true)
        {
            Destroy(this.gameObject, 1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenSpawnerR : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Zone1" || other.gameObject.tag == "WorldSpawner2" || other.gameObject.tag == "Zone2" || other.gameObject.tag == "WorldSpawner3" || other.gameObject.tag == "Zone3" || other.gameObject.tag == "WorldSpawner4" || other.gameObject.tag == "Zone4" || other.gameObject.tag == "WorldSpawner5" || other.gameObject.tag == "Zone5"
            || other.gameObject.tag == "River" || other.gameObject.tag == "RiverTurn")
        {
            Destroy(this.gameObject);
        }
    }

    public GameObject worldGen;

    public WorldGeneration worldGenS;

    void Start()
    {

        worldGen = GameObject.Find("WorldGenerator");

        worldGenS = worldGen.GetComponent("WorldGeneration") as WorldGeneration;
    }

    public void Update()
    {
        if (worldGenS.generationFinished == true)
        {
            Destroy(this.gameObject);
        }
    }
}

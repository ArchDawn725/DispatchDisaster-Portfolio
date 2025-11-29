using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenSpawnerZ3 : MonoBehaviour
{
    public GameObject Zone3BridgeSpawner;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Zone1" || other.gameObject.tag == "Zone2" || other.gameObject.tag == "Zone3" || other.gameObject.tag == "WorldSpawner4" || other.gameObject.tag == "Zone4" || other.gameObject.tag == "WorldSpawner5" || other.gameObject.tag == "Zone5"
            || other.gameObject.tag == "RiverTurn")
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "River")
        {
            this.gameObject.tag = "Player";
            Invoke("SpawnBridge", 0.2f);
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

    public void SpawnBridge()
    {
        Instantiate(Zone3BridgeSpawner, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCheck3 : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WorldSpawner" || other.gameObject.tag == "WorldSpawner2" || other.gameObject.tag == "WorldSpawner3" || other.gameObject.tag == "WorldSpawner4" || other.gameObject.tag == "WorldSpawner5")
        {
            other.gameObject.tag = "Transition3To4";
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverFind : MonoBehaviour
{
    public bool found;

    public Seeker seeker;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "River Connection")
        {
            found = true;
            seeker.found = true;
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
            Destroy(this, 1);
        }
    }
}

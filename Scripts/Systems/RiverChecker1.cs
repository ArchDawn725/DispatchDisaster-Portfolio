using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class RiverChecker1 : MonoBehaviour
{
    public GameObject worldGen;
    public GameObject River;

    public WorldGeneration worldGenS;

    public Seeker seeker;

    public int called;

    public void Start()
    {
        worldGen = GameObject.Find("WorldGenerator");

        worldGenS = worldGen.GetComponent("WorldGeneration") as WorldGeneration;
    }

    public void Update()
    {
        if (worldGenS.generationFinished == true)
        {
            if (seeker.findings <= 2)
            {
                print("destroy me");
                StartSetup();
            }
            else
            {
                Destroy(this);
            }
        }
    }

    public void StartSetup()
    {
        if (called == 0)
        {
            StartCoroutine(Setup());
            called++;
        }
    }

    public IEnumerator Setup()
    {
        yield return new WaitForSeconds(0.1f);
        print("started");
        gameObject.tag = "Untagged";
        Instantiate(River, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}

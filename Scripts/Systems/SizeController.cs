using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SizeController : MonoBehaviour
{
    public GameObject ControllerModule;
    public Controller controller;

    public WorldGeneration worldGen;
    public GameObject WorldGenerator;

    public bool small;
    public bool medium;
    public bool large;

    public Challenges challenge;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Loaded()
    {
        ControllerModule = GameObject.Find("Controller Module");
        controller = ControllerModule.GetComponent("Controller") as Controller;

        WorldGenerator = GameObject.Find("WorldGenerator");
        worldGen = WorldGenerator.GetComponent("WorldGeneration") as WorldGeneration;

//        challenge.Loaded();


        if (large == true)
        {
            worldGen.Big = true;
            controller.isBig = true;
            worldGen.ToStart();
        }
        if (medium == true)
        {
            worldGen.Medium = true;
            controller.isMedium = true;
            worldGen.ToStart();
        }
        if (small == true)
        {
            worldGen.Small = true;
            controller.isSmall = true;
            worldGen.ToStart();
        }

        Destroy(this);
    }

    public void Large()
    {
        large = true;
        SceneManager.LoadScene(2);
    }

    public void Medium()
    {
        medium = true;
        SceneManager.LoadScene(2);
    }

    public void Small()
    {
        small = true;
        SceneManager.LoadScene(2);
    }

    public void Reset()
    {
        small = false;
        medium = false;
        large = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNew : MonoBehaviour
{

    public GameObject ControllerModule;
    private Controller controller;

    // Start is called before the first frame update
    void Start()
    {
        ControllerModule = GameObject.Find("Controller Module");
        controller = ControllerModule.GetComponent("Controller") as Controller;

        controller.spawnEmergancies();
    }
}

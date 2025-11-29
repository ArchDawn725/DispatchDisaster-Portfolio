using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highways : MonoBehaviour
{
    private Ambulance ambulance;
    private FireTruck fireTruck;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ambulance")
        {
            ambulance = other.GetComponent<Ambulance>();

            ambulance.OnHighway();
        }
        if (other.gameObject.tag == "FireTruck")
        {
            fireTruck = other.GetComponent<FireTruck>();

            fireTruck.OnHighway();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ambulance")
        {
            ambulance.NormalSpeed();
        }
        if (other.gameObject.tag == "FireTruck")
        {
            fireTruck.NormalSpeed();
        }
    }
}

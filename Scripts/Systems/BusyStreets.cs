using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusyStreets : MonoBehaviour
{
    private Ambulance ambulance;

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

            ambulance.OffHighway();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ambulance")
        {
            ambulance.NormalSpeed();
        }
    }
}


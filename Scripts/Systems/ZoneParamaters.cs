using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ZoneParamaters : MonoBehaviour
{
    public bool zone01;
    public bool zone02;
    public bool zone03;
    public bool zone04;
    public bool zone05;

    public int zone;

    public EMSEmergancy emergancy;
    public FireEmergancy fireEmergency;
    public PoliceEmergency policeEmergency;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Emergancy")
        {
            emergancy = other.GetComponent<EMSEmergancy>();

            emergancy.zone = zone;

            if (zone01 == true)
            {
                emergancy.inZone01 = true;
            }
            if (zone02 == true)
            {
                emergancy.inZone02 = true;
            }
            if (zone03 == true)
            {
                emergancy.inZone03 = true;
            }
            if (zone04 == true)
            {
                emergancy.inZone04 = true;
            }
            if (zone05 == true)
            {
                emergancy.inZone05 = true;
            }
        }

        if (other.gameObject.tag == "FireEmergancy")
        {
            fireEmergency = other.GetComponent<FireEmergancy>();

            fireEmergency.zone = zone;

            if (zone01 == true)
            {
                fireEmergency.inZone01 = true;
            }
            if (zone02 == true)
            {
                fireEmergency.inZone02 = true;
            }
            if (zone03 == true)
            {
                fireEmergency.inZone03 = true;
            }
            if (zone04 == true)
            {
                fireEmergency.inZone04 = true;
            }
            if (zone05 == true)
            {
                fireEmergency.inZone05 = true;
            }
        }

        if (other.gameObject.tag == "PoliceEmergancy")
        {
            policeEmergency = other.GetComponent<PoliceEmergency>();

            policeEmergency.zone = zone;

            if (zone01 == true)
            {
                policeEmergency.inZone01 = true;
            }
            if (zone02 == true)
            {
                policeEmergency.inZone02 = true;
            }
            if (zone03 == true)
            {
                policeEmergency.inZone03 = true;
            }
            if (zone04 == true)
            {
                policeEmergency.inZone04 = true;
            }
            if (zone05 == true)
            {
                policeEmergency.inZone05 = true;
            }
        }
    }
}

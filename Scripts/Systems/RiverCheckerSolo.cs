using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverCheckerSolo : MonoBehaviour
{
    /*
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Zone1" || other.gameObject.tag == "Zone2" || other.gameObject.tag == "Zone3" || other.gameObject.tag == "Zone4" || other.gameObject.tag == "Zone5")
        {
            Destroy(this.gameObject);
        }
    }
    */

    public Seeker seeker;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WorldSpawner" || other.gameObject.tag == "WorldSpawner2" || other.gameObject.tag == "WorldSpawner3" || other.gameObject.tag == "WorldSpawner4" || other.gameObject.tag == "WorldSpawner5")
        {
            if (seeker.isRiverTurn == false)
            {
                Destroy(this.gameObject);
            }
        }
    }
}

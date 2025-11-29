using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour {

    Light Light;

    public float spinSpeed = 3;

    void Start()
    {
        Light = GetComponent<Light>();
        //StartCoroutine(Flashing());
    }

    private void Update()
    {
        transform.Rotate(spinSpeed, 0, 0 * Time.deltaTime); //rotates 50 degrees per second around z axis
    }

    IEnumerator Flashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            Light.enabled = !Light.enabled;
        }
    }
}
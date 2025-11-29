using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finder : MonoBehaviour
{
    public GameObject world;
    // Start is called before the first frame update
    void Start()
    {
        world = GameObject.Find("World");
        transform.parent = world.transform;
    }
}

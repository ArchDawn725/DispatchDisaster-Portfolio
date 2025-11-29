using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emergancy : MonoBehaviour {
    public Color gizmoColor = Color.green;


    public void Awake()
    {

    }

    void OnDrawGizmos()
    {
        // Sets the color to red
        Gizmos.color = gizmoColor;
        //draws a small cube at the location of the gam object that the script is attached to
        Gizmos.DrawCube(transform.position, new Vector3(0.5f, 0.5f, 0.5f));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFollow : MonoBehaviour
{
    public float distance;

    public Transform cube;

    public LayerMask PlaceableLayer;


    // Update is called once per frame
    void Update()
    {
 //       Vector3 temp = Input.mousePosition;
 //       temp.z = distance; // Set this to be the distance you want the object to be placed in front of the camera.
 //       this.transform.position = Camera.main.ScreenToWorldPoint(temp);

        RaycastHit rayHit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity))
        {
            if (rayHit.collider.tag == "Connection")
            {
                this.transform.position = rayHit.point;
            }
        }

        else if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity))
        {

        }


        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity))
            {
                if (rayHit.collider.tag == "Connection")
                {
                    Instantiate(cube, rayHit.point, Quaternion.identity);
                    gameObject.SetActive(false);
                }
            }

            else if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity))
            {

            }
        }
    }


}


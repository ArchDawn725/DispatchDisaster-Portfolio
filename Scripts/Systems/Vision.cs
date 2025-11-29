using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour {
 [SerializeField] float ZoomAmount = 0; //With Positive and negative values
 [SerializeField] float MaxToClamp = 5;
 [SerializeField] float ROTSpeed = 50;

   [SerializeField] public int Speed = 1;

    public int Boundary = 1; // distance from edge scrolling starts
 public int speed = 5;
 private int theScreenWidth;
 private int theScreenHeight;

    public Vector3 camPos;
    public Vector3 startingPos;

    public int xMax;
    public int xMin;
    public int zMax;
    public int zMin;


         public void  Start()
    {
        theScreenWidth = Screen.width;
        theScreenHeight = Screen.height;

        camPos = startingPos;
        ZoomAmount = 0;
    }

    void Update()
    {
        Camera.main.transform.position = camPos;

        ZoomAmount += Input.GetAxis("Mouse ScrollWheel");
        ZoomAmount = Mathf.Clamp(ZoomAmount, -MaxToClamp, MaxToClamp);
        var translate = Mathf.Min(Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")), MaxToClamp - Mathf.Abs(ZoomAmount));
        gameObject.transform.Translate(0, 0, translate * ROTSpeed * Mathf.Sign(Input.GetAxis("Mouse ScrollWheel")));

//        float xAxisValue = (Input.GetAxis("Horizontal") * Speed);
//        float zAxisValue = Input.GetAxis("Vertical") * Speed;

        float xAxisValue = (Input.GetAxis("Horizontal") * Speed);
        float zAxisValue = Input.GetAxis("Vertical") * Speed;

        camPos = new Vector3(transform.position.x + xAxisValue, transform.position.y, transform.position.z + zAxisValue);


        if (Input.GetKey(KeyCode.BackQuote))
        {
            camPos = startingPos;
            ZoomAmount = 0;
        }


        if (Input.mousePosition.x > theScreenWidth - Boundary)
        {
            camPos.x += speed * Time.deltaTime; // move on +X axis
        }
        if (Input.mousePosition.x < 0 + Boundary)
        {
            camPos.x -= speed * Time.deltaTime; // move on -X axis
        }
        if (Input.mousePosition.y > theScreenHeight - Boundary)
        {
            camPos.z += speed * Time.deltaTime; // move on +Z axis
        }
        if (Input.mousePosition.y < 0 + Boundary)
        {
            camPos.z -= speed * Time.deltaTime; // move on -Z axis
        }

        if (camPos.x <= xMax)
        {
            // allowed to move
        }
        else
        {
            camPos = new Vector3((xMax - 1), transform.position.y, transform.position.z);
            transform.position = camPos;
        }
        if (camPos.x >= xMin)
        {
            // allowed to move
        }
        else
        {
            camPos = new Vector3((xMin + 1), transform.position.y, transform.position.z);
            transform.position = camPos;
        }

        if (camPos.z <= zMax)
        {
            // allowed to move
        }
        else
        {
            camPos = new Vector3(transform.position.x, transform.position.y, (zMax - 1));
            transform.position = camPos;
        }
        if (camPos.z >= zMin)
        {
            // allowed to move
        }
        else
        {
            camPos = new Vector3(transform.position.x, transform.position.y, (zMin + 1));
            transform.position = camPos;
        }

        /*        if (Input.GetButton("Fire3"))
                {
                    world.transform.Rotate(0, 1, 0, Space.World);
                }
        */
        if (Input.GetButton("Q"))
        {
//            transform.Rotate(0, 1, 0, Space.World);
        }
        if (Input.GetButton("E"))
        {

        }
    }

/*
    public void  OnGUI()
    {
        GUI.Box(new Rect((Screen.width / 2) - 140, 5, 280, 25), "Mouse Position = " + Input.mousePosition);
        GUI.Box(new Rect((Screen.width / 2) - 70, Screen.height - 30, 140, 25), "Mouse X = " + Input.mousePosition.x);
        GUI.Box(new Rect(5, (Screen.height / 2) - 12, 140, 25), "Mouse Y = " + Input.mousePosition.y);
    }
    */
}


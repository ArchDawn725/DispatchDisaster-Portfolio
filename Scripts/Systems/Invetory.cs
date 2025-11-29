using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Invetory : MonoBehaviour
{

    public bool[] isFull;
    public GameObject[] slots;

    public Button itemButtonPress;
    public GameObject ambulance;


    public bool isEMS;
    public bool isFire;
    public bool isPolice;

    public bool isHospital;
    public bool isFireStation;
    public bool isPoliceStation;


    public void Reset()
    {
        ambulance = null;
        isFire = false;
        isEMS = false;
        isPolice = false;
        isHospital = false;
        isFireStation = false;
        isPoliceStation = false;
    }

    public int avgFrameRate;
    public Text display_Text;

    public void Update()
    {
        float current = 0;
        current = (int)(1f / Time.unscaledDeltaTime);
        avgFrameRate = (int)current;
        display_Text.text = avgFrameRate.ToString() + " FPS";
    }
}

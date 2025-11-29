using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSize : MonoBehaviour
{
    public float hoverAmount;

    public Challenges challenges;
    public GameObject sizeCon;

    public void Big()
    {
        transform.localScale += Vector3.one * hoverAmount;
    }

    public void Small()
    {
        transform.localScale -= Vector3.one * hoverAmount;
    }

    public void Start()
    {
        sizeCon = GameObject.Find("SizeCon");
        challenges = sizeCon.GetComponent("Challenges") as Challenges;

        challenges.Loaded();
    }
}

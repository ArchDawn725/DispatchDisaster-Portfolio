using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("KillMe", 0.1f);
    }

    public void KillMe()
    {
        Destroy(this.gameObject);
    }
}

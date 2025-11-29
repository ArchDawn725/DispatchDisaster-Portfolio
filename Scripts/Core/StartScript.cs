using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{

    public int time;
    // Start is called before the first frame update
    public void Start()
    {
        StartCoroutine(coroutineA());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator coroutineA()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(1);
    }
}

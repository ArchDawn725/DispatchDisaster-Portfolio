using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicePulse : MonoBehaviour
{

    public float hoverAmount;

    public bool onScene;

    public float timer = 0.1f;

    public void Start()
    {
        StartCoroutine(coroutineA());
    }

    IEnumerator coroutineA()
    {
        yield return new WaitForSeconds(timer);
        if (onScene == false)
        {
            transform.localScale += Vector3.one * hoverAmount;
        }

        yield return new WaitForSeconds(timer);
        if (onScene == false)
        {
            transform.localScale += Vector3.one * hoverAmount;
        }

        yield return new WaitForSeconds(timer);
        if (onScene == false)
        {
            transform.localScale += Vector3.one * hoverAmount;
        }

        yield return new WaitForSeconds(timer);
        if (onScene == false)
        {
            transform.localScale += Vector3.one * hoverAmount;
        }

        yield return new WaitForSeconds(timer);
        if (onScene == false)
        {
            transform.localScale += Vector3.one * hoverAmount;
        }

        yield return new WaitForSeconds(timer);
        if (onScene == false)
        {
            transform.localScale += Vector3.one * hoverAmount;
        }

        yield return new WaitForSeconds(timer);
        if (onScene == false)
        {
            transform.localScale += Vector3.one * hoverAmount;
        }

        yield return new WaitForSeconds(timer);
        if (onScene == false)
        {
            transform.localScale += Vector3.one * hoverAmount;
        }

        yield return new WaitForSeconds(timer);
        if (onScene == false)
        {
            transform.localScale += Vector3.one * hoverAmount;
        }

        yield return new WaitForSeconds(timer);
        if (onScene == false)
        {
            transform.localScale += Vector3.one * hoverAmount;
            yield return StartCoroutine(coroutineB());
        }
    }

    IEnumerator coroutineB()
    {
        yield return new WaitForSeconds(timer);
        if (onScene == false)
        {
            transform.localScale -= Vector3.one * hoverAmount;
        }

        yield return new WaitForSeconds(timer);
        if (onScene == false)
        {
            transform.localScale -= Vector3.one * hoverAmount;
        }

        yield return new WaitForSeconds(timer);
        if (onScene == false)
        {
            transform.localScale -= Vector3.one * hoverAmount;
        }

        yield return new WaitForSeconds(timer);
        if (onScene == false)
        {
            transform.localScale -= Vector3.one * hoverAmount;
        }

        yield return new WaitForSeconds(timer);
        if (onScene == false)
        {
            transform.localScale -= Vector3.one * hoverAmount;
        }

        yield return new WaitForSeconds(timer);
        if (onScene == false)
        {
            transform.localScale -= Vector3.one * hoverAmount;
        }

        yield return new WaitForSeconds(timer);
        if (onScene == false)
        {
            transform.localScale -= Vector3.one * hoverAmount;
        }

        yield return new WaitForSeconds(timer);
        if (onScene == false)
        {
            transform.localScale -= Vector3.one * hoverAmount;
        }

        yield return new WaitForSeconds(timer);
        if (onScene == false)
        {
            transform.localScale -= Vector3.one * hoverAmount;
        }

        yield return new WaitForSeconds(timer);
        if (onScene == false)
        {
            transform.localScale -= Vector3.one * hoverAmount;
            StartCoroutine(coroutineA());
        }
    }

    public void Freeze()
    {
        onScene = true;
        transform.localScale = Vector3.one;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction : MonoBehaviour
{
    private bool isShown;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && isShown)
        {
            GetComponent<Animator>().Play("popOut");
        }
    }

    public void ShowHelp()
    {
        StartCoroutine("PopIn");
    }

    IEnumerator PopIn()
    {
        GetComponent<Animator>().Play("popIn");
        yield return new WaitForSeconds(1f); // prevent popOut from playing
        isShown = true;
    }
}

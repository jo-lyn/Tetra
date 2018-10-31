using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction : MonoBehaviour
{
    public GameObject helpButton;
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
            helpButton.SetActive(true);
            isShown = false;
        }
    }

    public void ShowHelp()
    {
        StartCoroutine("PopIn");
    }

    IEnumerator PopIn()
    {
        GetComponent<Animator>().Play("popIn");
        helpButton.SetActive(false);
        yield return new WaitForSeconds(1f); // prevent popOut from playing
        isShown = true;
    }
}

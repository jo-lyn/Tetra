using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopUpWindow : MonoBehaviour
{
    public GameObject button;
    private bool isShown;

    void Update()
    {
        if (Input.GetKeyDown("space") && isShown)
        {
            Debug.Log("kikik");
            GetComponent<Animator>().Play("popOut");
            button.SetActive(true);
            isShown = false;
        }
    }

    public void ShowWindow()
    {
        StartCoroutine("PopIn");
    }

    IEnumerator PopIn()
    {
        GetComponent<Animator>().Play("popIn");
        button.SetActive(false);
        yield return new WaitForSeconds(1f); // prevent popOut from playing
        isShown = true;
    }
}

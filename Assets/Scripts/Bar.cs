using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public Image bar;
    public GameObject glowingAlert;
    private float incrementAmount = 0.1f;
    private bool isFull;

    // Use this for initialization
    void Start()
    {
        bar.fillAmount = 0f;
        glowingAlert.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameController.instance.isGameOver)
        {
            if (Input.GetKeyDown("space") && bar.fillAmount == 1)
            {
                ResetFill();
            }

            if (bar.fillAmount == 1 && !isFull)
            {
                glowingAlert.SetActive(true);
                isFull = true;
            }
        }
    }

    public void UpdateFill(int numShapesCleared)
    {
        if (numShapesCleared != 0)
        {
            bar.fillAmount += incrementAmount;
        }
    }

    void ResetFill()
    {
        SoundController.instance.Play("activate");
        bar.fillAmount = 0;
        GameController.instance.ClearTopLayer();
        StartCoroutine(FadeOutAlert());
        isFull = false;
    }

    IEnumerator FadeOutAlert()
    {
        glowingAlert.GetComponent<Animator>().Play("glowFade");
        yield return new WaitForSeconds(1f);
        glowingAlert.SetActive(false);
    }
}

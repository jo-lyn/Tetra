using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public Image bar;
    private float incrementAmount = 0.1f;
    private Color normalColor;

    // Use this for initialization
    void Start()
    {
        bar.fillAmount = 0f;
        normalColor = bar.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && bar.fillAmount == 1)
        {
            ResetFill();
        }

        if (bar.fillAmount == 1) {
            bar.color = new Color(0.65f, 0.13f, 0.08f);
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
        bar.fillAmount = 0;
        bar.color = normalColor;
        GameController.instance.ClearTopLayer();
    }
}

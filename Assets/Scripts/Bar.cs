using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public Image bar;
    private float incrementAmount = 0.2f;

    // Use this for initialization
    void Start()
    {
        bar.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (bar.fillAmount == 1)
        {
            ResetFill();
        }
    }

    public void UpdateFill(int numShapesCleared)
    {
        if (numShapesCleared != 0 && (numShapesCleared % 4) == 0)
        {
            Debug.Log(numShapesCleared);
            bar.fillAmount += incrementAmount;
        }
    }

    void ResetFill()
    {
        bar.fillAmount = 0;
        GameController.instance.ClearTopLayer();
    }
}

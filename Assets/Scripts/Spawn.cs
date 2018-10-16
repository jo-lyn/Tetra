using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] shapes;
    public GameObject[] alerts;
    private SpriteRenderer[] alertSprites;

    // Use this for initialization
    void Start()
    {
        alertSprites = new SpriteRenderer[alerts.Length];
        for (int i = 0; i < alerts.Length; i++)
        {
            alertSprites[i] = alerts[i].GetComponent<SpriteRenderer>();
            Color color = alertSprites[i].color;
            color.a = 0f;
            alertSprites[i].color = color;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public SpriteRenderer getAlert(string shapeTag)
    {
        foreach (SpriteRenderer alertSprite in alertSprites)
        {
            if (alertSprite.CompareTag(shapeTag))
            {
                return alertSprite;
            }
        }
        return alertSprites[0];
    }

    public void SpawnShape(int shapeNum)
    {
        GameObject shape = Instantiate(shapes[shapeNum], transform.position, gameObject.transform.rotation);
        Debug.Log(shape.tag);
    }
}

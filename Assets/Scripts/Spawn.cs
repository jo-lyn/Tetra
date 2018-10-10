using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] shapes;
    public GameObject alert;
    private SpriteRenderer alertSprite;

    // Use this for initialization
    void Start()
    {
        alertSprite = alert.GetComponent<SpriteRenderer>();
        Color color = alertSprite.color;
        color.a = 0f;
        alertSprite.color = color;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public SpriteRenderer getAlert()
    {
        return alertSprite;
    }

    public void SpawnShape()
    {
        int randNum = Random.Range(0, 4);
        Instantiate(shapes[randNum], transform.position, gameObject.transform.rotation);
    }
}

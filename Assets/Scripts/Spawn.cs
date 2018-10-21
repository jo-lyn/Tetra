using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] shapes;
    public SpriteRenderer alert;

    // Use this for initialization
    void Start()
    {
        Color color = alert.color;
        color.a = 0f;
        alert.color = color;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public SpriteRenderer getAlert()
    {
        return alert;
    }

    public void SpawnShape()
    {
        int randNum = Random.Range(0, 4);
        Instantiate(shapes[randNum], transform.position, gameObject.transform.rotation);
    }
}
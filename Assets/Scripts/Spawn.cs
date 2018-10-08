using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] shapes;

    // Use this for initialization
    void Start ()
	{
    }
	
	// Update is called once per frame
	void Update ()
	{
    }

    public void SpawnShape()
    {
        int randNum = Random.Range(0, 4);
        Instantiate(shapes[randNum], transform.position, gameObject.transform.rotation);
    }
}

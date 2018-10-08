using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public Spawn[] spawns;
    public float spawnTime = 3.0f;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("SpawnCoroutine");
        //InvokeRepeating("CallSpawn", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime = 1.0f / (0.01f * Time.timeSinceLevelLoad + 0.3f) + 0.5f;
        
        if (spawnTime < 0.5f)
        {
            spawnTime = 0.05f;
        }
    }

    void Spawn()
    {
        int randNum = Random.Range(0, 4);
        spawns[randNum].SpawnShape();
    }

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(spawnTime);
        }
    }
}

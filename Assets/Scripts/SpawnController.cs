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

    void Spawn(int i)
    {
        spawns[i].SpawnShape();
    }

    IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(3.0f);
        while (true)
        {
            int randNum = Random.Range(0, 4);
            Color temp = spawns[randNum].getAlert().color;
            temp.a = 1f;
            spawns[randNum].getAlert().color = temp;
            yield return new WaitForSeconds(1f);
            temp.a = 0f;
            spawns[randNum].getAlert().color = temp;
            Spawn(randNum);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}

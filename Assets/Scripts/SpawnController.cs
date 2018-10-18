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
        /**
        spawnTime = 1.0f / (0.01f * Time.timeSinceLevelLoad + 0.3f) + 0.5f;

        if (spawnTime < 0.5f)
        {
            spawnTime = 0.05f;
        }*/
    }

    void ShowAlert(int spawnNum)
    {
        Color color = spawns[spawnNum].getAlert().color;
        color.a = 1f;
        spawns[spawnNum].getAlert().color = color;
    }

    void HideAlert(int spawnNum)
    {
        Color color = spawns[spawnNum].getAlert().color;
        color.a = 0f;
        spawns[spawnNum].getAlert().color = color;
    }

    IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(3.0f);
        while (true)
        {
            int spawnNum = Random.Range(0, 4);
            ShowAlert(spawnNum);
            yield return new WaitForSeconds(1f);
            HideAlert(spawnNum);
            spawns[spawnNum].SpawnShape();
            yield return new WaitForSeconds(1f / GameController.instance.GetSpawnRate());
        }
    }
}
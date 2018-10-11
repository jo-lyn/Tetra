using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;
    public CanvasGroup gameOver;
    public Stacker[] stacks;
    public GameObject spawnControllerObj;
    private SpawnController spawnController;
    private int numShapesCleared;
    private float baseFallSpeed, fallSpeed;
    private float baseSpawnRate, spawnRate;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        gameOver.alpha = 0;
        numShapesCleared = 0;
        baseFallSpeed = 10f;
        baseSpawnRate = 0.3f;
        spawnController = spawnControllerObj.GetComponent<SpawnController>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Stacker stack in stacks)
        {
            if (stack.GetStackCount() >= 8)
            {
                GameOver();
            }
        }
    }

    void GameOver()
    {
        gameOver.alpha = 1;
        Destroy(spawnControllerObj);
    }

    public float GetFallSpeed()
    {
        float multiplier = 1 + numShapesCleared / 13f;
        fallSpeed = numShapesCleared == 0 ? baseFallSpeed : baseFallSpeed * multiplier;
        return fallSpeed;
    }

    public float GetSpawnRate()
    {
        float speedBoost = numShapesCleared / 13f;
        spawnRate = numShapesCleared == 0 ? baseSpawnRate : baseSpawnRate + speedBoost;
        Debug.Log(spawnRate);
        return spawnRate;
    }

    public void Replay()
    {
        SceneManager.LoadScene("main");
    }

    public void AddNumShapesCleared()
    {
        numShapesCleared++;
    }
}

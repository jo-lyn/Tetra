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
    private int numShapesCleared, numShapesStacked;
    private float baseFallSpeed, fallSpeed;
    private float baseSpawnRate, spawnRate;
    private float negativeMultipler;

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
        negativeMultipler = 1f;
        spawnController = spawnControllerObj.GetComponent<SpawnController>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GetTotalStackCount());
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

    int GetTotalStackCount()
    {
        const int NUM_ROOT_SHAPES = 4;
        int count = 0;
        foreach (Stacker stack in stacks)
        {
            count += stack.GetStackCount();
        }
        return count - NUM_ROOT_SHAPES;
    }

    public float GetFallSpeed()
    {
        float multiplier = 1 + numShapesCleared / 13f;
        // float negativeMultipler = GetTotalStackCount()...;
        fallSpeed = numShapesCleared == 0
                    ? baseFallSpeed
                    : baseFallSpeed * multiplier * negativeMultipler;
        return fallSpeed;
    }

    public float GetSpawnRate()
    {
        float speedBoost = numShapesCleared / 13f;
        spawnRate = numShapesCleared == 0
                    ? baseSpawnRate
                    : baseSpawnRate + speedBoost;
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

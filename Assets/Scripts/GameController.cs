using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;
    public CanvasGroup gameOver;
    public Bar bar;
    public Stacker[] stacks;
    public GameObject spawnControllerObj;
    private SpawnController spawnController;
    private int numShapesCleared, numShapesStacked;
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
        //Debug.Log(GetTotalStackCount());
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

    public void ClearTopLayer()
    {
        foreach (Stacker stack in stacks)
        {
            stack.PopShape();
            numShapesCleared--;
        }
    }

    public float GetFallSpeed()
    {
        float positiveMultiplier = 1 + numShapesCleared * 0.08f;
        float negativeMultipler = 1 - GetTotalStackCount() * 0.02f;
        fallSpeed = numShapesCleared == 0
                    ? baseFallSpeed
                    : baseFallSpeed * positiveMultiplier * negativeMultipler;
        Debug.Log("shapes cleared: " + numShapesCleared + " stack count: " + GetTotalStackCount() + ", speed: " + fallSpeed);
        return fallSpeed;
    }

    public float GetSpawnRate()
    {
        float speedBoost = 1 + numShapesCleared * 0.08f;
        float negativeMultiplier = 1 - GetTotalStackCount() * 0.02f;
        spawnRate = numShapesCleared == 0
                    ? baseSpawnRate
                    : baseSpawnRate * speedBoost * negativeMultiplier;
        //Debug.Log("SPWAN RATE: " + spawnRate);
        return spawnRate;
    }

    public void Replay()
    {
        SceneManager.LoadScene("main");
    }

    public void AddNumShapesCleared()
    {
        numShapesCleared++;
        bar.UpdateFill(numShapesCleared);
    }
}

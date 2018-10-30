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
    private int numShapesCleared, numShapesStacked;
    private float baseFallSpeed, fallSpeed;
    private float baseSpawnRate, spawnRate;
    private bool isSurging;
    private float surgeDuration, surgeInterval;
    private float startTime, endTime;

    private int i;

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
        baseFallSpeed = 9.3f;
        baseSpawnRate = 0.3f;
        isSurging = false;
        surgeDuration = 6f;
        surgeInterval = 30f;
        startTime = Time.time;
        i = 0;

        InvokeRepeating("ActivateSurge", surgeInterval, surgeInterval);
        InvokeRepeating("DeactivateSurge", surgeInterval + surgeDuration, surgeInterval);
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
        if (i == 0)
        {
            endTime = Time.time - startTime;
            Debug.Log("Time taken: " + endTime);
            Debug.Log("Shapes cleared: " + numShapesCleared);
            Debug.Log("Fall speed: " + fallSpeed);
        }
        i++;
    }

    void ActivateSurge()
    {
         isSurging = true;
    }

    void DeactivateSurge()
    {
        isSurging = false;
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
            numShapesCleared--; // do not add to cleared count
        }
    }

    public float GetFallSpeed()
    {
        float positiveMultiplier = 1 + numShapesCleared * (1.48f / (80 + numShapesCleared) + 0.2f / 150);
        float negativeMultipler = 1 - Mathf.Pow(GetTotalStackCount(), 1.385f) / 100;
        fallSpeed = numShapesCleared == 0
                    ? baseFallSpeed
                    : baseFallSpeed * positiveMultiplier * negativeMultipler;
        //Debug.Log("shapes cleared: " + numShapesCleared + " stack count: " + GetTotalStackCount() + ", speed: " + fallSpeed);
        return fallSpeed;
    }

    public float GetSpawnRate()
    {
        if (isSurging)
        {
            float oldSpawnRate = spawnRate;
            spawnRate = 11f;
            if (spawnRate < oldSpawnRate) {
                spawnRate = oldSpawnRate * 1.5f;
            }
        }
        else
        {
            float speedBoost = 1 + numShapesCleared * 0.08f;
            float negativeMultiplier = 1 - GetTotalStackCount() * 0.02f;
            spawnRate = numShapesCleared == 0
                        ? baseSpawnRate
                        : baseSpawnRate * speedBoost * negativeMultiplier;
        }

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

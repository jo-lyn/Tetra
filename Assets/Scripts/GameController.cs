using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;
    public GameObject gameOver;
    public Bar bar;
    public Stacker[] stacks;
    public GameObject spawnControllerObj;

    public Animator surgeAnim;
    public bool isGameOver;

    private int numShapesCleared, numShapesStacked;
    private float baseFallSpeed, fallSpeed;
    private float baseSpawnRate, spawnRate;
    private bool isSurging;
    private float surgeDuration, surgeInterval;
    private float startTime, endTime;

    public Text timeTakenText;
    public Text fallSpeedText;
    public Text shapesClearedText;


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
        Cursor.visible = false;
        gameOver.SetActive(false);

        numShapesCleared = 0;
        baseFallSpeed = 9.3f;
        baseSpawnRate = 0.3f;
        isSurging = false;
        surgeDuration = 6f;
        surgeInterval = 30f;

        startTime = Time.time;
        isGameOver = false;

        timeTakenText.text = "";
        fallSpeedText.text = "";
        shapesClearedText.text = "";

        InvokeRepeating("ActivateSurge", surgeInterval, surgeInterval);
        InvokeRepeating("DeactivateSurge", surgeInterval + surgeDuration, surgeInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            foreach (Stacker stack in stacks)
            {
                if (stack.GetStackCount() >= 8)
                {
                    isGameOver = true;
                    StartCoroutine(GameOver());
                }
            }
        }
    }

    void ActivateSurge()
    {
        StartCoroutine("StartSurgeCoroutine");
    }

    void DeactivateSurge()
    {
        StartCoroutine("EndSurgeCoroutine");
    }

    IEnumerator StartSurgeCoroutine()
    {
        surgeAnim.Play("surgeIn");
        isSurging = true;
        yield return null;
    }

    IEnumerator EndSurgeCoroutine()
    {
        isSurging = false;
        yield return new WaitForSeconds(1f);
        surgeAnim.Play("surgeOut");
        //yield return null;
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
            if (spawnRate < oldSpawnRate)
            {
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

    public void LoadMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void AddNumShapesCleared()
    {
        numShapesCleared++;
        bar.UpdateFill(numShapesCleared);
    }

    IEnumerator GameOver()
    {
        Destroy(spawnControllerObj);
        Debug.Log("Time taken: " + endTime);
        Debug.Log("Shapes cleared: " + numShapesCleared);
        Debug.Log("Fall speed: " + fallSpeed);

        endTime = Time.time - startTime;
        timeTakenText.text = "Time taken: " + endTime;
        fallSpeedText.text = "Shapes cleared: " + numShapesCleared;
        shapesClearedText.text = "Fall speed: " + fallSpeed;

        for (int i = 0; i < 7; i++)
        {
            ClearTopLayer();
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(1f);

        gameOver.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public CanvasGroup gameOver;
    public Stacker[] stacks;
    public GameObject spawners;
    private SpawnController spawnController;
    private int numShapesCleared;
    private float baseFallSpeed, speedMultiplier, fallSpeed;

    // Use this for initialization
    void Start()
    {
        gameOver.alpha = 0;
        numShapesCleared = 0;
        baseFallSpeed = 10f;
        speedMultiplier = 1f;
        spawnController = spawners.GetComponent<SpawnController>();
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

        speedMultiplier = 1 + numShapesCleared / 10f;
        fallSpeed = numShapesCleared == 0 ? baseFallSpeed : baseFallSpeed * speedMultiplier;

        spawnController.SetFallSpeed(fallSpeed);
    }

    void GameOver()
    {
        gameOver.alpha = 1;
        Destroy(spawners);
    }

    public void Replay()
    {
        SceneManager.LoadScene("main");
    }

    public void AddNumShapesCleared()
    {
        numShapesCleared++;
        //Debug.Log(numShapesCleared);
    }
}

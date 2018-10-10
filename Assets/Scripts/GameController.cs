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
    private int numShapesCleared;
    private float fallSpeed;

    // Use this for initialization
    void Start()
    {
        gameOver.alpha = 0;
        numShapesCleared = 0;
        fallSpeed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        spawners.GetComponent<SpawnController>().SetFallSpeed(fallSpeed);
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
        Destroy(spawners);
    }

    public void Replay()
    {
        SceneManager.LoadScene("main");
    }
}

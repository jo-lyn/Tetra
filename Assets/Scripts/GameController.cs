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
    private int numCleared;

    // Use this for initialization
    void Start()
    {
        gameOver.alpha = 0;
        numCleared = 0;
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
        Destroy(spawners);
    }

    public void Replay()
    {
        SceneManager.LoadScene("main");
    }

    public void addClearedCount()
    {

    }
}

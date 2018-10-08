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

    // Use this for initialization
    void Start()
    {
        gameOver.alpha = 0;
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
}

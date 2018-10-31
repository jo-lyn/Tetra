using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator menuAnim;
    public Animator helpAnim;

    void Start()
    {
    }

    void Update()
    {

    }

    public void PlayGame()
    {
        Debug.Log("play");
        StartCoroutine(LoadGame());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadGame()
    {
        Debug.Log("setting trig");
        menuAnim.SetTrigger("menuOut");
        Debug.Log("anim end");
        yield return new WaitForSeconds(1f);

        AsyncOperation operation = SceneManager.LoadSceneAsync("main");
        while (!operation.isDone)
        {
            Debug.Log(operation.progress);

            yield return null;
        }
    }

}

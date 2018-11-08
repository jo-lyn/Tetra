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
        StartCoroutine(LoadGame());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadGame()
    {
        menuAnim.SetTrigger("menuOut");
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("main");
    }

}

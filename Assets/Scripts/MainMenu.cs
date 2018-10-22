using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public EventSystem eventSystem;
    public GameObject selectedObject;
    public Animator animator;

    void Update()
    {
        if (Input.GetAxisRaw("Vertical") != 0)
        {
           // eventSystem.SetSelectedGameObject(selectedObject);
        }
        //Debug.Log(eventSystem.currentSelectedGameObject);
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
        animator.SetTrigger("menuOut");
        Debug.Log("anim end");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("main");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public EventSystem eventSystem;
    public GameObject selectedObject;

    void Update()
    {
        /* 
        if (Input.GetAxisRaw("Vertical") != 0 && !isSelected)
        {
            eventSystem.SetSelectedGameObject(selectedObject);
            isSelected = true;
            Debug.Log(selectedObject);
        }*/
        //Debug.Log(eventSystem.currentSelectedGameObject);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

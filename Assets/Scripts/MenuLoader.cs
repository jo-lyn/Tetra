using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoader : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(LoadMenu());
    }
    IEnumerator LoadMenu()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync ( "menu" );
        op.allowSceneActivation = false;
        yield return new WaitForSeconds(2.3f);
        op.allowSceneActivation = true;
        //SceneManager.LoadScene("menu");
    }
}

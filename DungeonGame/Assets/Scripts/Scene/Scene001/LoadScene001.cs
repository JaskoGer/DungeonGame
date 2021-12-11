using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * @author Kacper Purtak
 * version 1.0
 * 31.10.2021
 * Description: Script to set correct scene value after loading the scene
 */

public class LoadScene001 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
            StartCoroutine(SetScene());
    }

    /*
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            GlobalScene.currentScene = 5;
            SceneManager.LoadScene(GlobalScene.currentScene);
        }
    }*/

    IEnumerator SetScene()
    {
        yield return new WaitForSeconds(1f);
        GlobalScene.currentScene = 2;
    }
}
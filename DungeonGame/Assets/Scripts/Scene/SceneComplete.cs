using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * @author Kacper Purtak
 * version 1.0
 * 30.10.2021
 * Description: Script to load the next scene after completing one
 * Bearbeitet von Tobias
 */

public class SceneComplete : MonoBehaviour
{
    private bool loaded = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!loaded)
            StartCoroutine(CompletedScene());
    }

    IEnumerator CompletedScene()
    {
        loaded = true;
        GlobalScene.currentScene++;
        ObjectManager.instance.fadeOutScene.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(GlobalScene.currentScene);
    }
}

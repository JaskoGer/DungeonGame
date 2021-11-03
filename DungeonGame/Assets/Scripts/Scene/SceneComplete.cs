using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * @author Kacper Purtak
 * version 1.0
 * 30.10.2021
 * Description: Script to load the next scene after completing one
 */

public class SceneComplete : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject fadeOutScene;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(CompletedScene());
    }

    IEnumerator CompletedScene()
    {
        GlobalScene.currentScene++;
        fadeOutScene.SetActive(true);
        yield return new WaitForSeconds(2f);
		Destroy(thePlayer);
        SceneManager.LoadScene(GlobalScene.currentScene);
    }
}

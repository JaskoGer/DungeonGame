using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * @author Kacper Purtak
 * version 1.0
 * 30.10.2021
 * Description: Script to load the next scene after completing one
 * Bearbeitet von Tobias Haubold
 */

public class SceneComplete : MonoBehaviour
{
    private GameObject thePlayer;
    public GameObject fadeOutScene;
    private bool loaded = false;

    void Start()
    {
        thePlayer = ObjectManager.instance.player.transform.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!loaded)
            StartCoroutine(CompletedScene());
    }

    IEnumerator CompletedScene()
    {
        loaded = true;
        GlobalScene.currentScene++;
        fadeOutScene.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(GlobalScene.currentScene);
    }
}

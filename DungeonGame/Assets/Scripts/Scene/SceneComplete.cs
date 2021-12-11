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
    private GameObject thePlayer;
    private GameObject gameManager;
    private PlayerManager positionManager;
    private GameObject fadeOutScene;
    private bool loaded = false;

    void Start()
    {
        thePlayer = ObjectManager.instance.player.gameObject;
        gameManager = GameObject.Find("GameManager");
        positionManager = gameManager.GetComponent<PlayerManager>();
        thePlayer.transform.position = new Vector3(positionManager.startPointx, positionManager.startPointy, positionManager.startPointz);
        fadeOutScene = ObjectManager.instance.fadeOutScene.gameObject;
        fadeOutScene.SetActive(false);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * @author Kacper Purtak
 * version 1.0
 * 01.11.2021
 * Bearbeitet von Tobias
 * Description: Script to load the next scene after completing the fist scene and picking up the starter-wearpon
 */

public class FirstSceneComplete : MonoBehaviour
{
    public static bool isStarterWeaponPickedUp = false;
    private GameObject thePlayer;
    private GameObject fadeOutScene;
    private GameObject gameManager;
    private PlayerManager positionManager;

    private void Start()
    {
        thePlayer = ObjectManager.instance.player.gameObject;
        gameManager = ObjectManager.instance.GetGameManager();
        positionManager = gameManager.GetComponent<PlayerManager>();
        thePlayer.transform.position = new Vector3(positionManager.startPointx, positionManager.startPointy, positionManager.startPointz);
        fadeOutScene = ObjectManager.instance.fadeOutScene.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isStarterWeaponPickedUp == true)
        {
            StartCoroutine(CompletedScene());
        }
        else
        {
            ObjectManager.instance.canvasMessenger.ErrorMessage("Hebe zuerst die Heugabel an den Heuballen auf!");
        }
    }

    IEnumerator CompletedScene()
    {
        GlobalScene.currentScene = 3;
        fadeOutScene.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(GlobalScene.currentScene);
    }
}
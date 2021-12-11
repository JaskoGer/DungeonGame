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
    private Text errorMessage;

    private void Start()
    {
        thePlayer = ObjectManager.instance.player.gameObject;
        gameManager = GameObject.Find("GameManager");
        positionManager = gameManager.GetComponent<PlayerManager>();
        thePlayer.transform.position = new Vector3(positionManager.startPointx, positionManager.startPointy, positionManager.startPointz);
        fadeOutScene = ObjectManager.instance.fadeOutScene.gameObject;
        errorMessage = ObjectManager.instance.errorTextField.GetComponent<Text>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isStarterWeaponPickedUp == true)
        {
            StartCoroutine(CompletedScene());
        }
        else
        {
            StartCoroutine(PickUpStarterWeaponErrorMessage());
        }
    }

    IEnumerator CompletedScene()
    {
        GlobalScene.currentScene = 3;
        fadeOutScene.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(GlobalScene.currentScene);
    }

    IEnumerator PickUpStarterWeaponErrorMessage()
    {
        errorMessage.text = "Hebe zuerst die Waffe an den Heuballen auf, bevor du den Dungeon betrittst!";
        errorMessage.enabled = true;
        yield return new WaitForSeconds(4f);
        errorMessage.enabled = false;
    }
}
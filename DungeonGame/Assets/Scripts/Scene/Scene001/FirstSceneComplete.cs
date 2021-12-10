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
    private Text errorMessage;

    private void Start()
    {
        thePlayer = ObjectManager.instance.player.gameObject;
        fadeOutScene = ObjectManager.instance.player.transform.GetChild(3).GetChild(0).GetChild(2).gameObject;
        errorMessage = ObjectManager.instance.player.transform.GetChild(3).GetChild(0).GetChild(4).GetComponent<Text>();
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
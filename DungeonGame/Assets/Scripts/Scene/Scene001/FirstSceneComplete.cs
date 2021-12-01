using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * @author Kacper Purtak
 * version 1.0
 * 01.11.2021
 * Description: Script to load the next scene after completing the fist scene and picking up the starter-wearpon
 */

public class FirstSceneComplete : MonoBehaviour
{
    public static bool isStarterWeaponPickedUp = false;
    public GameObject thePlayer;
    public GameObject fadeOutScene;
    public Text errorMessage;

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
        GlobalScene.currentScene++;
        fadeOutScene.SetActive(true);
        thePlayer.GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(2f);
        Destroy(thePlayer);
        SceneManager.LoadScene(GlobalScene.currentScene);
    }

    IEnumerator PickUpStarterWeaponErrorMessage()
    {
        errorMessage.GetComponent<Text>().text = "Hebe zuerst die Waffe an den Heuballen auf, bevor du den Dungeon betrittst!";
        errorMessage.enabled = true;
        yield return new WaitForSeconds(4f);
        errorMessage.enabled = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Tobias
 * Description: Script to set correct scene value after loading the scene
 */

public class LoadScene005 : MonoBehaviour
{
    private GameObject fadeOut;
    private GameObject thePlayer;
    private GameObject gameManager;
    private PlayerManager positionManager;

    void Start()
    {
        thePlayer = ObjectManager.instance.player.gameObject;
        gameManager = GameObject.Find("GameManager");
        positionManager = gameManager.GetComponent<PlayerManager>();
        thePlayer.transform.position = new Vector3(positionManager.startPointx, positionManager.startPointy, positionManager.startPointz);
        ObjectManager.instance.camRotator.transform.rotation = positionManager.startRotation;
        ObjectManager.instance.playerCharacter.transform.rotation = positionManager.startRotation;
        fadeOut = ObjectManager.instance.fadeOutScene.gameObject;
        fadeOut.SetActive(false);
        StartCoroutine(SetScene());
    }

    IEnumerator SetScene()
    {
        yield return new WaitForSeconds(1f);
        GlobalScene.currentScene = 6;
    }
}

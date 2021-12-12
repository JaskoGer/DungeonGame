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
        StartCoroutine(SetScene());
    }

    IEnumerator SetScene()
    {
        yield return new WaitForSeconds(1f);
        GlobalScene.currentScene = 6;
    }
}

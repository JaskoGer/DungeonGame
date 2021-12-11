using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Kacper Purtak
 * version 1.0
 * 31.10.2021
 * Bearbeitet von Tobias
 * Description: Script to set correct scene value after loading the scene
 */

public class LoadScene004 : MonoBehaviour
{
    private GameObject fadeOut;
    // Start is called before the first frame update
    void Start()
    {
        fadeOut = ObjectManager.instance.fadeOutScene.gameObject;
        fadeOut.SetActive(false);
        StartCoroutine(SetScene());
    }

    IEnumerator SetScene()
    {
        yield return new WaitForSeconds(1f);
        GlobalScene.currentScene = 2;
    }
}
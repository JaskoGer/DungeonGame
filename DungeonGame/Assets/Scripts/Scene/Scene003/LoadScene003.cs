using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Tobias Haubold
 * version 1.0
 * 09.12.2021
 * Description: Script to set correct scene value after loading the scene
 */

public class LoadScene003 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetScene());
    }

    IEnumerator SetScene()
    {
        yield return new WaitForSeconds(1f);
        GlobalScene.currentScene = 4;
    }
}

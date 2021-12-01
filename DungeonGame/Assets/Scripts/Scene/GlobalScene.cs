using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * @author Kacper Purtak
 * version 1.0
 * 30.10.2021
 * Description: Script to safe the players scene
 */

public class GlobalScene : MonoBehaviour
{
    private const string SceneKey = "Scene";
    public static int currentScene = 2;
    [SerializeField] private int scene;

    private void Start()
    {
        currentScene = PlayerPrefs.GetInt("Scene", 2);
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt(SceneKey, currentScene);
    }

    //monitor the curren scene
    private void Update()
    {
        scene = currentScene;
    }
}

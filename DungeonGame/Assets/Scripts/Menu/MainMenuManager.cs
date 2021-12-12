using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * @author Kacper Purtak
 * version 1.0
 * 10.12.2021
 * Description: enthaelt Funktionen für die Buttons im Main Menu
 */

public class MainMenuManager : MonoBehaviour
{
    PlayerStatsSingleton playerStats;

    private void Start()
    {
        playerStats = PlayerStatsSingleton.instance;
    }

    //Startet ein neues Spiel
    public void StartNewGame()
    {
        SceneManager.LoadScene(GlobalScene.currentScene);
    }

    //Laedt den alten Spielstand
    public void LoadGame()
    {
        playerStats.LoadPlayer();
    }

    //Schliesst das Spiel
    public void ExitGame()
    {
        Application.Quit();
    }
}

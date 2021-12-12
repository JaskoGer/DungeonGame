using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*@Author Laurin   
* Script für das Escape Menü
*/

public class ESCMenuManager : MonoBehaviour
{
    public GameObject Menu;
    PlayerStatsSingleton playerStats;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = PlayerStatsSingleton.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Menu.gameObject.SetActive(MenuChecker());
        }
    }

    //Checkt ob das Menü Aktiv ist oder nicht und ändert demnach den Modus
     private bool MenuChecker()
    {

        if(Menu.gameObject.activeSelf == true)
        {
            return false;
        }
        else if(Menu.gameObject.activeSelf == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /*
     * Bearbeitet von Kacper
     * Speichert den Spielstand des Spiels
     */
    public void SaveGame()
    {
        playerStats.SavePlayer();
    }

    /*
     * Bearbeitet von Kacper
     * Kehrt ins Main Menu zurück
     */
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(1);
        Menu.SetActive(false);
    }
}

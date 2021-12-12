using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevController : MonoBehaviour
{
public GameObject[] HUD;
private GameObject DevMenu;
private GameObject SceneMenu;
private GameObject PortMenu;
/*
 *@Author Laurin
 *Script für die Kontrolle des Developermenüs
 */

    // Start is called before the first frame update
    void Start()
    {
      HUD = GameObject.FindGameObjectsWithTag("DevTool");

      DevMenu = GameObject.Find("DevMenu");
      SceneMenu = GameObject.Find("SceneMenu");
      PortMenu = GameObject.Find("PortMenu");

      DevMenu.gameObject.SetActive(false);
      SceneMenu.gameObject.SetActive(false);
      PortMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

      if(Input.GetKeyDown(KeyCode.Z))
      {
          
        DevMenu.gameObject.SetActive(MenuChecker());
        
      }

    }


    //Checkt ob das Menü Aktiv ist oder nicht und ändert demnach den Modus
     private bool MenuChecker()
    {

        if(DevMenu.gameObject.activeSelf == true ^ SceneMenu.gameObject.activeSelf == true ^ PortMenu.gameObject.activeSelf == true )
        {
            SceneMenu.gameObject.SetActive(false);
            PortMenu.gameObject.SetActive(false);
            return false;
        }
        else if(DevMenu.gameObject.activeSelf == false && SceneMenu.gameObject.activeSelf == false && PortMenu.gameObject.activeSelf == false )
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    //Methode welche den Spieler Teleportiert
    public void TeleportPlayer(float xCord, float yCord, float zCord)
    {
        ObjectManager.instance.player.transform.position = new Vector3(xCord, yCord, zCord);
    }


    //Gibt dem Spieler Maximales Leben
    public void MaxHealthButton()
    {
        float temp = EntityStatsController.instance.ResetHealth(PlayerStatsSingleton.instance.GetPlayerHealth(), PlayerStatsSingleton.instance.GetPlayerMaxHealth()); 
        PlayerStatsSingleton.instance.SetPlayerHealth(temp);
    }
 

    //Tötet den Spieler
    public void SuicideButton()
    {
        PlayerStatsSingleton.instance.SetPlayerHealth(0);
    }


    //Gibt dem SPieler ein LevelUp
    public void LevelUpButton()
    {
        PlayerStatsSingleton.instance.LevelUp();
    }

    //Button für das wechseln der Menü Ebenen
    public void TeleportButton()
    {
        DevMenu.gameObject.SetActive(false);
        SceneMenu.gameObject.SetActive(true);
    }
    
    //Button für das wechseln der Menü Ebenen
    public void Scene3Button()
    {
        SceneMenu.gameObject.SetActive(false);
        PortMenu.gameObject.SetActive(true);
    }

    //Teleportiert den Spieler auf die angegebene Position
    public void Port1Button()
    {
        TeleportPlayer(6, 6, 56);
    }

    //Teleportiert den Spieler auf die angegebene Position
    public void Port2Button()
    {
        TeleportPlayer(-19, 12, 114);
    }

    //Teleportiert den Spieler auf die angegebene Position
    public void Port3Button()
    {
        TeleportPlayer(-50, 16, 227);
    }

    //Teleportiert den Spieler auf die angegebene Position
    public void Port4Button()
    {
        TeleportPlayer(-10, 20, 311);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*@Author Laurin   
* Script für das Escape Menü
*/

public class ESCMenuManager : MonoBehaviour
{
public GameObject Menu;

    // Start is called before the first frame update
    void Start()
    {
        
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

    public void SaveGame()
    {
        //Jonas sein Part (Aufrufen deiner Methode und so)
    }

    //Laedt den alten Spielstand
    public void LoadGame()
    {
        //Jonas sein Part (Aufrufen deiner Methode und so)
    }

    //Schliesst das Spiel
    public void ExitGame()
    {
        Application.Quit();
    }
}

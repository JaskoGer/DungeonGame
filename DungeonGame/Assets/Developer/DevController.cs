using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevController : MonoBehaviour
{
public GameObject[] HUD;
private GameObject DevMenu;

    // Start is called before the first frame update
    void Start()
    {
      HUD = GameObject.FindGameObjectsWithTag("DevTool");

      DevMenu = GameObject.Find("DevMenu");

      DevMenu.gameObject.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {

      if(Input.GetKeyDown(KeyCode.Z))
      {
        DevMenu.gameObject.SetActive(MenuChecker());
      }

    }

     public bool MenuChecker()
    {
        if(DevMenu.gameObject.activeSelf == true)
        {
            return false;
        }
        else if(DevMenu.gameObject.activeSelf == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void MaxHealthButton()
    {
        float temp = EntityStatsController.instance.ResetHealth(PlayerStatsSingleton.instance.GetPlayerHealth(), PlayerStatsSingleton.instance.GetPlayerMaxHealth()); 
        PlayerStatsSingleton.instance.SetPlayerHealth(temp);
    }
 
    public void SuicideButton()
    {
        PlayerStatsSingleton.instance.SetPlayerHealth(0);
    }
    
}

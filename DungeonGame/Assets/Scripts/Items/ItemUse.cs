using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUse : MonoBehaviour
{
    #region Singleton

    public static ItemUse instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Mehr als eine Instanz von ItemUse gefunden!");
        }
        instance = this;
    }

    #endregion Singleton

    public void UseItem(NewItem item)
    {
        switch (item.name)
        {
            default:
            case "healthPotion":
                HealthPotion.UseItem();
                break;
            case "helmet":
                print("yo");
                break;

        }
    }

    public class HealthPotion : MonoBehaviour
    {
        public static void UseItem()
        {
            PlayerStatsSingleton.instance.AddPlayerHealth(50);
        }
    }

}

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

    public void UseItem(string name)
    {
        switch (name)
        {
            default:
            case "Health Potion":
                HealthPotion.UseItem();
                break;
            case "Meat":
                HealthPotion.UseItem();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @Author Jasko
 * stellt die Logik der useable Items
 */
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

    /**
     * @Author Jasko
     * guckt welches Item geused wurde und ruft dessen Klasse auf
     */
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
        /**
         * @Author Jasko
         * ruft die AddPlayerHealth Methode auf und gibt einen Betrag mit
         */
        public static void UseItem()
        {
            PlayerStatsSingleton.instance.AddPlayerHealth(50);
        }
    }

}

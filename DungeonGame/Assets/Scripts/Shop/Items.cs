using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @author Manuel
 * Erstellung der Klasse Items und Deklarierung der Variablen
 */

public class Items : MonoBehaviour
{

    // ItemType verschiedener Items 
    public enum ItemType
    {
        healthPotion,
        meat,
        helmet,
        chestplate,
        crossbow
    }

    /*[SerializeField]
    private Sprite[] itemIcon;*/
    
    public static int GetCost(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.healthPotion: return 50;
            case ItemType.meat: return 100;
            case ItemType.helmet: return 300;
            case ItemType.chestplate: return 150;
            case ItemType.crossbow: return 200;
        }
    }

    /*public static Sprite GetSprite(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.healthPotion: return itemIcon[4];
            case ItemType.meat: return itemIcon[5];
            case ItemType.helmet: return itemIcon[2];
            case ItemType.chestplate: return itemIcon[3];
            case ItemType.crossbow: return itemIcon[1];
        }

    }*/
}
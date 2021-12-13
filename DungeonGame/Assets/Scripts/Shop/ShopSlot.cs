using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * @author Manuel Schulz
 * Description Shop Slots
 * bearbeitet von Tobias
 */
public class ShopSlot : MonoBehaviour
{
    public Image icon;
    public Button buyButton;
    public GameObject itemText;
    public GameObject priceText;
    NewInventory inventory;
    NewItem item;
    private void Start()
    {
        inventory = NewInventory.instance;
    }

    public void AddItemToShop(NewItem shopItem)
    {
        item = shopItem;
        icon.sprite = item.icon;
        itemText.GetComponent<Text>().text = item.name;
        priceText.GetComponent<Text>().text = "" + item.preis;
        icon.enabled = true;
        buyButton.interactable = true;
    }

    public void BuyItem()
    {
        if (buyButton.interactable && PlayerStatsSingleton.instance.GetPlayerMoneten() >= item.preis)        {

            PlayerStatsSingleton.instance.AddPlayerMoneten(-item.preis);
            NewInventory.instance.Add(item);
        }
        else
        {
            ObjectManager.instance.canvasMessenger.ErrorMessage("Du hast nicht genug Moneten!");
        }
    }
}

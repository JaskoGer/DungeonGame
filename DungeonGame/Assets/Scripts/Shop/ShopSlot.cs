using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        icon.enabled = true;
        buyButton.interactable = true;
    }

    public void BuyItem()
    {
        if (buyButton.interactable && PlayerStatsSingleton.instance.GetPlayerMoneten() >= item.preis)        {

            PlayerStatsSingleton.instance.AddPlayerMoneten(-item.preis);
            Debug.Log("Das Item" + item.name + "wurde gekauft");
            //inventory.Add(item);
            NewInventory.instance.Add(item);
        }
        else
        {
            ObjectManager.instance.ErrorMessage("Du hast nicht genug Moneten!");
        }
    }
}

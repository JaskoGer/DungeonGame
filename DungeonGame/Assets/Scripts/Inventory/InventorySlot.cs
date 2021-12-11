using UnityEngine;
using UnityEngine.UI;

/*
 * @author Kacper Purtak
 * version 1.0
 * 01.12.2021
 * Description: Vorlage für ein Item im Inventar-Slot
 */

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;

    NewItem item;   //momentanes Item im Slot

    //fuegt das Item in einen Slot 
    public void AddItem(NewItem newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    //leert den Slot
    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    //wird ausgefuehrt, wenn der RemoveButton im Inventar gedrueckt wird
    public void OnRemoveButton()
    {
        Debug.Log("Moin Meister");
        NewInventory.instance.Remove(item);
        ClearSlot();
    }

    //wird ausgefuehrt, wenn auf ein Item im Invantar gedrueckt wird
    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
        }
    }
}

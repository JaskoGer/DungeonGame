using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;

    NewItem item;

    public void AddItem(NewItem newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Debug.Log("Moin Meister");
        NewInventory.instance.Remove(item);
        ClearSlot();
    }

    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
        }
    }
}

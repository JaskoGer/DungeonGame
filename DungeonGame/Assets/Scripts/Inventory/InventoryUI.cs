using UnityEngine;

/*
 * @author Kacper Purtak
 * version 1.0
 * 01.12.2021
 * Description: verwaltet das UI des Inventars
 */

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;    //das Elternobjekt aller Items
    public GameObject inventoryUI;   //das gesammte UI
    NewInventory inventory;          //das momentane Inventar 
    InventorySlot[] slots;           //das momentane Slot-Array   

    // Start is called before the first frame update
    void Start()
    {
        inventory = NewInventory.instance;
        inventory.onItemChangedCallback += UpdateUI;   //delegate in NewInventory abonniert die Methode UpdateUI

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // prueft, ob das Inventar geoeffnet/geschlossen wird
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    /*
     * aktualisiert das Inventar wenn:
     * -Items hinzugefuegt werden
     * -Inventar-Slots geleert werden
     * wird mithilfe eines Delegates in NewInventory aufgerufen
     */
    void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}

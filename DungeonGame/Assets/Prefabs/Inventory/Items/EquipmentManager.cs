using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Kacper Purtak
 * version 1.0
 * 03.12.2021
 * Description: Controller zum ausruesten von Ausruestung
 */

public class EquipmentManager : MonoBehaviour
{
    #region Singleton

    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    Equipment[] currentEquipment;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;
    public GameObject[] itemObj;   //Array aus Gegenstaenden, die der Spieler ausruesten kann

    NewInventory inventory;

    private void Start()
    {
        inventory = NewInventory.instance;

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
    }

    //ruestet ein neues Item aus
    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipmentSlot;   //Slot-Platz, in den der Gegenstand passt
        Debug.Log(slotIndex);
        Equipment oldItem = null;

        //der zuletzt verwendete Gegenstand wird zurueck in das Inventar gelegt
        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            
			inventory.Add(oldItem);
			Debug.Log("Altes Item wurde geadded");
        }

        //ein Gegenstand wurde ausgeruestet, wodurch ein Delegate-Rueckruf ausgeloest wird
        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
			Debug.Log("onEquipmentChanged wurde ausgeführt");
        }
		
        currentEquipment[slotIndex] = newItem;
		itemObj[oldItem.itemID].SetActive(false);
        itemObj[newItem.itemID].SetActive(true);
    }

    //zieht die verwendete Item aus
    public void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }
    }

    //zieht alle verwendeten Items aus
    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
            itemObj[i].SetActive(false);
        }
    }

    //prueft, ob alle vewendeten Ausruestungen ausgezogen werden
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }
    }
}

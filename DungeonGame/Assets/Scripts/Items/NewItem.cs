using UnityEngine;

/*
 * @author Kacper Purtak
 * version 1.0
 * 30.11.2021
 * Description: Vorlage für Item-Objekte mit Methoden
 */

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class NewItem : ScriptableObject
{
    new public string name = "New Item";    //Name des Items
    public Sprite icon = null;              //Item Symbol
    public bool isDefaultItem = false;
	public int itemID;
    public int preis;

    //wird ausgefuehrt, wenn das Item im Inventar gedrueckt wird
    public virtual void Use()
    {
        ItemUse.instance.UseItem(name);
        RemoveFromInventory();
    }

    //wird verwendet, um ein Item aus dem Inventar zu entfernen
    public void RemoveFromInventory()
    {
        NewInventory.instance.Remove(this);
    }
}


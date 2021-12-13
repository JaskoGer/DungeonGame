using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Kacper Purtak
 * version 1.0
 * 03.12.2021
 * Description: Vorlage für Ausruestungsobjekte, welche man dem Spieler ausruesten kann 
 * Bearbeitet von Tobias
 */

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : NewItem
{
    public EquipmentSlot equipmentSlot;   //Funktion der Ausruestung
    public int healthModifier;
    public int damageModifier;

    //wird aufgerugen, wenn die Ausruestung im Inventar gedrueckt wird
    public override void Use()
    {
        EquipmentManager.instance.Equip(this);
    }
}

//Enum zum hinzuweisen der Funktion der Ausruestung
public enum EquipmentSlot { Weapon, Armor}

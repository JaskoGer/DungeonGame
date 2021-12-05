using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Kacper Purtak
 * version 1.0
 * 30.11.2021
 * Description: Aufheben eines Items
 */
public class PickUpItem : MonoBehaviour
{
    public GameObject fakeItem;	   //Gegenstand, welcher auf sich auf der Map befindet
    public AudioSource pickUpFX;   //Sound, der beim aufsammeln abgespielt wird
    public NewItem item;

	//wird ausgefuehrt, wenn der Gegenstand mit dem Spieler kolliediert
    private void OnTriggerEnter(Collider other)
    {
		if(other == ObjectManager.instance.player.GetComponent<BoxCollider>()){	
			pickUpFX.Play();
			Debug.Log("Picking up " + item.name);
			bool wasPickedUp = NewInventory.instance.Add(item);
			if (wasPickedUp)
			{
				Destroy(fakeItem);
				Destroy(this);
			}
		}
    }
}

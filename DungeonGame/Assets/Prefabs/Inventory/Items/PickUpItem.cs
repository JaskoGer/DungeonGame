using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Kacper Purtak
 * version 1.0
 * 30.11.2021
 * Description: Script to pick up items
 */
public class PickUpItem : MonoBehaviour
{
    public GameObject fakeItem;
    public AudioSource pickUpFX;
    public NewItem item;
	public Transform player;

    private void OnTriggerEnter(Collider other)
    {
		if(other == player.GetComponent<BoxCollider>()){	
			pickUpFX.Play();
			Debug.Log("Picking up " + item.name);
			bool wasPickedUp = NewInventory.instance.Add(item);
			if (wasPickedUp)
			{
				Destroy(fakeItem);
			}
		}
    }
}

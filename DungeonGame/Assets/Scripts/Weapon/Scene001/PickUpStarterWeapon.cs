using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Kacper Purtak
 * version 1.0
 * 01.11.2021
 * Bearbeitet von Tobias
 * Description: Script to pick up weapons
 */
public class PickUpStarterWeapon : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        FirstSceneComplete.isStarterWeaponPickedUp = true;
    }
}
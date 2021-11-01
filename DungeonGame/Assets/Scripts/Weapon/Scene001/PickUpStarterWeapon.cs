using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Kacper Purtak
 * version 1.0
 * 01.11.2021
 * Description: Script to pick up weapons
 */
public class PickUpStarterWeapon : MonoBehaviour
{
    public GameObject realWeapon;
    public GameObject fakeWeapon;
    public AudioSource pickUpFX;

    private void OnTriggerEnter(Collider other)
    {
        pickUpFX.Play();
        fakeWeapon.SetActive(false);
        realWeapon.SetActive(true);
        FirstSceneComplete.isStarterWeaponPickedUp = true;
        Destroy(this);
    }
}

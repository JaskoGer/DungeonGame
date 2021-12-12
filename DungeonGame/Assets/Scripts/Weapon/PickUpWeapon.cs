using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Kacper Purtak
 * version 1.0
 * 31.10.2021
 * Description: Ermoeglicht es bei Kollision eine Waffe aufzuheben
 */
public class PickUpWeapon : MonoBehaviour
{
    public GameObject realWeapon;   //echte Waffe im Player Objekt
    public GameObject fakeWeapon;   //falsche Waffe auf dem Boden
    public AudioSource pickUpFX;    //Sound,beim Aufheben

    //Wird ausgefuehrt bei einer Kollision mit einem Trigger-Collider
    private void OnTriggerEnter(Collider other)
    {
        pickUpFX.Play();
        fakeWeapon.SetActive(false);
        realWeapon.SetActive(true);
        Destroy(this);
    }
}

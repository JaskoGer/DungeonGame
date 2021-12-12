using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    public GameObject shopUI;
    public AudioSource magMonetenFX;

    private void OnTriggerEnter(Collider other)
    {
        shopUI.SetActive(true);
        magMonetenFX.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        shopUI.SetActive(false);
    }
}

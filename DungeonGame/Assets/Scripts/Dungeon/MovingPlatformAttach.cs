using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @Author Kacper
 * Beschreibung: Zieht den Spieler auf einer bewegenden Plattform mit sich
 */

public class MovingPlatformAttach : MonoBehaviour
{
    public GameObject thePlayer;

    //Bindet den Spieler an die Platform (als Kindobjekt) beim Betreten
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == thePlayer)
        {
            thePlayer.transform.parent = transform;
        }
    }

    //Bindet den Spieler aus der Platform beim Raustreten
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == thePlayer)
        {
            thePlayer.transform.parent = null;
        }
    }
}

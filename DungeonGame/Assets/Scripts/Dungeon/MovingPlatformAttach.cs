using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @Author Kacper
 * Beschreibung: Zieht den Spieler auf einer bewegenden Plattform mit sich
 * Bearbeitet von Tobias
 */

public class MovingPlatformAttach : MonoBehaviour
{
    private GameObject thePlayer;

    private void Start()
    {
        thePlayer = ObjectManager.instance.player.gameObject;
    }

    //Bindet den Spieler an die Platform (als Kindobjekt) beim Betreten
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == thePlayer)
        {
            thePlayer.transform.parent = transform;
        }
    }

    //Bindet den Spieler aus der Platform beim Austreten
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == thePlayer)
        {
            thePlayer.transform.parent = null;
        }
    }
}

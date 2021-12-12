using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @Author Tobias
 * Beschreibung: Zieht den Spieler auf einer bewegenden Plattform mit sich
 */

public class MovingPlatformAttach : MonoBehaviour
{
    private GameObject thePlayer;
    private bool entered;
    private Vector3 position;

    private void Start()
    {
        thePlayer = ObjectManager.instance.player.gameObject;
    }

    private void Update ()
    {
        if (entered)
        {
            thePlayer.transform.position += new Vector3(transform.position.x - position.x, transform.position.y - position.y, transform.position.z - position.z);

        }
        position = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == thePlayer)
        {
            entered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == thePlayer)
        {
            entered = false;
        }
    }
}

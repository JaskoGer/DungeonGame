using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * @Author Jasko
 * Entfernt Earl aus der Szene, wenn über den Gem gelaufen wird
 */
public class EarlJump : MonoBehaviour
{
    Transform target;
    public GameObject Earl;

    void Start()
    {
        target = ObjectManager.instance.player.transform;    
    }

    void Update()
    {
        if(Vector3.Distance(target.position, transform.position) <= 2f)
        {
            Earl.SetActive(false);
        }    
    }
}

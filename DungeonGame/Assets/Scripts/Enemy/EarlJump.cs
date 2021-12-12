using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarlJump : MonoBehaviour
{
    Transform target;
    public GameObject Earl;

    void Start()
    {
        target = ObjectManager.instance.player.transform;    
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(target.position, transform.position) <= 2f)
        {
            Earl.SetActive(false);
        }    
    }
}

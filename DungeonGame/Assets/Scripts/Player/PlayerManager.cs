using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @author Tobias
 * �berpr�ft ob der Player unter eine gewisse grenze f�llt
*/
public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update

    #region Singleton

    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public float lowestHeight = 0f;
    private Transform player;
    public float startPointx = 0f;
    public float startPointy = 0f;
    public float startPointz = 0f;
    public Quaternion startRotation = Quaternion.Euler(Vector3.zero);

    private void Start()
    {
        player = ObjectManager.instance.player.transform;
    }

    private void Update()
    {
        if (player.transform.position.y < lowestHeight)
        {
            player.GetComponent<DeathController>().DieInstant();
        }
    }

}

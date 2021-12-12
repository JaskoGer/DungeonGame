using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @author Tobias
 * überprüft ob der Player unter eine gewisse grenze fällt
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
            player.transform.Find("rotator").rotation = Quaternion.Euler(Vector3.zero);
            player.transform.Find("RandyBeta").rotation = Quaternion.Euler(Vector3.zero);
            player.transform.SetPositionAndRotation(new Vector3(startPointx, startPointy, startPointz), startRotation);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public GameObject player;
    public float StartPointx = 0f;
    public float StartPointy = 0f;
    public float StartPointz = 0f;
    public Quaternion StartRotation = Quaternion.Euler(Vector3.zero);

    private void Update()
    {
        if (player.transform.position.y < lowestHeight)
        {
            player.transform.Find("rotator").rotation = Quaternion.Euler(Vector3.zero);
            player.transform.Find("RandyBeta").rotation = Quaternion.Euler(Vector3.zero);
            player.transform.SetPositionAndRotation(new Vector3(StartPointx, StartPointy, StartPointz), StartRotation);
        }
    }

}

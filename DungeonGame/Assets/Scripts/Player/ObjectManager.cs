using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{

    #region Singleton

    public static ObjectManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject playerCharacter;
    public Transform player;
    public Transform mainCam;
    public Transform camRotator;
}

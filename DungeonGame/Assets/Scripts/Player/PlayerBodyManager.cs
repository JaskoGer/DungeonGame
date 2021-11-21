using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBodyManager : MonoBehaviour
{

    #region Singleton

    public static PlayerBodyManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject playerBody;
}

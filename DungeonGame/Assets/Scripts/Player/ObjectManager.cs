using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{

    #region Singleton

    public static ObjectManager instance;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		
		else if (instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}

	#endregion

	public GameObject playerCharacter;
    public Transform player;
    public Transform mainCam;
    public Transform camRotator;
	public Transform earl;
    public GameObject fadeOutScene;
	public GameObject errorTextField;
    public GameObject inventory;
	public GameObject crossBow;
    public GameObject pitchFork;
	public GameObject metalFork;
}

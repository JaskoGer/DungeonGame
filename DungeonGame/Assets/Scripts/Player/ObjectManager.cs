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

		//DontDestroyOnLoad(gameObject);
	}

	#endregion

	public GameObject playerCharacter;
    public Transform player;
    public Transform mainCam;
    public Transform camRotator;
	
	void Start()
	{
		player = GameObject.Find("/Player").transform;
		print(GameObject.Find("/Player").transform);
		playerCharacter = GameObject.Find("/Player/RandyBeta");
		print(GameObject.Find("/Player/RandyBeta"));
		camRotator = GameObject.Find("/Player/rotator").transform;
		mainCam = GameObject.Find("/Player/rotator/Main Camera").transform;
	}
}

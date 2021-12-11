using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/*
 * @author Tobias Haubold
 * version 1.0
 * 01.11.2021
 * Description: Scene Wechsel
 */
public class Boos2Deafeat : MonoBehaviour
{
	private GameObject fadeOut;
	public GameObject Boss;
	private bool loaded = false;
	private GameObject thePlayer;
	private GameObject gameManager;
	private PlayerManager positionManager;

    void Start()
	{
		thePlayer = ObjectManager.instance.player.gameObject;
		gameManager = GameObject.Find("GameManager");
		positionManager = gameManager.GetComponent<PlayerManager>();
		thePlayer.transform.position = new Vector3(positionManager.startPointx, positionManager.startPointy, positionManager.startPointz);
		fadeOut = ObjectManager.instance.fadeOutScene.gameObject;
		fadeOut.SetActive(false);
	}
	
    void Update()
	{
		if(Boss == null && !loaded)
		{
			StartCoroutine(CompletedScene());
		}
	}

    IEnumerator CompletedScene()
    {
		loaded = true;
        GlobalScene.currentScene = 4;
		fadeOut.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(GlobalScene.currentScene);
    }
}

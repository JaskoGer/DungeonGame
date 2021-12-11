using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Boos1Deafeat : MonoBehaviour
{
	private GameObject fadeOut;
	public GameObject SlimeBoss;
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
		
		Debug.Log("SlimeBoss");
		if(SlimeBoss == null && !loaded)
		{
			StartCoroutine(CompletedScene());
		}
	}

    IEnumerator CompletedScene()
    {
		loaded = true;
        GlobalScene.currentScene = 4;
		//fadeout
		fadeOut.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(GlobalScene.currentScene);
    }
}

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

	void Start()
	{
		//fadeout
		fadeOut = ObjectManager.instance.player.transform.GetChild(3).GetChild(0).GetChild(2).gameObject;
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

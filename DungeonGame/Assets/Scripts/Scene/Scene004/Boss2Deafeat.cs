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
public class Boss2Deafeat : MonoBehaviour
{
	public GameObject Boss;
	private bool loaded = false;

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
		ObjectManager.instance.fadeOutScene.SetActive(true);
        yield return new WaitForSeconds(2f);
		GlobalScene.currentScene = 6;
		SceneManager.LoadScene(GlobalScene.currentScene);
    }
}

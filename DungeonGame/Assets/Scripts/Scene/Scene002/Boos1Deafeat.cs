using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Boos1Deafeat : MonoBehaviour
{
	public GameObject SlimeBoss;
	private bool loaded = false;

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
		ObjectManager.instance.fadeOutScene.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(GlobalScene.currentScene);
    }
}

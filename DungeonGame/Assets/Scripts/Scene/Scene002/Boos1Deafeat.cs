using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Boos1Deafeat : MonoBehaviour
{
	private GameObject fadeOut;
	public GameObject SlimeBoss;
	private bool loaded = false;

	void Start()
	{
		//fadeout
		fadeOut = ObjectManager.instance.player.transform.GetChild(3).GetChild(0).GetChild(2).gameObject;
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

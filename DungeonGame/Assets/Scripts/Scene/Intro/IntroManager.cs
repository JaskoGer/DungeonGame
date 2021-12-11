using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * @author Kacper Purtak
 * version 1.0
 * 10.12.2021
 * Description: Steuerndes Script der Intro Sequenz
 */

public class IntroManager : MonoBehaviour
{
    public GameObject gameLogo;
    public AudioSource introSound;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartIntro());
    }

    IEnumerator StartIntro()
    {
        introSound.Play();
        yield return new WaitForSeconds(1f);
        gameLogo.SetActive(true);
        yield return new WaitForSeconds(9f);
        SceneManager.LoadScene(1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// @author Laurin Sebek
/// Script für das abspielen einer zufaelligen Hintergrundmusik
/// @Version 0.9.13 - 08.11.2021
public class MusicController : MonoBehaviour
{
    public AudioSource BackgroundMusik;
        public AudioClip[] myBackgroundMusik;

    // Start is called before the first frame update
    void Start()
    {
        playRandomBackgroundMusik();   
    }

    // Update is called once per frame
    void Update()
    {
        if (!BackgroundMusik.isPlaying)
        {
            playRandomBackgroundMusik();
        }
    }

    void playRandomBackgroundMusik()
    {
        BackgroundMusik.clip = myBackgroundMusik[Random.Range(0, myBackgroundMusik.Length)] as AudioClip;

        BackgroundMusik.Play();
    }
}

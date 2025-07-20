using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgSource;
    public AudioSource audioSource;

    public AudioClip bgMusic;
    public AudioClip matchSound;
    public AudioClip nomatchSound;

    void Start()
    {
        bgSource.clip = bgMusic;
        bgSource.loop = true;
        bgSource.Play();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
 
    public void MatchSound()
    {
        audioSource.clip = matchSound;
        audioSource.Play();

    }
    public void NoMatchSound()
    {
        audioSource.clip = nomatchSound;
        audioSource.Play();
    }


}



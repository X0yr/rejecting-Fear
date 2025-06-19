using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSound : MonoBehaviour
{
    public AudioClip[] walkSound_AR;


    private AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Walk_sound_play()
    {
        audioSource.PlayOneShot(walkSound_AR[Random.Range(0, walkSound_AR.Length)]);
    }
}

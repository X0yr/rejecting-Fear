using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSlice : MonoBehaviour
{
    public AudioClip[] sliceSound_AR;


    private AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Slice_sound_play()
    {
        audioSource.PlayOneShot(sliceSound_AR[Random.Range(0, sliceSound_AR.Length)]);
    }
}

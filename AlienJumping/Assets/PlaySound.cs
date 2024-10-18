using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    private AudioSource soundSource;
    public static PlaySound instance{get; private set; }
    private void Awake()
    {
        soundSource = GetComponent<AudioSource>();
        if (instance == null)
        {
            instance = this; // Assign this instance
        }
        else
        {
            Destroy(gameObject); // Ensure there's only one instance
        }
    }
    public void PlaySourceSound(AudioClip _sound)
    {
        soundSource.PlayOneShot(_sound);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // Singleton instance

    public AudioClip backgroundMusic; // Background music
    public AudioClip soundEffect; // Sound effect for actions/events

    private AudioSource musicSource; // AudioSource for music
    private AudioSource sfxSource; // AudioSource for sound effects

    private void Awake()
    {
        // Singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Initialize audio sources
        musicSource = gameObject.AddComponent<AudioSource>();
        sfxSource = gameObject.AddComponent<AudioSource>();

        // Assign background music to musicSource
        musicSource.clip = backgroundMusic;
        musicSource.loop = true; // Loop the background music
        musicSource.Play(); // Start playing background music
    }

    // Method to play a sound effect
    public void PlaySoundEffect()
    {
        sfxSource.PlayOneShot(soundEffect);
    }
}

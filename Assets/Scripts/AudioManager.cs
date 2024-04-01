using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource ballRollingAudio;
    public AudioSource strikeAudio;

    private void Awake()
    {
        // Ensure there's only one instance of GameManager
        if (instance == null)
        {
            instance = this; // Set the instance to this object if it's null
            DontDestroyOnLoad(gameObject); // Optional: Keep GameManager alive between scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    public void PlayBallRollingAudio()
    {
        ballRollingAudio.Play();
    }

    public void PlayStrikeAudio()
    {
        strikeAudio.Play();
    }
}

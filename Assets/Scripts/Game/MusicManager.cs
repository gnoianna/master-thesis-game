using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    public float MusicVolume = 0.5f;
    public float SoundVolume = 0.5f;

    public AudioSource MusicAudioSource;
    public AudioSource SoundAudioSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeMusicVolume(float volume)
    {
        MusicVolume = volume;
        MusicAudioSource.volume = MusicVolume;
    }

    public void ChangeSoundVolume(float volume)
    {
        SoundVolume = volume;
        SoundAudioSource.volume = SoundVolume;
    }

    public void UpdateMusic(AudioClip newMusic)
    {
        MusicAudioSource.clip = newMusic;
        MusicAudioSource.Play();
    }

    public void PlayCollisionSound()
    {
        SoundAudioSource.Play();
    }
}

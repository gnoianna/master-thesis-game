using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public float MusicVolume;
    public float SoundVolume;
    public AudioSource Music;
    public AudioSource Sound;

    void Start()
    {
        MusicVolume = 0.5f;
        SoundVolume = 0.5f;
    }

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
        Music.volume = MusicVolume;
    }

    public void ChangeSoundVolume(float volume)
    {
        SoundVolume = volume;
        Sound.volume = SoundVolume;
    }

    public void UpdateMusicAudioClip(AudioClip newMusic)
    {
        Music.clip = newMusic;
        Music.Play();
    }

    public void PlayCollisionSound()
    {
        Sound.Play();
    }
}

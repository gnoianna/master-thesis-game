using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SliderController : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        if (gameObject.CompareTag("Music"))
            slider.value = MusicManager.Instance.MusicVolume;
        else if (gameObject.CompareTag("Sound"))
            slider.value = MusicManager.Instance.SoundVolume;
    }

    public void ChangeAudioSourceVolume()
    {
        if (gameObject.CompareTag("Music"))
            MusicManager.Instance.ChangeMusicVolume(slider.value);
        else if (gameObject.CompareTag("Sound"))
            MusicManager.Instance.ChangeSoundVolume(slider.value);
    }
}

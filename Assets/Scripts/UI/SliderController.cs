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
            slider.value = AudioManager.Instance.MusicVolume;
        else if (gameObject.CompareTag("Sound"))
            slider.value = AudioManager.Instance.SoundVolume;
    }

    public void ChangeAudioSourceVolume()
    {
        if (gameObject.CompareTag("Music"))
            AudioManager.Instance.ChangeMusicVolume(slider.value);
        else if (gameObject.CompareTag("Sound"))
            AudioManager.Instance.ChangeSoundVolume(slider.value);
    }
}

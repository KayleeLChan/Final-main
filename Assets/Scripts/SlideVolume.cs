using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SlideVolume : MonoBehaviour
{

    public AudioMixer mixer;

    //Set the volume of bgm to point of settings slider logarithmically rather than linearally
    public void SetVolume (float sliderValue)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue)*20);
    }
}

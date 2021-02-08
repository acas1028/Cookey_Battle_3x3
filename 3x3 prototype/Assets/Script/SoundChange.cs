using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundChange : MonoBehaviour
{
    public Scrollbar soundVolume;
    public AudioSource soundAudio;
   
    // Start is called before the first frame update
    void Start()
    {
        soundVolume.value = GameManager.instance.soundVol;
        soundAudio.volume = soundVolume.value;
    }

    // Update is called once per frame
    void Update()
    {
        MusicSlider();
    }

    public void MusicSlider()
    {
        soundAudio.volume = soundVolume.value;
        GameManager.instance.soundVol = soundVolume.value;
    }

    public void PlaySound()
    {
        soundAudio.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicChange : MonoBehaviour
{

    public Scrollbar musicVolume;
    public Scrollbar soundVolume;
    // Start is called before the first frame update

    private void Awake()
    {

    }
    void Start()
    {
        musicVolume.value = GameManager.instance.musicVol;
        soundVolume.value = GameManager.instance.soundVol;
    }

    // Update is called once per frame
    void Update()
    {
        MusicSlider();
        SoundSlider();
    }

    public void MusicSlider()
    {
        GameManager.instance.musicVol = musicVolume.value;
    }

    public void SoundSlider()
    {
        GameManager.instance.soundVol = soundVolume.value;
    }

}

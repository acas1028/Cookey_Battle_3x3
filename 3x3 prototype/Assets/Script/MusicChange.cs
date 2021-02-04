using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicChange : MonoBehaviour
{

    public Scrollbar musicVolume;
    // Start is called before the first frame update

    private void Awake()
    {

    }
    void Start()
    {
        musicVolume.value = GameManager.instance.musicVol;
    }

    // Update is called once per frame
    void Update()
    {
        MusicSlider();
    }

    public void MusicSlider()
    {
        GameManager.instance.musicVol = musicVolume.value;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource musicAudio;
    private void Awake()
    {
        
    }
    void Start()
    {
        musicAudio.volume = GameManager.instance.musicVol;
    }

    // Update is called once per frame
    void Update()
    {
        musicAudio.volume = GameManager.instance.musicVol;
    }
}

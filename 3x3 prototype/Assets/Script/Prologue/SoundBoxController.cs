using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBoxController : MonoBehaviour
{
    public AudioClip[] audioClips;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<AudioSource>().volume = GameManager.instance.soundVol;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(int num)
    {
        if (num >= audioClips.Length)
            return;

        this.GetComponent<AudioSource>().clip = audioClips[num];
        this.GetComponent<AudioSource>().Play();
    }
}

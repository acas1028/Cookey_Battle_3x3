using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class StageSelect_SoundBox : MonoBehaviour
{
    public AudioClip StageSelect;
    
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<AudioSource>().volume = GameManager.instance.soundVol;

        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound()
    {
        this.gameObject.GetComponent<AudioSource>().Play();

        Destroy(this.gameObject, 1.5f);
    }
}

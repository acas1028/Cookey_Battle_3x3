using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class StageSelect_SoundChange : MonoBehaviour
{

    public AudioClip selectStage1;
    public AudioClip selectStage2;
    public AudioClip selectStage3;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<AudioSource>().volume = GameManager.instance.soundVol;

        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectStage1SoundPlay()
    {
        this.GetComponent<AudioSource>().clip = selectStage1;
        this.GetComponent<AudioSource>().Play();
        Destroy(this.gameObject,1);
    }

    public void SelectStage2SoundPlay()
    {
        this.GetComponent<AudioSource>().clip = selectStage2;
        this.GetComponent<AudioSource>().Play();
        Destroy(this.gameObject,1);
    }

    public void SelectStage3SoundPlay()
    {
        this.GetComponent<AudioSource>().clip = selectStage3;
        this.GetComponent<AudioSource>().Play();
        Destroy(this.gameObject,1);
    }
}

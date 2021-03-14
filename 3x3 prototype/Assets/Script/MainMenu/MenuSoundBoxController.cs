using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSoundBoxController : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip SceneChangeSound;
    public AudioClip OptionSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = GameManager.instance.soundVol;
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySceneChangeSound()
    {
        StartCoroutine("PlayingSceneChangeSound");
    }
    IEnumerator PlayingSceneChangeSound()
    {
        audioSource.clip = SceneChangeSound;
        audioSource.Play();

        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }

    public void PlayOptionSound()
    {
        audioSource.clip = OptionSound;
        audioSource.Play();
    }

}

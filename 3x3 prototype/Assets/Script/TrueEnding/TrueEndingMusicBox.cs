using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrueEndingMusicBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<AudioSource>().volume = GameManager.instance.musicVol;

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "LoadingScene")
            Destroy(gameObject);
    }
}

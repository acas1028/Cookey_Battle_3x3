using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrologueSkipScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sceneChange()
    {
        if(PlayerPrefs.HasKey("Name"))
        {
            LoadingSceneManager.LoadScene(2);
        }
        else
        {
            LoadingSceneManager.LoadScene(1);
        }
    }
}

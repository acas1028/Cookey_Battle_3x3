using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNameButton : MonoBehaviour
{
    public GameObject NameCheck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void yesButton()
    {
        LoadingSceneManager.LoadScene(2);
    }

    public void noButton()
    {
        NameCheck.gameObject.SetActive(false);
    }
}

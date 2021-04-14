using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSkip : MonoBehaviour
{
    public GameObject tutorialInput;

    public bool isSkip;

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
        isSkip = true;
        this.gameObject.SetActive(false);
    }

    public void NoButton()
    {
        isSkip = false;
        this.gameObject.SetActive(false);
        
    }
}

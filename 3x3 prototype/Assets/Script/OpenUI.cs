using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenUI : MonoBehaviour
{
    public GameObject gameObject_UI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeUIStatus()
    {
        if (gameObject_UI.activeSelf == true)
            gameObject_UI.SetActive(false);
        else
            gameObject_UI.SetActive(true);
    }
}

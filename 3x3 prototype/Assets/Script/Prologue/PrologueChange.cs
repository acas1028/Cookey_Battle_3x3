using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrologueChange : MonoBehaviour
{
    public GameObject currentButton;
    public GameObject nextButton;
    public int sceneNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void changeImage()
    {
        if (currentButton.tag == "Untagged")
        {
            currentButton.SetActive(false);
            nextButton.SetActive(true);
        }
        else if(currentButton.tag== "No")
        {
            nextButton.SetActive(true);
        }

        if (nextButton.transform.tag == "Finish")
            LoadingSceneManager.LoadScene(sceneNumber);

    }
}

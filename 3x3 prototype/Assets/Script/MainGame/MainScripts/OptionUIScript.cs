using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionUIScript : MonoBehaviour
{
    public GameObject MainKeyBoardInput;
    public GameObject OptionUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ExitButton();
        }
    }
    
    public void ExitButton()
    {
        OptionUI.SetActive(false);
        MainKeyBoardInput.SetActive(true);
    }

    public void StageButton()
    {
        LoadingSceneManager.LoadScene(2);
    }

    public void MainMenuButton()
    {
        LoadingSceneManager.LoadScene(0);
    }
}

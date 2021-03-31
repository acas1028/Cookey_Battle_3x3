using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragonButton: MonoBehaviour
{
     void Start()
    {
        
    }

     void Update()
    {
        
    }


    public void PracticeDragonButton()
    {
        GameManager.instance.SetStageLevel(3);
        SceneManager.LoadScene("PracticeMode_DragonWallington");
        this.gameObject.SetActive(false);
    }
}

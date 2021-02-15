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
        SceneManager.LoadScene("Practice Mode_Dragon Wallton");
        this.gameObject.SetActive(false);
    }
}

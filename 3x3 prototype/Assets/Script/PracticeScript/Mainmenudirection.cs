using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenudirection : MonoBehaviour
{
    
    public void Mainmenudirect()
    {
        SceneManager.LoadScene("MainMenu");
        this.gameObject.SetActive(false);
    }
}

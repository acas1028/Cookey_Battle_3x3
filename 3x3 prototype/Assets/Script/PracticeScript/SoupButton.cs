using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoupButton: MonoBehaviour
{

    // Start is called before the first frame update
    public void PracticeSoupButton()
    {
        SceneManager.LoadScene("Practice Mode_Space Soup");
        this.gameObject.SetActive(false);
        
    }

   
}

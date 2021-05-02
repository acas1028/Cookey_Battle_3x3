using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoupButton: MonoBehaviour
{

    // Start is called before the first frame update
    public void PracticeSoupButton()
    {
        GameManager.instance.SetStageLevel(1);
        SceneManager.LoadScene("PracticeMode_SpaceSoup");
        
        
    }

   
}

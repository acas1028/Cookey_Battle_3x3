using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeButton : MonoBehaviour
{

    // Start is called before the first frame update


    public void PracticeSlimeButton()
    {
            GameManager.instance.SetStageLevel(2);
            SceneManager.LoadScene("Practice Mode_Slime Salad");
            this.gameObject.SetActive(false);

        
    }

   
}

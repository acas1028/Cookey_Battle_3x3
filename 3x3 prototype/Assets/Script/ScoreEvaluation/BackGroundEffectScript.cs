using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundEffectScript : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        SetClearState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetClearState()
    {
        switch (GameManager.instance.GetStageLevel())
        {
            case 1:
                GetComponent<Animator>().SetInteger("ClearState", 0);
                if (GameManager.instance.GetStage1Clear())
                    GetComponent<Animator>().SetInteger("ClearState", 1);
                if (GameManager.instance.GetStage1HiddenClear())
                    GetComponent<Animator>().SetInteger("ClearState", 2);
                break;
            case 2:
                GetComponent<Animator>().SetInteger("ClearState", 0);
                if (GameManager.instance.GetStage2Clear())
                    GetComponent<Animator>().SetInteger("ClearState", 1);
                if (GameManager.instance.GetStage2HiddenClear())
                    GetComponent<Animator>().SetInteger("ClearState", 2);
                break;
            case 3:
                GetComponent<Animator>().SetInteger("ClearState", 0);
                if (GameManager.instance.GetStage3Clear())
                    GetComponent<Animator>().SetInteger("ClearState", 1);
                if (GameManager.instance.GetStage3HiddenClear())
                    GetComponent<Animator>().SetInteger("ClearState", 2);
                break;
        }
    }
}

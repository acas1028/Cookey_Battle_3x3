using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinishScript : MonoBehaviour
{
    public GameObject ingameStepObject;
    public GameObject fieldObject;

    int hiddenCondition;
    int hiddenCount;

    int fieldScore;
    // Start is called before the first frame update
    void Start()
    {
        
        hiddenCondition = ingameStepObject.GetComponent<CompareActiveAnswer>().GetHiddenConditionNumber();
        hiddenCount = ingameStepObject.GetComponent<CompareActiveAnswer>().GetHiddenCount();

        fieldScore = fieldObject.GetComponent<FieldObjectScript>().GetFieldScore();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            switch(GameManager.instance.GetStageLevel())
            {
                case 1:
                    fieldObject.GetComponent<FieldObjectScript>().SetFieldScore(fieldScore / 16);
                    fieldScore = fieldObject.GetComponent<FieldObjectScript>().GetFieldScore();
                    GameManager.instance.SetStage1Try(true);
                    GameManager.instance.SetStage1Score(fieldScore);
                    LoadingSceneManager.LoadScene(8);
                    break;
                case 2:
                    fieldObject.GetComponent<FieldObjectScript>().SetFieldScore(fieldScore / 28);
                    fieldScore = fieldObject.GetComponent<FieldObjectScript>().GetFieldScore();
                    GameManager.instance.SetStage2Try(true);
                    GameManager.instance.SetStage2Score(fieldScore);
                    LoadingSceneManager.LoadScene(9);
                    break;
                case 3:
                    fieldObject.GetComponent<FieldObjectScript>().SetFieldScore(fieldScore / 38);
                    fieldScore = fieldObject.GetComponent<FieldObjectScript>().GetFieldScore();
                    GameManager.instance.SetStage3Try(true);
                    GameManager.instance.SetStage3Score(fieldScore);
                    LoadingSceneManager.LoadScene(10);
                    break;
            }

            if (hiddenCondition == hiddenCount)
            {
                GameManager.instance.SetStageHiddenCondition(true);
                Debug.Log("Hidden Clear");
            }
            else
            {
                GameManager.instance.SetStageHiddenCondition(false);
                Debug.Log("Normal Clear");
            }
            
        }
    }
    
   
}

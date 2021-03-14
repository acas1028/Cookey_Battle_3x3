using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject ingameStepObject;
    public GameObject fieldObject;

    public GameObject[] foodImageShadow;

    int hiddenCondition;
    int hiddenCount;

    int fieldScore;
   
    void Start()
    {
        hiddenCondition = ingameStepObject.GetComponent<CompareActiveAnswer>().GetHiddenConditionNumber();
        hiddenCount = ingameStepObject.GetComponent<CompareActiveAnswer>().GetHiddenCount();

        fieldScore = fieldObject.GetComponent<FieldObjectScript>().GetFieldScore();
    }

    // Update is called once per frame
    void Update()
    {
        switch(GameManager.instance.GetStageLevel())
        {
            case 1:
                fieldObject.GetComponent<FieldObjectScript>().SetFieldScore(fieldScore / 16);
                fieldScore = fieldObject.GetComponent<FieldObjectScript>().GetFieldScore();
                if(fieldScore<60)
                {
                    foodImageShadow[0].SetActive(true);
                }
                else if(fieldScore>=60)
                {
                    foodImageShadow[1].SetActive(true);
                }

                break;

            case 2:
                fieldObject.GetComponent<FieldObjectScript>().SetFieldScore(fieldScore / 28);
                fieldScore = fieldObject.GetComponent<FieldObjectScript>().GetFieldScore();
                if (fieldScore < 80)
                {
                    foodImageShadow[2].SetActive(true);
                }
                else if (fieldScore >= 80)
                {
                    foodImageShadow[3].SetActive(true);
                }
                break;

            case 3:
                fieldObject.GetComponent<FieldObjectScript>().SetFieldScore(fieldScore / 38);
                fieldScore = fieldObject.GetComponent<FieldObjectScript>().GetFieldScore();
                if (fieldScore < 95)
                {
                    foodImageShadow[4].SetActive(true);
                }
                else if (fieldScore >= 95)
                {
                    foodImageShadow[5].SetActive(true);
                }

                break;
        }
    }
}

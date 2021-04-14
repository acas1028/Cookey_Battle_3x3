using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public float timer;

    public GameObject commandCompare;


    public void Update()
    {
        timer += Time.deltaTime;
        
        if(commandCompare.GetComponent<CompareActiveAnswer>().isInventoryOk==true)
        {
            if(timer>1)
            {
                commandCompare.GetComponent<CompareActiveAnswer>().ShowMakingIngredient.SetActive(false);
                commandCompare.GetComponent<CompareActiveAnswer>().block.SetActive(false);
                commandCompare.GetComponent<CompareActiveAnswer>().isInventoryOk = false;
                commandCompare.GetComponent<CompareActiveAnswer>().keyboardinput.SetActive(true);
            }
        }

    }
}

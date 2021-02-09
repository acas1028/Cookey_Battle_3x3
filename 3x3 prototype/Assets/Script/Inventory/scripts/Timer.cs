using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public float timer;

    public GameObject commandCompare;


    public void Update()
    {
        timer += 1;
        
        if(commandCompare.GetComponent<CompareActiveAnswer>().isInventoryOk==true)
        {
            if(timer>200)
            {
                commandCompare.GetComponent<CompareActiveAnswer>().ShowMakingIngredient.SetActive(false);
                commandCompare.GetComponent<CompareActiveAnswer>().block.SetActive(false);
                commandCompare.GetComponent<CompareActiveAnswer>().isInventoryOk = false;
                commandCompare.GetComponent<CompareActiveAnswer>().keyboardinput.SetActive(true);
            }
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardAndInventorySwitch : MonoBehaviour
{
    public GameObject compareActiveAnswer;

    public int removeCount = 1;

    public int ususalCount;

    public bool isInventorystart = false;

    private void Start()
    {
       
    }

    private void Update()
    {

        if( compareActiveAnswer.GetComponent<CompareActiveAnswer>().inventoryonoff==true)
        {
            ususalCount = compareActiveAnswer.GetComponent<CompareActiveAnswer>().basic_instance.Count;
        }

        if (compareActiveAnswer.GetComponent<CompareActiveAnswer>().basic_instance.Count== ususalCount-removeCount )
        {
            isInventorystart = true;
            
        }
    }
}

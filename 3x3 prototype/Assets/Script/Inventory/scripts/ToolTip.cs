using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Database")
        {
            text.text = other.GetComponent<DataSpace>().item_List.Explanation;
        }

        if(other.tag =="Slot")
        {
            if(other.transform.childCount ==0)
            {
                text.text = null;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if( other.tag == "Database")
        {
            text.text = null;
        }
    }
}

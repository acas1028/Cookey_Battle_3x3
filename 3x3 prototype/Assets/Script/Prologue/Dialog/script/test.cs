using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
   
    public int index;

    
    void Start()
    {
        IEnumerator dialog_co = dialog.instance.dialog_system_start(0);
        StartCoroutine(dialog_co);
    }

    private void Update()
    {

    }

    public void skip()
    {
        dialog.instance.skip(index);
    }


}

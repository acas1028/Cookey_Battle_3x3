using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterResultUIController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject beforeObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetAfterObject()
    {
        beforeObject.GetComponent<BeforeChangeScript>().SetAfterSpaceObject();
        beforeObject.GetComponent<BeforeChangeScript>().SetStageSelectObject();
    }
}

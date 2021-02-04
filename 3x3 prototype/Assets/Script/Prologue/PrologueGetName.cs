using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrologueGetName : MonoBehaviour
{
    public Text uiText;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = "'" + GameManager.instance.GetUserName() + "' 으로";
    }
}

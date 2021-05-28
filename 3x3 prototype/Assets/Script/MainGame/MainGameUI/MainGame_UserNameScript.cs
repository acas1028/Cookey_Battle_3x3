using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGame_UserNameScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Text>().text = GameManager.instance.GetUserName().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrueEndingUserName : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.SetUserName("123123"); // 디버깅용
        this.GetComponent<Text>().text = GameManager.instance.GetUserName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

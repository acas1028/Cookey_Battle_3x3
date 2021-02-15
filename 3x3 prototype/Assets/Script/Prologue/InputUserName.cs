﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputUserName : MonoBehaviour
{
    public InputField inputField;

    public GameObject checkNameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateUserName()
    {
        GameManager.instance.SetUserName(inputField.text);
        Debug.Log(GameManager.instance.GetUserName());
        PlayerPrefs.SetString("Name", inputField.text);

        checkNameObject.SetActive(true);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoKey : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Input.GetKeyDown(KeyCode.RightArrow);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueEndingCreditAfterPanel : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f) ;
    }
}

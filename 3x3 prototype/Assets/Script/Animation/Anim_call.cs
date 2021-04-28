﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_call : MonoBehaviour
{
    public Animator player_animator;

    public int ran_states = 0;

    public int ran = 0;

    public float time;

    public GameObject anim_call;

    void Update()
    {
        if (anim_call.GetComponent<CompareActiveAnswer>().anim_call == true)
        {
            this.time += Time.deltaTime;
            Animation_call();
        }
    }

    public void Animation_call()
    {
        if (anim_call.GetComponent<CompareActiveAnswer>().anim_call == true)
        {
            if (time >= 4f)
            {
                
                Random_make();
                player_animator.SetInteger("States", ran_states);
            }
            if (time >= 4f)
            {
                time = 0f;
            }
        }

    }

    public void Random_make()
    {
        if (time <= 8.0f &&time >=4f)
        {
            
            ran_states = Random.Range(1, 5);
        }
    }
}

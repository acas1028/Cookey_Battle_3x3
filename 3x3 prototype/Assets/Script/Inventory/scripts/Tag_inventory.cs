﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tag_inventory : MonoBehaviour
{
    public GameObject[] compare_score_basic;

    public GameObject compare_score;

    public GameObject[] score_space;

    public int find_tag_compare = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if (find_tag_compare == 0)
            {
            score_space = GameObject.FindGameObjectsWithTag("Database");
            for (int i = 0; i < score_space.Length; i++)
            {
                score_space[i].GetComponent<DataSpace>().dataMovingCount = true;

            }

            compare_score_basic = GameObject.FindGameObjectsWithTag("MovingDatabase");
                for (int i = 0; i < score_space.Length; i++)
                {
                    score_space[i].GetComponent<DataSpace>().dataMovingCount = false;
                }
                find_tag_compare++;
            Debug.Log("ww");
            }
    }
}

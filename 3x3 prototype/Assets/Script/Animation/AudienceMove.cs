using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceMove : MonoBehaviour
{
    public GameObject[] Audience;

    public int timer;
    void Start()
    {
        Audience = GameObject.FindGameObjectsWithTag("Audience");
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1;

        if(timer>300)
        {
            for(int i=0; i<Audience.Length;i++)
            {
                if(Audience[i].GetComponent<SpriteRenderer>().flipX == true)
                {
                    Audience[i].GetComponent<SpriteRenderer>().flipX = false;
                }

                else if(Audience[i].GetComponent<SpriteRenderer>().flipX == false)
                {
                    Audience[i].GetComponent<SpriteRenderer>().flipX = true;
                }
            }
            timer = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutIngredientAnime : MonoBehaviour
{
    public bool isAnime = false;

    public GameObject player_Anime;

    public float timer;

    public void Update()
    {
        
        
        if(isAnime==true)
        {
            player_Anime.GetComponent<Animator>().SetInteger("States", 0);
            player_Anime.GetComponent<Animator>().SetInteger("States", 13);
            //Debug.Log(player_Anime.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            timer += Time.deltaTime;
            if(timer> player_Anime.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length)
            {
                isAnime = false;
                player_Anime.GetComponent<Animator>().SetInteger("States", 0);
                timer = 0;
            }
            
        }



        
    }

    
}

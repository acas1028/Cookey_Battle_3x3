using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_KeyBoardInputScript : MonoBehaviour
{
    public GameObject inventory;
    public GameObject commandBook;
    public GameObject recipeBook;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            inventory.SetActive(true);
            this.gameObject.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            commandBook.SetActive(true);
            this.gameObject.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            recipeBook.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}

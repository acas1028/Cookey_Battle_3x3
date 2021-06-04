using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeScriptInput_Command : MonoBehaviour
{
    public GameObject command_Recipe;

    public GameObject recipe;

    public GameObject Command_Recipt_Script;

   

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Command_Recipt_Script.GetComponent<Command_recipeScript>().is_Commanding == true)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {

                if (command_Recipe.activeSelf == false)
                {
                    command_Recipe.SetActive(true);
                    this.gameObject.SetActive(false);
                }
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                if (recipe.activeSelf == false)
                {
                    recipe.SetActive(true);
                    this.gameObject.SetActive(false);

                }
            }
        }
        



    }
}

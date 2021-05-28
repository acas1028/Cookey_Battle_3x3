using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeScriptInput_Command : MonoBehaviour
{
    public GameObject command_Recipe;

    public GameObject recipe;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            if (command_Recipe.activeSelf == true) { command_Recipe.SetActive(false); }
            else { command_Recipe.SetActive(true); }
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            if (recipe.activeSelf == true) { recipe.SetActive(false); }
            else { recipe.SetActive(true); }
        }
    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command_recipeScript : MonoBehaviour
{

    public GameObject recipeScriptinput_command;

    public GameObject command_Recipe;

    public GameObject recipe;

    public int starting_command_Count = 0;

    public bool is_Commanding;

    public bool is_Starting_Command;

    private void Start()
    {
        is_Commanding = false;
        is_Starting_Command = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (is_Commanding==true)
        {
            if (starting_command_Count == 0)
            {
                is_Starting_Command = true;
            }
            if(is_Starting_Command==true)
            {
                recipeScriptinput_command.SetActive(true);
                is_Starting_Command = false;
                starting_command_Count++;
            }

            if (recipeScriptinput_command.activeSelf == false)
            {
                if (Input.GetKeyDown(KeyCode.W)&& recipe.activeSelf==false)
                {
                    command_Recipe.SetActive(false);
                    recipeScriptinput_command.SetActive(true);
                }

                if (Input.GetKeyDown(KeyCode.R)&& command_Recipe.activeSelf==false)
                {
                    recipe.SetActive(false);
                    recipeScriptinput_command.SetActive(true);
                }

            }
        }
    }
}

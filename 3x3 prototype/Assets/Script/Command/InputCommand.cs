using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCommand : MonoBehaviour
{
    public Command command;

    public CalculationCommand calculationCommand;

    public ComandComparison comandComparison;

    public GameObject CommandCompare;

    public GameObject commandCount;

    public GameObject compareactive;

    public bool answer_manager = false;

    public int timer;

    public bool clear_command = false;



    int count = 1;



    private void Update()
    {

        if(CommandCompare.GetComponent<CommandCompare>().timer_manager == true)
        {
            timer += 1;
        }

        if(timer > 200)
        {
            CommandCompare.GetComponent<CommandCompare>().correct_answer.SetActive(false);
            CommandCompare.GetComponent<CommandCompare>().incorrect_answer.SetActive(false);
            answer_manager = true;
        }

        if(answer_manager == true)
        {
            calculationCommand.Commands.Clear();
            for (int i = 0; i < command.commandList.Count; i++)
            {
                Destroy(command.commandList[i]);
            }
            command.commandList.Clear();
            count = 1;
            answer_manager = false;
            CommandCompare.GetComponent<CommandCompare>().timer_manager = false;
            timer = 0;
            CommandCompare.GetComponent<CommandCompare>().command_limit = false;
            if(CommandCompare.GetComponent<CommandCompare>().isSoup == true)
            {
                if (compareactive.GetComponent<CompareActiveAnswer>().CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == compareactive.GetComponent<CompareActiveAnswer>().Soup_Command_Database.GetComponent<Soup_Command_DataBase>().HisCount && compareactive.GetComponent<CompareActiveAnswer>().Soup_Command_Database.GetComponent<Soup_Command_DataBase>().HisCount != 0)
                {
                    clear_command = true;
                }
            }
            if (CommandCompare.GetComponent<CommandCompare>().isSlime == true)
            {
                if (compareactive.GetComponent<CompareActiveAnswer>().CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == compareactive.GetComponent<CompareActiveAnswer>().Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount && compareactive.GetComponent<CompareActiveAnswer>().Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount != 0)
                {
                    clear_command = true;
                }
            }
            if (CommandCompare.GetComponent<CommandCompare>().isDragon == true)
            {
                if (compareactive.GetComponent<CompareActiveAnswer>().CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == compareactive.GetComponent<CompareActiveAnswer>().Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount && compareactive.GetComponent<CompareActiveAnswer>().Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount != 0)
                {
                    clear_command = true;
                }
            }
        }

        if (CommandCompare.GetComponent<CommandCompare>().command_limit == false)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && count < 11)
            {
                calculationCommand.Commands.Add(KeyCode.UpArrow);
                command.Spawn(command.Spawnposition(count), KeyCode.UpArrow);
                count += 1;
            }

            else if (Input.GetKeyDown(KeyCode.RightArrow) && count < 11)
            {
                calculationCommand.Commands.Add(KeyCode.RightArrow);
                command.Spawn(command.Spawnposition(count), KeyCode.RightArrow);
                count += 1;
            }

            else if (Input.GetKeyDown(KeyCode.DownArrow) && count < 11)
            {
                calculationCommand.Commands.Add(KeyCode.DownArrow);
                command.Spawn(command.Spawnposition(count), KeyCode.DownArrow);
                count += 1;
            }

            else if (Input.GetKeyDown(KeyCode.LeftArrow) && count < 11)
            {
                calculationCommand.Commands.Add(KeyCode.LeftArrow);
                command.Spawn(command.Spawnposition(count), KeyCode.LeftArrow);
                count += 1;
            }

            else if (Input.GetKeyDown(KeyCode.Space))
            {
                
                comandComparison.Comparison();
                CommandCompare.GetComponent<CommandCompare>().Command_checking();
                if (commandCount.GetComponent<CommandCount>().isSoup == true)
                {
                    CommandCompare.GetComponent<CommandCompare>().CommandCompare_Soup();
                    Debug.Log("3");
                }
                if (commandCount.GetComponent<CommandCount>().isSlime == true)
                {
                    CommandCompare.GetComponent<CommandCompare>().CommandCompare_Slime();
                }

                if (commandCount.GetComponent<CommandCount>().isDragon == true)
                {
                    CommandCompare.GetComponent<CommandCompare>().CommandCompare_Dragon();
                }

                
                    
               
                    
                
            }

        }
        

        





            //if (comandComparison.commandName!=null)
            //{
            //    Debug.Log(comandComparison.commandName);
            //    comandComparison.commandName = null;
            //}





     }


}

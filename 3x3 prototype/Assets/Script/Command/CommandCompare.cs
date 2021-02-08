using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandCompare : MonoBehaviour
{
    public GameObject commandComparison;

    public GameObject soup_Command_Database;
    
    public GameObject fieldobject;

    public GameObject CompareActiveAnswer;

    public Animator player_animator;

    public int command_Count = 0;

    public int field_score;

    public int command_Score;

    public int final_Command_Score;

    public bool isSame;

    public bool isSoup;

    public bool isSlime;

    public bool isDragon;

    




    public  void CommandCompare_Soup()
    {
        

        if (soup_Command_Database.GetComponent<Soup_Command_DataBase>().GetItemName_SoupCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == commandComparison.GetComponent<ComandComparison>().commandName)
        {
            
            command_Score += 100;
            
           
            //fieldobject.GetComponent<FieldObjectScript>().SetFieldScore((command_Score + 100)/2 );
            
            
        }
        else
        {
            command_Score += 0;
            //fieldobject.GetComponent<FieldObjectScript>().SetFieldScore((command_Score + 0)/2 );

        }

        
    }

    public void CommandCompare_Slime()
    {
        if (soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SoupCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == commandComparison.GetComponent<ComandComparison>().commandName)
        {

            command_Score += 100;


            //fieldobject.GetComponent<FieldObjectScript>().SetFieldScore((command_Score + 100)/2 );


        }
        else
        {
            command_Score += 0;
            //fieldobject.GetComponent<FieldObjectScript>().SetFieldScore((command_Score + 0)/2 );

        }
    }

    public void CommandCompare_Dragon()
    {
        if (soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == commandComparison.GetComponent<ComandComparison>().commandName)
        {

            command_Score += 100;


            //fieldobject.GetComponent<FieldObjectScript>().SetFieldScore((command_Score + 100)/2 );


        }
        else
        {
            command_Score += 0;
            //fieldobject.GetComponent<FieldObjectScript>().SetFieldScore((command_Score + 0)/2 );

        }
    }


    public void CommandScore()
    {
        if (isSoup == true)
        {
            final_Command_Score = command_Score / soup_Command_Database.GetComponent<Soup_Command_DataBase>().HisCount;
        }

        if(isSlime==true)
        {
            final_Command_Score = command_Score / soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount;
        }

        if (isDragon == true)
        {
            final_Command_Score = command_Score / soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount;
        }
        

        fieldobject.GetComponent<FieldObjectScript>().SetFieldScore(fieldobject.GetComponent<FieldObjectScript>().GetFieldScore()+final_Command_Score);

        command_Score = 0;




    }

    public void CommandAnswer_division()
    {
        if (isSoup == true)
        {
            if (soup_Command_Database.GetComponent<Soup_Command_DataBase>().GetItemName_SoupCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == "Cutting_Command")
            {
                commandComparison.GetComponent<ComandComparison>().CommandsAnswer = commandComparison.GetComponent<CommandCollection>().CuttingCommand;
            }

            if (soup_Command_Database.GetComponent<Soup_Command_DataBase>().GetItemName_SoupCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == "Boiling_Down_Command")
            {
                commandComparison.GetComponent<ComandComparison>().CommandsAnswer = commandComparison.GetComponent<CommandCollection>().Boiling_DownCommand;
            }

            if (soup_Command_Database.GetComponent<Soup_Command_DataBase>().GetItemName_SoupCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == "Boiling_Command")
            {
                commandComparison.GetComponent<ComandComparison>().CommandsAnswer = commandComparison.GetComponent<CommandCollection>().BoilingCommand;
            }

            if (soup_Command_Database.GetComponent<Soup_Command_DataBase>().GetItemName_SoupCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == "Chopping_Command")
            {
                commandComparison.GetComponent<ComandComparison>().CommandsAnswer = commandComparison.GetComponent<CommandCollection>().ChoppingCommand;
            }

            if (soup_Command_Database.GetComponent<Soup_Command_DataBase>().GetItemName_SoupCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == "Mash_Command")
            {
                commandComparison.GetComponent<ComandComparison>().CommandsAnswer = commandComparison.GetComponent<CommandCollection>().MashCommand;
            }

            if (soup_Command_Database.GetComponent<Soup_Command_DataBase>().GetItemName_SoupCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == "Spray_Command")
            {
                commandComparison.GetComponent<ComandComparison>().CommandsAnswer = commandComparison.GetComponent<CommandCollection>().SprayCommand;
            }

            if (soup_Command_Database.GetComponent<Soup_Command_DataBase>().GetItemName_SoupCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == "WrapUp_Command")
            {
                commandComparison.GetComponent<ComandComparison>().CommandsAnswer = commandComparison.GetComponent<CommandCollection>().WrapUpCommand;
            }

            if (soup_Command_Database.GetComponent<Soup_Command_DataBase>().GetItemName_SoupCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == "Cut_inInsert_Command")
            {
                Debug.Log("we");
                commandComparison.GetComponent<ComandComparison>().CommandsAnswer = commandComparison.GetComponent<CommandCollection>().Cut_inInsertCommand;
            }

            if (soup_Command_Database.GetComponent<Soup_Command_DataBase>().GetItemName_SoupCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == "Stir_Fry_Command")
            {
                commandComparison.GetComponent<ComandComparison>().CommandsAnswer = commandComparison.GetComponent<CommandCollection>().Stir_fryCommand;
            }

            if (soup_Command_Database.GetComponent<Soup_Command_DataBase>().GetItemName_SoupCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == "Ironing_Command")
            {
                commandComparison.GetComponent<ComandComparison>().CommandsAnswer = commandComparison.GetComponent<CommandCollection>().IroningCommand;
            }

            if (soup_Command_Database.GetComponent<Soup_Command_DataBase>().GetItemName_SoupCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == "Push_Command")
            {
                commandComparison.GetComponent<ComandComparison>().CommandsAnswer = commandComparison.GetComponent<CommandCollection>().PushCommand;
            }
        }

        if(isSlime==true)
        {
            if (soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SoupCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == "Cutting_Command")
            {
                commandComparison.GetComponent<ComandComparison>().CommandsAnswer = commandComparison.GetComponent<CommandCollection>().CuttingCommand;
            }

            if (soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SoupCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == "Boiling_Down_Command")
            {
                commandComparison.GetComponent<ComandComparison>().CommandsAnswer = commandComparison.GetComponent<CommandCollection>().Boiling_DownCommand;
            }

            if (soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SoupCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == "Boiling_Command")
            {
                commandComparison.GetComponent<ComandComparison>().CommandsAnswer = commandComparison.GetComponent<CommandCollection>().BoilingCommand;
            }

            if (soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SoupCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == "Chopping_Command")
            {
                commandComparison.GetComponent<ComandComparison>().CommandsAnswer = commandComparison.GetComponent<CommandCollection>().ChoppingCommand;
            }

            if (soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SoupCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == "Mash_Command")
            {
                commandComparison.GetComponent<ComandComparison>().CommandsAnswer = commandComparison.GetComponent<CommandCollection>().MashCommand;
            }

            if (soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SoupCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == "Spray_Command")
            {
                commandComparison.GetComponent<ComandComparison>().CommandsAnswer = commandComparison.GetComponent<CommandCollection>().SprayCommand;
            }

            if (soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SoupCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == "WrapUp_Command")
            {
                commandComparison.GetComponent<ComandComparison>().CommandsAnswer = commandComparison.GetComponent<CommandCollection>().WrapUpCommand;
            }

            if (soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SoupCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == "Cut_inInsert_Command")
            {
                commandComparison.GetComponent<ComandComparison>().CommandsAnswer = commandComparison.GetComponent<CommandCollection>().Cut_inInsertCommand;
            }

            if (soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SoupCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == "Stir_Fry_Command")
            {
                commandComparison.GetComponent<ComandComparison>().CommandsAnswer = commandComparison.GetComponent<CommandCollection>().Stir_fryCommand;
            }

            if (soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SoupCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == "Ironing_Command")
            {
                commandComparison.GetComponent<ComandComparison>().CommandsAnswer = commandComparison.GetComponent<CommandCollection>().IroningCommand;
            }

            if (soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SoupCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == "Push_Command")
            {
                commandComparison.GetComponent<ComandComparison>().CommandsAnswer = commandComparison.GetComponent<CommandCollection>().PushCommand;
            }
        }
        if (isDragon == true)
        {
            if (soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == "Cutting_Command")
            {
                commandComparison.GetComponent<ComandComparison>().CommandsAnswer = commandComparison.GetComponent<CommandCollection>().CuttingCommand;
            }

            if (soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == "Boiling_Down_Command")
            {
                commandComparison.GetComponent<ComandComparison>().CommandsAnswer = commandComparison.GetComponent<CommandCollection>().Boiling_DownCommand;
            }

            if (soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == "Boiling_Command")
            {
                commandComparison.GetComponent<ComandComparison>().CommandsAnswer = commandComparison.GetComponent<CommandCollection>().BoilingCommand;
            }

            if (soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == "Chopping_Command")
            {
                commandComparison.GetComponent<ComandComparison>().CommandsAnswer = commandComparison.GetComponent<CommandCollection>().ChoppingCommand;
            }

            if (soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == "Mash_Command")
            {
                commandComparison.GetComponent<ComandComparison>().CommandsAnswer = commandComparison.GetComponent<CommandCollection>().MashCommand;
            }

            if (soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == "Spray_Command")
            {
                commandComparison.GetComponent<ComandComparison>().CommandsAnswer = commandComparison.GetComponent<CommandCollection>().SprayCommand;
            }

            if (soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == "WrapUp_Command")
            {
                commandComparison.GetComponent<ComandComparison>().CommandsAnswer = commandComparison.GetComponent<CommandCollection>().WrapUpCommand;
            }

            if (soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == "Cut_inInsert_Command")
            {
                commandComparison.GetComponent<ComandComparison>().CommandsAnswer = commandComparison.GetComponent<CommandCollection>().Cut_inInsertCommand;
            }

            if (soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == "Stir_Fry_Command")
            {
                commandComparison.GetComponent<ComandComparison>().CommandsAnswer = commandComparison.GetComponent<CommandCollection>().Stir_fryCommand;
            }

            if (soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == "Ironing_Command")
            {
                commandComparison.GetComponent<ComandComparison>().CommandsAnswer = commandComparison.GetComponent<CommandCollection>().IroningCommand;
            }

            if (soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(CompareActiveAnswer.GetComponent<CompareActiveAnswer>().command_All_Count) == "Push_Command")
            {
                commandComparison.GetComponent<ComandComparison>().CommandsAnswer = commandComparison.GetComponent<CommandCollection>().PushCommand;
            }
        }       

    }

    public void Command_checking()
    {
        Debug.Log(commandComparison.GetComponent<ComandComparison>().commandName);
        if (commandComparison.GetComponent<ComandComparison>().commandName == "Cutting_Command")
        {
            player_animator.SetBool("Cutting", true);
        }
        if (commandComparison.GetComponent<ComandComparison>().commandName == "Boiling_Down_Command")
        {
            player_animator.SetBool("Boiling_Down", true);
        }
        if (commandComparison.GetComponent<ComandComparison>().commandName == "Boiling_Command")
        {
            player_animator.SetBool("Boiling", true);
        }
        if (commandComparison.GetComponent<ComandComparison>().commandName == "Chopping_Command")
        {
            player_animator.SetBool("Chopping", true);
        }
        if (commandComparison.GetComponent<ComandComparison>().commandName == "Mash_Command")
        {
            player_animator.SetBool("Mash", true);
        }
        if (commandComparison.GetComponent<ComandComparison>().commandName == "Spray_Command")
        {
            player_animator.SetBool("Spray", true);
        }
        if (commandComparison.GetComponent<ComandComparison>().commandName == "WrapUp_Command")
        {
            player_animator.SetBool("WrapUp", true);
        }
        if (commandComparison.GetComponent<ComandComparison>().commandName == "Cut_inInsert_Command")
        {
            player_animator.SetBool("Cut_inInsert", true);
        }
        if (commandComparison.GetComponent<ComandComparison>().commandName == "Stir_Fry_Command")
        {
            player_animator.SetBool("Stir_Fry", true);
        }
        if (commandComparison.GetComponent<ComandComparison>().commandName == "Ironing_Command")
        {
            player_animator.SetBool("Ironing", true);
        }
        if (commandComparison.GetComponent<ComandComparison>().commandName == "Push_Command")
        {
            player_animator.SetBool("Push", true);
        }

    }




}

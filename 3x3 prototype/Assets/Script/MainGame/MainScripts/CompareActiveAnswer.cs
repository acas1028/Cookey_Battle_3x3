using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompareActiveAnswer : MonoBehaviour
{
    public GameObject fieldObject;
    public GameObject gameFinishObject;

    public GameObject SoundBox;

    public GameObject compare_score;

    public GameObject movetag;

    public GameObject keyboardinput;

    public GameObject commandbar;

    public GameObject inventory;

    public GameObject inventoryandcommanbarSwitch;

    public GameObject CommandComparison;

    public GameObject Soup_Command_Database;

    public GameObject commandCompare;

    public GameObject ShowMakingIngredient;

    public GameObject block;

    public GameObject timer;

    public GameObject player_Anime;

    public GameObject[] score_compare_basic_instance;

    public GameObject[] score_compare_instance;

    public GameObject[] Making_Ingredients;

    public GameObject[] hiddenMaking_Ingredients;

    public GameObject[] Making_Ingredients_Moving;

    public GameObject[] hiddenMaking_Ingredients_Moving;

    public GameObject[] InventorySlot;

    public GameObject dataGameManager;

    public GameObject maingame_inventory;

    public GameObject command_manager;

    public GameObject commandboard_recipe_Input;

    public int Ingredient_Count = 0;

    public int making_Count = 0;

    public int hiddentmaking_Count = 0;

    public int score_compare_cal = 0;

    public int command_All_Count = 0;

    public int isHiddentCount = 0;

    public int hiddentIngredientCount = 0;

    public Item_list item_List;

    public List<GameObject> basic_instance;

    public bool inventoryonoff = false;

    public bool isPossibleDestroy = false;

    public bool iscommandStart = false;

    public bool isinventoryStart = false;

    public bool isInventoryOk = false;

    public bool anim_call = false;

    public bool isComplete = false;

    public bool putAnimeOk = false;



    int ingameStage;
    int ingameStep;
    int hiddenConditionNumber; //히든 아이템 갯수
    int hiddenCount; // 히든 아이템 사용 횟수


    void Start()
    {
        ingameStage = GameManager.instance.GetStageLevel();
        ingameStep = 0;
        hiddenCount = 0;
        movetag.GetComponent<Find_tag>();

        

        //for(int i=0;i< score_compare_basic_instance.Length; i++)
        //{
        //    basic_instance.Add(score_compare_basic_instance[i]);
        //}


        switch (ingameStage)
        {
            case 1:
                hiddenConditionNumber = 4;
                break;
            case 2:
                hiddenConditionNumber = 9;
                break;
            case 3:
                hiddenConditionNumber = 9;
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hiddenCount);
        
        if (InventorySlot.Length == 0)
        {
            InventorySlot = GameObject.FindGameObjectsWithTag("Slot"); //문제가 생길시 고침
        }
        if (movetag.GetComponent<WareHouseInventoryScript>().WareHouseDestroy == 1 && inventoryonoff==false)
        {
            
            score_compare_basic_instance = maingame_inventory.GetComponent<Inventory_clone_on>().inventory_clone;

            for (int i = 0; i < score_compare_basic_instance.Length; i++)
            {
                basic_instance.Add(score_compare_basic_instance[i]);
            }
            inventoryonoff = true;
        }

        for(int i=0; i<basic_instance.Count;i++)
        {
            if(basic_instance[i] == null)
            {
                basic_instance.RemoveAt(i);
            }
        }

        if(putAnimeOk==true && EndAnimationDone()==true)
        {
            player_Anime.GetComponent<Animator>().SetInteger("States", 0);
            putAnimeOk = false;
            
        }

        switch (ingameStage)
        {
            case 1:
                CompareAnswer_Stage1(ingameStep);
                break;
            case 2:
                CompareAnswer_Stage2(ingameStep);
                break;
            case 3:
                CompareAnswer_Stage3(ingameStep);
                break;
        }
    }

    void CompareAnswer_Stage1(int step)  // 예를들어 스텝 7이 끝
    {
        
        switch(step)
        {
            case 1:
                {
                    anim_call = true;
                    for (int j = 0; j < basic_instance.Count; j++)
                    {
                        
                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {
                            
                            
                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {
                                    
                                    
                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();                                                                    
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                        
                                  
                                 
                                    
                                }
                            }
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.F1))
                    {
                        ingameStep++;
                        hiddenCount++;
                    }
                }
                break;
            
            
            case 2:
                {
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf==true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    iscommandStart = true;
                                }
                            }
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Alpha2))
                        ingameStep++;
                    else if (Input.GetKeyDown(KeyCode.F1))
                    {
                        ingameStep++;
                        hiddenCount++;
                    }
                }
                break;
            case 3:
                {
                    if(iscommandStart==true)
                    {
                        keyboardinput.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = true;
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Soup_Command_DataBase>().GetItemName_SoupCommand_Count(Soup_Command_Database.GetComponent<Soup_Command_DataBase>().GetItemName_SoupCommand(command_All_Count));
                        
                    }

                    //for (int i = 1; i < 5; i++)
                    //{
                    //    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == i)
                    //    {
                    //        commandCompare.GetComponent<CommandCompare>().Command_checking();
                    //    }
                    //}

                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Soup_Command_DataBase>().HisCount && Soup_Command_Database.GetComponent<Soup_Command_DataBase>().HisCount != 0 && command_manager.GetComponent<InputCommand>().clear_command == true)
                    {

                        commandbar.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = false;
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().starting_command_Count = 0;
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        isInventoryOk = true;
                        timer.GetComponent<Timer>().timer = 0;
                        command_All_Count++;
                        ingameStep++;
                        command_manager.GetComponent<InputCommand>().clear_command = false;

                    }

                       

                    //    for (int j = 0; j < basic_instance.Count; j++)
                    //{

                    //    if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                    //    {

                    //        for (int i = 0; i < basic_instance.Count; i++)
                    //        {
                    //            if (basic_instance[i].activeSelf == true)
                    //            {

                    //                compare_score = basic_instance[i];
                    //                compare_score.GetComponent<DataMove>().Name_Compare();
                    //                ingameStep++;
                    //                isPossibleDestroy = true;
                    //            }
                    //        }
                    //    }
                    //}

                    if (Input.GetKeyDown(KeyCode.Alpha3))
                        ingameStep++;
                    else if (Input.GetKeyDown(KeyCode.F1))
                    {
                        ingameStep++;
                        hiddenCount++;
                    }
                }
                break;
            case 4:
                {
                    commandCompare.GetComponent<CommandCompare>().player_animator.SetInteger("States", 0);
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    
                                }
                            }
                        }
                    }
                    

                    if (Input.GetKeyDown(KeyCode.Alpha4))
                        ingameStep++;
                }
                break;
            case 5:
                {
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    compare_score.GetComponent<DataMove>().Hidden_Name_Comapare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    hiddentIngredientCount++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);

                                }
                            }
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.Alpha5))
                        ingameStep++;
                }
                break;
            case 6:
                {
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    iscommandStart = true;

                                }
                            }
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.Alpha6))
                        ingameStep++;
                }
                break;
            case 7:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = true;
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Soup_Command_DataBase>().GetItemName_SoupCommand_Count(Soup_Command_Database.GetComponent<Soup_Command_DataBase>().GetItemName_SoupCommand(command_All_Count));

                    }

                    //for (int i = 1; i < 3; i++)
                    //{
                    //    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == i)
                    //    {
                    //        commandCompare.GetComponent<CommandCompare>().Command_checking();
                    //    }
                    //}

                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Soup_Command_DataBase>().HisCount && Soup_Command_Database.GetComponent<Soup_Command_DataBase>().HisCount != 0 && command_manager.GetComponent<InputCommand>().clear_command == true)
                    {

                        commandbar.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = false;
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().starting_command_Count = 0;
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        isInventoryOk = true;
                        timer.GetComponent<Timer>().timer = 0;
                        command_All_Count++;
                        ingameStep++;
                        command_manager.GetComponent<InputCommand>().clear_command = false;
                    }

                    if (Input.GetKeyDown(KeyCode.Alpha7))
                    {
                        ingameStep++;

                        gameFinishObject.SetActive(true);
                    }
                }
                break;
            case 8:
                {
                    commandCompare.GetComponent<CommandCompare>().player_animator.SetInteger("States", 0);
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);

                                }
                            }
                        }
                    }

                }
                break;
            case 9:
                {
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    compare_score.GetComponent<DataMove>().Hidden_Name_Comapare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    hiddentIngredientCount++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    iscommandStart = true;

                                }
                            }
                        }
                    }

                }
                break;
            case 10:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = true;
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Soup_Command_DataBase>().GetItemName_SoupCommand_Count(Soup_Command_Database.GetComponent<Soup_Command_DataBase>().GetItemName_SoupCommand(command_All_Count));

                    }

                    //for (int i = 1; i < 2; i++)
                    //{
                    //    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == i)
                    //    {
                    //        commandCompare.GetComponent<CommandCompare>().Command_checking();
                    //    }
                    //}

                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Soup_Command_DataBase>().HisCount && Soup_Command_Database.GetComponent<Soup_Command_DataBase>().HisCount != 0 && command_manager.GetComponent<InputCommand>().clear_command == true)
                    {

                        commandbar.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = false;
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().starting_command_Count = 0;
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        isInventoryOk = true;
                        timer.GetComponent<Timer>().timer = 0;
                        command_All_Count++;
                        ingameStep++;
                        command_manager.GetComponent<InputCommand>().clear_command = false;
                    }
                }
                break;
            case 11:
                {
                    commandCompare.GetComponent<CommandCompare>().player_animator.SetInteger("States", 0);
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {
                                    isHiddentCount = 0;
                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    compare_score.GetComponent<DataMove>().Hidden_Name_Comapare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    hiddentIngredientCount++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    iscommandStart = true;

                                }
                            }
                        }
                    }

                }
                break;

            case 12:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = true;
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Soup_Command_DataBase>().GetItemName_SoupCommand_Count(Soup_Command_Database.GetComponent<Soup_Command_DataBase>().GetItemName_SoupCommand(command_All_Count));

                    }

                    //for (int i = 1; i < 6; i++)
                    //{
                    //    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == i)
                    //    {
                    //        commandCompare.GetComponent<CommandCompare>().Command_checking();
                    //    }
                    //}

                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Soup_Command_DataBase>().HisCount && Soup_Command_Database.GetComponent<Soup_Command_DataBase>().HisCount != 0 && command_manager.GetComponent<InputCommand>().clear_command == true)
                    {

                        commandbar.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = false;
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().starting_command_Count = 0;
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        if (isHiddentCount == 0)
                        {
                            Making_ingredient();
                        }

                        else if(isHiddentCount==1)
                        {
                            HiddentMaking_Ingredient();
                            isHiddentCount = 0;
                        }
                        isInventoryOk = true;
                        timer.GetComponent<Timer>().timer = 0;
                        command_All_Count++;
                        ingameStep++;
                        command_manager.GetComponent<InputCommand>().clear_command = false;
                    }
                }
                break;

            case 13:
                {
                    commandCompare.GetComponent<CommandCompare>().player_animator.SetInteger("States", 0);
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    
                                    

                                }
                            }
                        }
                    }

                }
                break;

            case 14:
                {
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    compare_score.GetComponent<DataMove>().Hidden_Name_Comapare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    hiddentIngredientCount++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    iscommandStart = true;


                                }
                            }
                        }
                    }

                }
                break;
            case 15:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = true;
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Soup_Command_DataBase>().GetItemName_SoupCommand_Count(Soup_Command_Database.GetComponent<Soup_Command_DataBase>().GetItemName_SoupCommand(command_All_Count));

                    }

                    //for (int i = 1; i < 6; i++)
                    //{
                    //    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == i)
                    //    {
                    //        commandCompare.GetComponent<CommandCompare>().Command_checking();
                    //    }
                    //}

                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Soup_Command_DataBase>().HisCount && Soup_Command_Database.GetComponent<Soup_Command_DataBase>().HisCount != 0 && command_manager.GetComponent<InputCommand>().clear_command == true)
                    {

                        commandbar.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = false;
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().starting_command_Count = 0;
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        isComplete = true;
                        Making_ingredient();
                        isInventoryOk = true;
                        isComplete = false;
                        timer.GetComponent<Timer>().timer = 0;
                        command_All_Count++;
                        ingameStep++;
                        command_manager.GetComponent<InputCommand>().clear_command = false;
                    }
                }
                break;
            case 16:
                {
                    commandCompare.GetComponent<CommandCompare>().player_animator.SetInteger("States", 0);
                    ingameStep++;
                    command_All_Count = 0;
                    making_Count = 0;
                    hiddentIngredientCount = 0;
                    hiddentmaking_Count = 0;
                   
                    //hidden으로 가는 법?


                    gameFinishObject.SetActive(true);
                }
                break;

        }
    }

    void CompareAnswer_Stage2(int step)     // 13
    {
        switch (step)
        {
            case 1:
                {
                    anim_call = true;
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    compare_score.GetComponent<DataMove>().Hidden_Name_Comapare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    hiddentIngredientCount++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    iscommandStart = true;



                                }
                            }
                        }
                    }
                }
                break;
            case 2:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = true;
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SlimeCommand_Count(Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SoupCommand(command_All_Count));

                    }

                    //for (int i = 1; i < 6; i++)
                    //{
                    //    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == i)
                    //    {
                    //        commandCompare.GetComponent<CommandCompare>().Command_checking();
                    //    }
                    //}

                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount && Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount != 0 && command_manager.GetComponent<InputCommand>().clear_command == true)
                    {

                        commandbar.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = false;
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().starting_command_Count = 0;
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        if (isHiddentCount == 0)
                        {
                            Making_ingredient();
                        }

                        else if (isHiddentCount == 1)
                        {
                            HiddentMaking_Ingredient();
                            isHiddentCount = 0;
                            making_Count++;
                        }
                        isInventoryOk = true;
                        timer.GetComponent<Timer>().timer = 0;
                        command_All_Count++;
                        ingameStep++;
                        command_manager.GetComponent<InputCommand>().clear_command = false;
                    }
                }
                break;
            case 3:
                {
                    commandCompare.GetComponent<CommandCompare>().player_animator.SetInteger("States", 0);
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    compare_score.GetComponent<DataMove>().Hidden_Name_Comapare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    hiddentIngredientCount++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    



                                }
                            }
                        }
                    }
                }

                break;

            case 4:
                {
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    iscommandStart = true;



                                }
                            }
                        }
                    }
                }
                break;
            case 5:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = true;
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SlimeCommand_Count(Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SoupCommand(command_All_Count));

                    }

                    //for (int i = 1; i < 6; i++)
                    //{
                    //    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == i)
                    //    {
                    //        commandCompare.GetComponent<CommandCompare>().Command_checking();
                    //    }
                    //}

                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount && Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount != 0 && command_manager.GetComponent<InputCommand>().clear_command == true)
                    {

                        commandbar.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = false;
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().starting_command_Count = 0;
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        if (isHiddentCount == 0)
                        {
                            Making_ingredient();
                        }

                        else if (isHiddentCount == 1)
                        {
                            HiddentMaking_Ingredient();
                            isHiddentCount = 0;
                            making_Count++;
                        }
                        isInventoryOk = true;
                        timer.GetComponent<Timer>().timer = 0;
                        command_All_Count++;
                        ingameStep++;
                        command_manager.GetComponent<InputCommand>().clear_command = false;
                    }
                }
                break;
            case 6:
                {
                    commandCompare.GetComponent<CommandCompare>().player_animator.SetInteger("States", 0);
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    compare_score.GetComponent<DataMove>().Hidden_Name_Comapare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    hiddentIngredientCount++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                   



                                }
                            }
                        }
                    }
                }
                break;
            case 7:
                {
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    compare_score.GetComponent<DataMove>().Hidden_Name_Comapare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    hiddentIngredientCount++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    iscommandStart = true;



                                }
                            }
                        }
                    }
                }
                break;
            case 8:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = true;
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SlimeCommand_Count(Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SoupCommand(command_All_Count));

                    }

                    //for (int i = 1; i < 3; i++)
                    //{
                    //    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == i)
                    //    {
                    //        commandCompare.GetComponent<CommandCompare>().Command_checking();
                    //    }
                    //}

                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount && Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount != 0 && command_manager.GetComponent<InputCommand>().clear_command == true)
                    {

                        commandbar.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = false;
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().starting_command_Count = 0;
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        if (isHiddentCount == 0)
                        {
                            Making_ingredient();
                        }

                        else if (isHiddentCount == 1)
                        {
                            HiddentMaking_Ingredient();
                            isHiddentCount = 0;
                            making_Count++;
                        }
                        isInventoryOk = true;
                        timer.GetComponent<Timer>().timer = 0;
                        command_All_Count++;
                        ingameStep++;
                        command_manager.GetComponent<InputCommand>().clear_command = false;
                    }
                }
                break;
            case 9:
                {
                    commandCompare.GetComponent<CommandCompare>().player_animator.SetInteger("States", 0);
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    compare_score.GetComponent<DataMove>().Hidden_Name_Comapare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    hiddentIngredientCount++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    iscommandStart = true;



                                }
                            }
                        }
                    }
                }
                break;
            case 10:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = true;
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SlimeCommand_Count(Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SoupCommand(command_All_Count));

                    }

                    //for (int i = 1; i < 9; i++)
                    //{
                    //    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == i)
                    //    {
                    //        commandCompare.GetComponent<CommandCompare>().Command_checking();
                    //    }
                    //}

                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount && Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount != 0 && command_manager.GetComponent<InputCommand>().clear_command == true)
                    {

                        commandbar.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = false;
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().starting_command_Count = 0;
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        if (isHiddentCount == 0)
                        {
                            Making_ingredient();
                        }

                        else if (isHiddentCount == 1)
                        {
                            HiddentMaking_Ingredient();
                            isHiddentCount = 0;
                            making_Count++;
                        }
                        isInventoryOk = true;
                        timer.GetComponent<Timer>().timer = 0;
                        command_All_Count++;
                        ingameStep++;
                        command_manager.GetComponent<InputCommand>().clear_command = false;
                    }
                }
                break;
            case 11:
                {
                    commandCompare.GetComponent<CommandCompare>().player_animator.SetInteger("States", 0);
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    iscommandStart = true;



                                }
                            }
                        }
                    }
                }
                break;
            case 12:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = true;
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SlimeCommand_Count(Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SoupCommand(command_All_Count));

                    }

                    //for (int i = 1; i < 6; i++)
                    //{
                    //    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == i)
                    //    {
                    //        commandCompare.GetComponent<CommandCompare>().Command_checking();
                    //    }
                    //}

                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount && Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount != 0 && command_manager.GetComponent<InputCommand>().clear_command == true)
                    {

                        commandbar.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = false;
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().starting_command_Count = 0;
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        isInventoryOk = true;
                        timer.GetComponent<Timer>().timer = 0;
                        command_All_Count++;
                        ingameStep++;
                        command_manager.GetComponent<InputCommand>().clear_command = false;
                    }
                }
                break;
            case 13:
                {
                    commandCompare.GetComponent<CommandCompare>().player_animator.SetInteger("States", 0);
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);




                                }
                            }
                        }
                    }
                }
                break;
            case 14:
                {
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    compare_score.GetComponent<DataMove>().Hidden_Name_Comapare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    hiddentIngredientCount++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);




                                }
                            }
                        }
                    }
                }
                break;

            case 15:
                {
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    iscommandStart = true;




                                }
                            }
                        }
                    }
                }
                break;

            case 16:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = true;
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SlimeCommand_Count(Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SoupCommand(command_All_Count));

                    }

                    //for (int i = 1; i < 3; i++)
                    //{
                    //    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == i)
                    //    {
                    //        commandCompare.GetComponent<CommandCompare>().Command_checking();
                    //    }
                    //}

                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount && Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount != 0 && command_manager.GetComponent<InputCommand>().clear_command == true)
                    {

                        commandbar.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = false;
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().starting_command_Count = 0;
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        if (isHiddentCount == 0)
                        {
                            Making_ingredient();
                        }

                        else if (isHiddentCount == 1)
                        {
                            HiddentMaking_Ingredient();
                            isHiddentCount = 0;
                            making_Count++;
                        }
                        isInventoryOk = true;
                        timer.GetComponent<Timer>().timer = 0;
                        command_All_Count++;
                        ingameStep++;
                        command_manager.GetComponent<InputCommand>().clear_command = false;
                    }
                }
                break;
            case 17:
                {
                    commandCompare.GetComponent<CommandCompare>().player_animator.SetInteger("States", 0);
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    iscommandStart = true;




                                }
                            }
                        }
                    }
                }
                break;

            case 18:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = true;
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SlimeCommand_Count(Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SoupCommand(command_All_Count));

                    }

                    //for (int i = 1; i < 9; i++)
                    //{
                    //    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == i)
                    //    {
                    //        commandCompare.GetComponent<CommandCompare>().Command_checking();
                    //    }
                    //}

                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount && Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount != 0 && command_manager.GetComponent<InputCommand>().clear_command == true)
                    {

                        commandbar.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = false;
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().starting_command_Count = 0;
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        isInventoryOk = true;
                        timer.GetComponent<Timer>().timer = 0;
                        command_All_Count++;
                        ingameStep++;
                        command_manager.GetComponent<InputCommand>().clear_command = false;
                    }
                }
                break;
            case 19:
                {
                    commandCompare.GetComponent<CommandCompare>().player_animator.SetInteger("States", 0);
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    iscommandStart = true;




                                }
                            }
                        }
                    }
                }
                break;
            case 20:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = true;
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SlimeCommand_Count(Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SoupCommand(command_All_Count));

                    }

                    //for (int i = 1; i < 9; i++)
                    //{
                    //    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == i)
                    //    {
                    //        commandCompare.GetComponent<CommandCompare>().Command_checking();
                    //    }
                    //}

                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount && Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount != 0 && command_manager.GetComponent<InputCommand>().clear_command == true)
                    {

                        commandbar.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = false;
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().starting_command_Count = 0;
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;                       
                        Making_ingredient();                     
                        isInventoryOk = true;
                        timer.GetComponent<Timer>().timer = 0;
                        command_All_Count++;
                        ingameStep++;
                        command_manager.GetComponent<InputCommand>().clear_command = false;
                    }
                }
                break;
            case 21:
                {
                    commandCompare.GetComponent<CommandCompare>().player_animator.SetInteger("States", 0);
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    compare_score.GetComponent<DataMove>().Hidden_Name_Comapare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    hiddentIngredientCount++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    iscommandStart = true;




                                }
                            }
                        }
                    }
                }
                break;
            case 22:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = true;
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SlimeCommand_Count(Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SoupCommand(command_All_Count));

                    }

                    //for (int i = 1; i < 9; i++)
                    //{
                    //    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == i)
                    //    {
                    //        commandCompare.GetComponent<CommandCompare>().Command_checking();
                    //    }
                    //}

                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount && Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount != 0 && command_manager.GetComponent<InputCommand>().clear_command == true)
                    {

                        commandbar.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = false;
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().starting_command_Count = 0;
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        if (isHiddentCount == 0)
                        {
                            Making_ingredient();
                        }

                        else if (isHiddentCount == 1)
                        {
                            HiddentMaking_Ingredient();
                            isHiddentCount = 0;
                            making_Count++;
                        }
                        isInventoryOk = true;
                        timer.GetComponent<Timer>().timer = 0;
                        command_All_Count++;
                        ingameStep++;
                        command_manager.GetComponent<InputCommand>().clear_command = false;
                    }
                }
                break;
            case 23:
                {
                    commandCompare.GetComponent<CommandCompare>().player_animator.SetInteger("States", 0);
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);




                                }
                            }
                        }
                    }
                }
                break;
            case 24:
                {
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                   




                                }
                            }
                        }
                    }
                }
                break;
            case 25:
                {
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    compare_score.GetComponent<DataMove>().Hidden_Name_Comapare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    hiddentIngredientCount++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    




                                }
                            }
                        }
                    }
                }
                break;
            
            case 26:
                {
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    compare_score.GetComponent<DataMove>().Hidden_Name_Comapare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    hiddentIngredientCount++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);




                                }
                            }
                        }
                    }
                }
                break;
            case 27:
                {
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    compare_score.GetComponent<DataMove>().Hidden_Name_Comapare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    hiddentIngredientCount++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);




                                }
                            }
                        }
                    }

                }
                break;
            case 28:
                {
                    commandCompare.GetComponent<CommandCompare>().player_animator.SetInteger("States", 0);
                    ingameStep++;
                    command_All_Count = 0;
                    making_Count = 0;
                    hiddentIngredientCount = 0;
                    hiddentmaking_Count = 0;
                    //hidden으로 가는 법?


                    

                    gameFinishObject.SetActive(true);
                }
                break;

            


        }
    }

    void CompareAnswer_Stage3(int step)     // 15
    {
        switch (step)
        {
            case 1:
                {
                    anim_call = true;
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    iscommandStart = true;




                                }
                            }
                        }
                    }

                }
                break;
            case 2:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = true;
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand_Count(Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(command_All_Count));

                    }

                    //for (int i = 1; i < 6; i++)
                    //{
                    //    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == i)
                    //    {
                    //        commandCompare.GetComponent<CommandCompare>().Command_checking();
                    //    }
                    //}

                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount && Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount != 0 && command_manager.GetComponent<InputCommand>().clear_command == true)
                    {

                        commandbar.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = false;
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().starting_command_Count = 0;
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        isInventoryOk = true;
                        timer.GetComponent<Timer>().timer = 0;
                        command_All_Count++;
                        ingameStep++;
                        command_manager.GetComponent<InputCommand>().clear_command = false;
                    }
                }
                break;
            case 3:
                {
                    commandCompare.GetComponent<CommandCompare>().player_animator.SetInteger("States", 0);
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);




                                }
                            }
                        }
                    }
                }
                break;
            case 4:
                {
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);




                                }
                            }
                        }
                    }
                }
                break;
            case 5:
                {
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    iscommandStart = true;




                                }
                            }
                        }
                    }
                }
                break;
            case 6:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = true;
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand_Count(Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(command_All_Count));

                    }

                    //for (int i = 1; i < 6; i++)
                    //{
                    //    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == i)
                    //    {
                    //        commandCompare.GetComponent<CommandCompare>().Command_checking();
                    //    }
                    //}

                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount && Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount != 0 && command_manager.GetComponent<InputCommand>().clear_command == true)
                    {

                        commandbar.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = false;
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().starting_command_Count = 0;
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        isInventoryOk = true;
                        timer.GetComponent<Timer>().timer = 0;
                        command_All_Count++;
                        ingameStep++;
                        command_manager.GetComponent<InputCommand>().clear_command = false;
                    }
                }
                break;
            case 7:
                {
                    commandCompare.GetComponent<CommandCompare>().player_animator.SetInteger("States", 0);
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    compare_score.GetComponent<DataMove>().Hidden_Name_Comapare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    hiddentIngredientCount++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    iscommandStart = true;




                                }
                            }
                        }
                    }
                }
                break;
            case 8:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = true;
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand_Count(Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(command_All_Count));

                    }

                    //for (int i = 1; i < 6; i++)
                    //{
                    //    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == i)
                    //    {
                    //        commandCompare.GetComponent<CommandCompare>().Command_checking();
                    //    }
                    //}

                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount && Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount != 0 && command_manager.GetComponent<InputCommand>().clear_command == true)
                    {

                        commandbar.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = false;
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().starting_command_Count = 0;
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        if (isHiddentCount == 0)
                        {
                            Making_ingredient();
                        }

                        else if (isHiddentCount == 1)
                        {
                            HiddentMaking_Ingredient();
                            isHiddentCount = 0;
                            making_Count++;
                        }
                        isInventoryOk = true;
                        timer.GetComponent<Timer>().timer = 0;
                        command_All_Count++;
                        ingameStep++;
                        command_manager.GetComponent<InputCommand>().clear_command = false;
                    }
                }
                break;
            case 9:
                {
                    commandCompare.GetComponent<CommandCompare>().player_animator.SetInteger("States", 0);
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    compare_score.GetComponent<DataMove>().Hidden_Name_Comapare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    hiddentIngredientCount++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);




                                }
                            }
                        }
                    }
                }
                break;
            case 10:
                {
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    compare_score.GetComponent<DataMove>().Hidden_Name_Comapare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    hiddentIngredientCount++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);




                                }
                            }
                        }
                    }
                }
                break;
            case 11:
                {
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    iscommandStart = true;




                                }
                            }
                        }
                    }
                }
                break;
            case 12:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = true;
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand_Count(Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(command_All_Count));

                    }

                    //for (int i = 1; i < 3; i++)
                    //{
                    //    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == i)
                    //    {
                    //        commandCompare.GetComponent<CommandCompare>().Command_checking();
                    //    }
                    //}

                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount && Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount != 0 && command_manager.GetComponent<InputCommand>().clear_command == true)
                    {

                        commandbar.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = false;
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().starting_command_Count = 0;
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        if (isHiddentCount == 0)
                        {
                            Making_ingredient();
                        }

                        else if (isHiddentCount == 2)
                        {
                            HiddentMaking_Ingredient();
                            isHiddentCount = 0;
                            making_Count++;
                        }
                        isInventoryOk = true;
                        timer.GetComponent<Timer>().timer = 0;
                        command_All_Count++;
                        ingameStep++;
                        command_manager.GetComponent<InputCommand>().clear_command = false;
                    }
                }
                break;
            case 13:
                {
                    commandCompare.GetComponent<CommandCompare>().player_animator.SetInteger("States", 0);
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    compare_score.GetComponent<DataMove>().Hidden_Name_Comapare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    hiddentIngredientCount++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    iscommandStart = true;




                                }
                            }
                        }
                    }

                }
                break;
            case 14:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = true;
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand_Count(Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(command_All_Count));

                    }

                    //for (int i = 1; i < 9; i++)
                    //{
                    //    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == i)
                    //    {
                    //        commandCompare.GetComponent<CommandCompare>().Command_checking();
                    //    }
                    //}

                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount && Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount != 0 && command_manager.GetComponent<InputCommand>().clear_command == true)
                    {

                        commandbar.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = false;
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().starting_command_Count = 0;
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        if (isHiddentCount == 0)
                        {
                            Making_ingredient();
                        }

                        else if (isHiddentCount == 1)
                        {
                            HiddentMaking_Ingredient();
                            isHiddentCount = 0;
                            making_Count++;
                        }
                        isInventoryOk = true;
                        timer.GetComponent<Timer>().timer = 0;
                        command_All_Count++;
                        ingameStep++;
                        command_manager.GetComponent<InputCommand>().clear_command = false;
                    }
                }
                break;
            case 15:
                {
                    commandCompare.GetComponent<CommandCompare>().player_animator.SetInteger("States", 0);
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    



                                }
                            }
                        }
                    }
                }
                break;
            case 16:
                {
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    compare_score.GetComponent<DataMove>().Hidden_Name_Comapare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    hiddentIngredientCount++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    iscommandStart = true;




                                }
                            }
                        }
                    }
                }
                break;
            case 17:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = true;
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand_Count(Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(command_All_Count));

                    }

                    //for (int i = 1; i < 3; i++)
                    //{
                    //    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == i)
                    //    {
                    //        commandCompare.GetComponent<CommandCompare>().Command_checking();
                    //    }
                    //}

                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount && Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount != 0 && command_manager.GetComponent<InputCommand>().clear_command == true)
                    {

                        commandbar.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = false;
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().starting_command_Count = 0;
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        if (isHiddentCount == 0)
                        {
                            Making_ingredient();
                        }

                        else if (isHiddentCount == 1)
                        {
                            HiddentMaking_Ingredient();
                            isHiddentCount = 0;
                            making_Count++;
                        }
                        isInventoryOk = true;
                        timer.GetComponent<Timer>().timer = 0;
                        command_All_Count++;
                        ingameStep++;
                        command_manager.GetComponent<InputCommand>().clear_command = false;
                    }
                }
                break;
            case 18:
                {
                    commandCompare.GetComponent<CommandCompare>().player_animator.SetInteger("States", 0);
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    




                                }
                            }
                        }
                    }
                }
                break;
            case 19:
                {
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);





                                }
                            }
                        }
                    }
                }
                break;
            case 20:
                {
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    compare_score.GetComponent<DataMove>().Hidden_Name_Comapare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    hiddentIngredientCount++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);





                                }
                            }
                        }
                    }
                }
                break;
            case 21:
                {
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    compare_score.GetComponent<DataMove>().Hidden_Name_Comapare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    hiddentIngredientCount++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    iscommandStart = true;




                                }
                            }
                        }
                    }
                }
                break;
            case 22:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = true;
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand_Count(Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(command_All_Count));

                    }

                    //for (int i = 1; i < 3; i++)
                    //{
                    //    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == i)
                    //    {
                    //        commandCompare.GetComponent<CommandCompare>().Command_checking();
                    //    }
                    //}

                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount && Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount != 0 && command_manager.GetComponent<InputCommand>().clear_command == true)
                    {

                        commandbar.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = false;
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().starting_command_Count = 0;
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        if (isHiddentCount == 0)
                        {
                            Making_ingredient();
                        }

                        else if (isHiddentCount == 2)
                        {
                            HiddentMaking_Ingredient();
                            isHiddentCount = 0;
                            making_Count++;
                        }
                        isInventoryOk = true;
                        timer.GetComponent<Timer>().timer = 0;
                        command_All_Count++;
                        ingameStep++;
                        command_manager.GetComponent<InputCommand>().clear_command = false;
                    }
                }
                break;

            case 23:
                {
                    commandCompare.GetComponent<CommandCompare>().player_animator.SetInteger("States", 0);
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    iscommandStart = true;




                                }
                            }
                        }
                    }

                }
                break;

            case 24:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = true;
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand_Count(Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(command_All_Count));

                    }

                    //for (int i = 1; i < 3; i++)
                    //{
                    //    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == i)
                    //    {
                    //        commandCompare.GetComponent<CommandCompare>().Command_checking();
                    //    }
                    //}

                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount && Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount != 0 && command_manager.GetComponent<InputCommand>().clear_command == true)
                    {

                        commandbar.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = false;
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().starting_command_Count = 0;
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        isInventoryOk = true;
                        timer.GetComponent<Timer>().timer = 0;
                        command_All_Count++;
                        ingameStep++;
                        command_manager.GetComponent<InputCommand>().clear_command = false;
                    }

                }
                break;
            case 25:
                {
                    commandCompare.GetComponent<CommandCompare>().player_animator.SetInteger("States", 0);
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    compare_score.GetComponent<DataMove>().Hidden_Name_Comapare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    hiddentIngredientCount++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    iscommandStart = true;




                                }
                            }
                        }
                    }
                }
                break;
            case 26:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = true;
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand_Count(Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(command_All_Count));

                    }

                    //for (int i = 1; i < 3; i++)
                    //{
                    //    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == i)
                    //    {
                    //        commandCompare.GetComponent<CommandCompare>().Command_checking();
                    //    }
                    //}

                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount && Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount != 0 && command_manager.GetComponent<InputCommand>().clear_command == true)
                    {

                        commandbar.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = false;
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().starting_command_Count = 0;
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        if (isHiddentCount == 0)
                        {
                            Making_ingredient();
                        }

                        else if (isHiddentCount == 1)
                        {
                            HiddentMaking_Ingredient();
                            isHiddentCount = 0;
                            making_Count++;
                        }
                        isInventoryOk = true;
                        timer.GetComponent<Timer>().timer = 0;
                        command_All_Count++;
                        ingameStep++;
                        command_manager.GetComponent<InputCommand>().clear_command = false;
                    }
                }
                break;
            case 27:
                {
                    commandCompare.GetComponent<CommandCompare>().player_animator.SetInteger("States", 0);
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    iscommandStart = true;




                                }
                            }
                        }
                    }
                }
                break;
            case 28:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = true;
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand_Count(Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(command_All_Count));

                    }

                    //for (int i = 1; i < 4; i++)
                    //{
                    //    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == i)
                    //    {
                    //        commandCompare.GetComponent<CommandCompare>().Command_checking();
                    //    }
                    //}

                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount && Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount != 0 && command_manager.GetComponent<InputCommand>().clear_command == true)
                    {

                        commandbar.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = false;
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().starting_command_Count = 0;
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        isInventoryOk = true;
                        timer.GetComponent<Timer>().timer = 0;
                        command_All_Count++;
                        ingameStep++;
                        command_manager.GetComponent<InputCommand>().clear_command = false;
                    }
                }
                break;
            case 29:
                {
                    commandCompare.GetComponent<CommandCompare>().player_animator.SetInteger("States", 0);
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    




                                }
                            }
                        }
                    }
                }
                break;
            case 30:
                {
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    compare_score.GetComponent<DataMove>().Hidden_Name_Comapare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    hiddentIngredientCount++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);





                                }
                            }
                        }
                    }
                }
                break;
            case 31:
                {
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    iscommandStart = true;





                                }
                            }
                        }
                    }

                }
                break;
            case 32:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = true;
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand_Count(Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(command_All_Count));

                    }

                    //for (int i = 1; i < 3; i++)
                    //{
                    //    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == i)
                    //    {
                    //        commandCompare.GetComponent<CommandCompare>().Command_checking();
                    //    }
                    //}

                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount && Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount != 0 && command_manager.GetComponent<InputCommand>().clear_command == true)
                    {

                        commandbar.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = false;
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().starting_command_Count = 0;
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();                                       
                        isInventoryOk = true;
                        timer.GetComponent<Timer>().timer = 0;
                        command_All_Count++;
                        ingameStep++;
                        command_manager.GetComponent<InputCommand>().clear_command = false;
                    }
                }
                break;

            case 33:
                {
                    commandCompare.GetComponent<CommandCompare>().player_animator.SetInteger("States", 0);
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    iscommandStart = true;





                                }
                            }
                        }
                    }
                }
                break;

            case 34:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = true;
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand_Count(Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(command_All_Count));

                    }

                    //for (int i = 1; i < 3; i++)
                    //{
                    //    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == i)
                    //    {
                    //        commandCompare.GetComponent<CommandCompare>().Command_checking();
                    //    }
                    //}

                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount && Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount != 0 && command_manager.GetComponent<InputCommand>().clear_command == true)
                    {

                        commandbar.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = false;
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().starting_command_Count = 0;
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        isInventoryOk = true;
                        timer.GetComponent<Timer>().timer = 0;
                        command_All_Count++;
                        ingameStep++;
                        command_manager.GetComponent<InputCommand>().clear_command = false;
                    }
                }
                break;
            case 35:
                {
                    commandCompare.GetComponent<CommandCompare>().player_animator.SetInteger("States", 0);
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();
                                    ingameStep++;
                                    Ingredient_Count++;
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    





                                }
                            }
                        }
                    }
                }
                break;
            case 36:
                {
                    for (int j = 0; j < basic_instance.Count; j++)
                    {

                        if (basic_instance[j].GetComponent<DataMove>().space_onoff == true && inventory.activeSelf == true)
                        {

                            for (int i = 0; i < basic_instance.Count; i++)
                            {
                                if (basic_instance[i].activeSelf == true)
                                {

                                    compare_score = basic_instance[i];
                                    compare_score.GetComponent<DataMove>().Name_Compare();                                   
                                    ingameStep++;
                                    Ingredient_Count++;                                    
                                    basic_instance[i].GetComponent<DataMove>().DataMoving();
                                    keyboardinput.SetActive(true);
                                    inventory.SetActive(false);
                                    iscommandStart = true;






                                }
                            }
                        }
                    }
                }
                break;
            case 37:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = true;
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand_Count(Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(command_All_Count));

                    }

                    //for (int i = 1; i < 6; i++)
                    //{
                    //    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == i)
                    //    {
                    //        commandCompare.GetComponent<CommandCompare>().Command_checking();
                    //    }
                    //}

                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount && Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount != 0 && command_manager.GetComponent<InputCommand>().clear_command == true)
                    {

                        commandbar.SetActive(false);
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().is_Commanding = false;
                        commandboard_recipe_Input.GetComponent<Command_recipeScript>().starting_command_Count = 0;
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        isInventoryOk = true;
                        timer.GetComponent<Timer>().timer = 0;
                        command_All_Count++;
                        ingameStep++;
                        command_manager.GetComponent<InputCommand>().clear_command = false;
                    }
                }
                break;

            case 38:
                {
                    commandCompare.GetComponent<CommandCompare>().player_animator.SetInteger("States", 0);
                    ingameStep++;
                    command_All_Count = 0;
                    making_Count = 0;
                    hiddentIngredientCount = 0;
                    hiddentmaking_Count = 0;
                    //hidden으로 가는 법?


                    gameFinishObject.SetActive(true);
                }
                break;



        }
    }
    public int GetIngameStep()
    {
        return ingameStep;
    }

    public int GetIngameStage()
    {
        return ingameStage;
    }
    public void SetIngameStep(int num)
    {
        ingameStep = num;
    }

    public int GetHiddenConditionNumber()
    {
        return hiddenConditionNumber;
    }

    public int GetHiddenCount()
    {
        return hiddenCount;
    }

    public void SetHiddentCount(int count)
    {
        hiddenCount = count;
    }

    public void Making_ingredient()
    {
        Making_Ingredients[making_Count].transform.SetParent(InventorySlot[dataGameManager.GetComponent<Data_GameManager>().moveCount].transform);
        Making_Ingredients[making_Count].transform.position = InventorySlot[dataGameManager.GetComponent<Data_GameManager>().moveCount].transform.position;
        Making_Ingredients[making_Count].transform.localScale = new Vector3(0.8f, 0.8f, 0);
        Making_Ingredients_Moving[making_Count].transform.SetParent(InventorySlot[dataGameManager.GetComponent<Data_GameManager>().moveCount].transform);
        Making_Ingredients_Moving[making_Count].transform.position = InventorySlot[dataGameManager.GetComponent<Data_GameManager>().moveCount].transform.position;
        Making_Ingredients_Moving[making_Count].transform.localScale = new Vector3(0.8f, 0.8f, 0);
        Making_Ingredients_Moving[making_Count].GetComponent<WareHouseDataMove>().enabled = false;
        Making_Ingredients_Moving[making_Count].GetComponent<DataMove>().enabled = true;
        basic_instance.Add(Making_Ingredients_Moving[making_Count]);
        dataGameManager.GetComponent<Data_GameManager>().moveCount++;
        if (isComplete == false)
        {
            ShowMakingIngredient.GetComponent<Image>().sprite = Making_Ingredients[making_Count].GetComponent<Image>().sprite;
            ShowMakingIngredient.SetActive(true);
            SoundBox.GetComponent<SoundBoxController>().PlaySound(4);
            block.SetActive(true);
        }

        making_Count++;
    }

    public void HiddentMaking_Ingredient()
    {
        
        hiddenMaking_Ingredients[hiddentmaking_Count].transform.SetParent(InventorySlot[dataGameManager.GetComponent<Data_GameManager>().moveCount].transform);
        hiddenMaking_Ingredients[hiddentmaking_Count].transform.position = InventorySlot[dataGameManager.GetComponent<Data_GameManager>().moveCount].transform.position;
        hiddenMaking_Ingredients[hiddentmaking_Count].transform.localScale = new Vector3(0.8f, 0.8f, 0);
        hiddenMaking_Ingredients_Moving[hiddentmaking_Count].transform.SetParent(InventorySlot[dataGameManager.GetComponent<Data_GameManager>().moveCount].transform);
        hiddenMaking_Ingredients_Moving[hiddentmaking_Count].transform.position = InventorySlot[dataGameManager.GetComponent<Data_GameManager>().moveCount].transform.position;
        hiddenMaking_Ingredients_Moving[hiddentmaking_Count].transform.localScale = new Vector3(0.8f, 0.8f, 0);
        hiddenMaking_Ingredients_Moving[hiddentmaking_Count].GetComponent<WareHouseDataMove>().enabled = false;
        hiddenMaking_Ingredients_Moving[hiddentmaking_Count].GetComponent<DataMove>().enabled = true;
        basic_instance.Add(hiddenMaking_Ingredients_Moving[hiddentmaking_Count]);
        dataGameManager.GetComponent<Data_GameManager>().moveCount++;
        Debug.Log(ShowMakingIngredient.GetComponent<Image>().sprite);
        Debug.Log(hiddenMaking_Ingredients[hiddentmaking_Count].GetComponent<Image>().sprite);
        ShowMakingIngredient.GetComponent<Image>().sprite = hiddenMaking_Ingredients[hiddentmaking_Count].GetComponent<Image>().sprite;
        ShowMakingIngredient.SetActive(true);
        SoundBox.GetComponent<SoundBoxController>().PlaySound(4);
        block.SetActive(true);

        hiddentmaking_Count++;
    }



    bool EndAnimationDone()

    {

        return player_Anime.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("PutIngredient_Animation") && player_Anime.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.35f;

    }



    

}

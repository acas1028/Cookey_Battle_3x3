using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompareActiveAnswer : MonoBehaviour
{
    public GameObject fieldObject;
    public GameObject gameFinishObject;

    public GameObject compare_score;

    public GameObject movetag;

    public GameObject keyboardinput;

    public GameObject commandbar;

    public GameObject inventory;

    public GameObject inventoryandcommanbarSwitch;

    public GameObject CommandComparison;

    public GameObject Soup_Command_Database;

    public GameObject commandCompare;

    public GameObject[] score_compare_basic_instance;

    public GameObject[] score_compare_instance;

    public GameObject[] Making_Ingredients;

    public GameObject[] Making_Ingredients_Moving;

    public GameObject[] InventorySlot;

    public GameObject dataGameManager;

    public GameObject maingame_inventory;

    public int Ingredient_Count = 0;

    public int making_Count = 0;

    public int score_compare_cal = 0;

    public int command_All_Count = 0;

    public Item_list item_List;

    public List<GameObject> basic_instance;

    public bool inventoryonoff = false;

    public bool isPossibleDestroy = false;

    public bool iscommandStart = false;

    public bool isinventoryStart = false;

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
                hiddenConditionNumber = 3;
                break;
            case 2:
                hiddenConditionNumber = 4;
                break;
            case 3:
                hiddenConditionNumber = 5;
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
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
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Soup_Command_DataBase>().GetItemName_SoupCommand_Count(Soup_Command_Database.GetComponent<Soup_Command_DataBase>().GetItemName_SoupCommand(command_All_Count));
                        
                    }

                    

                    if(CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount== Soup_Command_Database.GetComponent<Soup_Command_DataBase>().HisCount && Soup_Command_Database.GetComponent<Soup_Command_DataBase>().HisCount!=0)
                    {
                        
                        commandbar.SetActive(false);
                        keyboardinput.SetActive(true);
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        command_All_Count++;
                        ingameStep++;

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
                                    ingameStep++;
                                    Ingredient_Count++;
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
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Soup_Command_DataBase>().GetItemName_SoupCommand_Count(Soup_Command_Database.GetComponent<Soup_Command_DataBase>().GetItemName_SoupCommand(command_All_Count));

                    }



                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Soup_Command_DataBase>().HisCount && Soup_Command_Database.GetComponent<Soup_Command_DataBase>().HisCount != 0)
                    {

                        commandbar.SetActive(false);
                        keyboardinput.SetActive(true);
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        command_All_Count++;
                        ingameStep++;

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
            case 10:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Soup_Command_DataBase>().GetItemName_SoupCommand_Count(Soup_Command_Database.GetComponent<Soup_Command_DataBase>().GetItemName_SoupCommand(command_All_Count));

                    }



                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Soup_Command_DataBase>().HisCount && Soup_Command_Database.GetComponent<Soup_Command_DataBase>().HisCount != 0)
                    {

                        commandbar.SetActive(false);
                        keyboardinput.SetActive(true);
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        command_All_Count++;
                        ingameStep++;

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
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Soup_Command_DataBase>().GetItemName_SoupCommand_Count(Soup_Command_Database.GetComponent<Soup_Command_DataBase>().GetItemName_SoupCommand(command_All_Count));

                    }



                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Soup_Command_DataBase>().HisCount && Soup_Command_Database.GetComponent<Soup_Command_DataBase>().HisCount != 0)
                    {

                        commandbar.SetActive(false);
                        keyboardinput.SetActive(true);
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        command_All_Count++;
                        ingameStep++;

                    }
                }
                break;

            case 13:
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
            case 15:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Soup_Command_DataBase>().GetItemName_SoupCommand_Count(Soup_Command_Database.GetComponent<Soup_Command_DataBase>().GetItemName_SoupCommand(command_All_Count));

                    }



                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Soup_Command_DataBase>().HisCount && Soup_Command_Database.GetComponent<Soup_Command_DataBase>().HisCount != 0)
                    {

                        commandbar.SetActive(false);
                        keyboardinput.SetActive(true);
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        command_All_Count++;
                        ingameStep++;

                    }
                }
                break;
            case 16:
                {
                    ingameStep++;
                    command_All_Count = 0;
                    making_Count = 0;

                    

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
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SlimeCommand_Count(Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SoupCommand(command_All_Count));

                    }



                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount && Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount != 0)
                    {

                        commandbar.SetActive(false);
                        keyboardinput.SetActive(true);
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        command_All_Count++;
                        ingameStep++;

                    }
                }
                break;
            case 3:
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
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SlimeCommand_Count(Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SoupCommand(command_All_Count));

                    }



                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount && Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount != 0)
                    {

                        commandbar.SetActive(false);
                        keyboardinput.SetActive(true);
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        command_All_Count++;
                        ingameStep++;

                    }
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
            case 8:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SlimeCommand_Count(Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SoupCommand(command_All_Count));

                    }



                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount && Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount != 0)
                    {

                        commandbar.SetActive(false);
                        keyboardinput.SetActive(true);
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        command_All_Count++;
                        ingameStep++;

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
            case 10:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SlimeCommand_Count(Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SoupCommand(command_All_Count));

                    }



                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount && Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount != 0)
                    {

                        commandbar.SetActive(false);
                        keyboardinput.SetActive(true);
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        command_All_Count++;
                        ingameStep++;

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
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SlimeCommand_Count(Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SoupCommand(command_All_Count));

                    }



                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount && Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount != 0)
                    {

                        commandbar.SetActive(false);
                        keyboardinput.SetActive(true);
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        command_All_Count++;
                        ingameStep++;

                    }
                }
                break;
            case 13:
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
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SlimeCommand_Count(Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SoupCommand(command_All_Count));

                    }



                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount && Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount != 0)
                    {

                        commandbar.SetActive(false);
                        keyboardinput.SetActive(true);
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        command_All_Count++;
                        ingameStep++;

                    }
                }
                break;
            case 17:
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

            case 18:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SlimeCommand_Count(Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SoupCommand(command_All_Count));

                    }



                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount && Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount != 0)
                    {

                        commandbar.SetActive(false);
                        keyboardinput.SetActive(true);
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        command_All_Count++;
                        ingameStep++;

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
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SlimeCommand_Count(Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SoupCommand(command_All_Count));

                    }



                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount && Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount != 0)
                    {

                        commandbar.SetActive(false);
                        keyboardinput.SetActive(true);
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        command_All_Count++;
                        ingameStep++;

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
            case 22:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SlimeCommand_Count(Soup_Command_Database.GetComponent<SlimeCommandDatabase>().GetItemName_SoupCommand(command_All_Count));

                    }



                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount && Soup_Command_Database.GetComponent<SlimeCommandDatabase>().HisCount != 0)
                    {

                        commandbar.SetActive(false);
                        keyboardinput.SetActive(true);
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        command_All_Count++;
                        ingameStep++;

                    }
                }
                break;
            case 23:
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
            case 28:
                {
                    ingameStep++;

                    command_All_Count = 0;
                    making_Count = 0;

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
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand_Count(Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(command_All_Count));

                    }



                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount && Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount != 0)
                    {

                        commandbar.SetActive(false);
                        keyboardinput.SetActive(true);
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        command_All_Count++;
                        ingameStep++;

                    }
                }
                break;
            case 3:
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
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand_Count(Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(command_All_Count));

                    }



                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount && Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount != 0)
                    {

                        commandbar.SetActive(false);
                        keyboardinput.SetActive(true);
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        command_All_Count++;
                        ingameStep++;

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
            case 8:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand_Count(Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(command_All_Count));

                    }



                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount && Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount != 0)
                    {

                        commandbar.SetActive(false);
                        keyboardinput.SetActive(true);
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        command_All_Count++;
                        ingameStep++;

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
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand_Count(Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(command_All_Count));

                    }



                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount && Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount != 0)
                    {

                        commandbar.SetActive(false);
                        keyboardinput.SetActive(true);
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        command_All_Count++;
                        ingameStep++;

                    }
                }
                break;
            case 13:
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
            case 14:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand_Count(Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(command_All_Count));

                    }



                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount && Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount != 0)
                    {

                        commandbar.SetActive(false);
                        keyboardinput.SetActive(true);
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        command_All_Count++;
                        ingameStep++;

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
            case 17:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand_Count(Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(command_All_Count));

                    }



                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount && Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount != 0)
                    {

                        commandbar.SetActive(false);
                        keyboardinput.SetActive(true);
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        command_All_Count++;
                        ingameStep++;

                    }
                }
                break;
            case 18:
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
            case 22:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand_Count(Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(command_All_Count));

                    }



                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount && Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount != 0)
                    {

                        commandbar.SetActive(false);
                        keyboardinput.SetActive(true);
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        command_All_Count++;
                        ingameStep++;

                    }
                }
                break;

            case 23:
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

            case 24:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand_Count(Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(command_All_Count));

                    }



                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount && Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount != 0)
                    {

                        commandbar.SetActive(false);
                        keyboardinput.SetActive(true);
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        command_All_Count++;
                        ingameStep++;

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
            case 26:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand_Count(Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(command_All_Count));

                    }



                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount && Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount != 0)
                    {

                        commandbar.SetActive(false);
                        keyboardinput.SetActive(true);
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        command_All_Count++;
                        ingameStep++;

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
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand_Count(Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(command_All_Count));

                    }



                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount && Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount != 0)
                    {

                        commandbar.SetActive(false);
                        keyboardinput.SetActive(true);
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        command_All_Count++;
                        ingameStep++;

                    }
                }
                break;
            case 29:
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
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand_Count(Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(command_All_Count));

                    }



                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount && Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount != 0)
                    {

                        commandbar.SetActive(false);
                        keyboardinput.SetActive(true);
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        command_All_Count++;
                        ingameStep++;

                    }
                }
                break;

            case 33:
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

            case 34:
                {
                    if (iscommandStart == true)
                    {
                        keyboardinput.SetActive(false);
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand_Count(Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(command_All_Count));

                    }



                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount && Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount != 0)
                    {

                        commandbar.SetActive(false);
                        keyboardinput.SetActive(true);
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        command_All_Count++;
                        ingameStep++;

                    }
                }
                break;
            case 35:
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
                        commandbar.SetActive(true);
                        Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand_Count(Soup_Command_Database.GetComponent<Dragon_Command_Database>().GetItemName_DragonCommand(command_All_Count));

                    }



                    if (CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount == Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount && Soup_Command_Database.GetComponent<Dragon_Command_Database>().HisCount != 0)
                    {

                        commandbar.SetActive(false);
                        keyboardinput.SetActive(true);
                        commandCompare.GetComponent<CommandCompare>().CommandScore();
                        CommandComparison.GetComponent<ComandComparison>().CommandComparisonCount = 0;
                        Making_ingredient();
                        command_All_Count++;
                        ingameStep++;

                    }
                }
                break;

            case 38:
                {
                    ingameStep++;

                    command_All_Count = 0;
                    making_Count = 0;

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
        making_Count++;
    }

}

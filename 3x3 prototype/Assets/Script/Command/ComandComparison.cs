using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComandComparison : MonoBehaviour
{
    public CalculationCommand calculationCommand;

    public CommandCollection commandCollection;

    public GameObject commandCompare;

    public List<KeyCode> CommandsAnswer = new List<KeyCode>(); // 정답 비교하기 위한 리스트. 즉, 정답으로 해당하는 리스트를 이쪽으로 옮긴뒤 비교.

    public PracticeCommand practiceCommand; //연습용

    public string commandName; // 커맨드 이름을 밝히기 위한 요소
    
    public int CommandComparisonCount = 0; // 점수 비교를 한 뒤 얼마나 맞혔는지를 체크하기위한 정수형 변수

   


    public void Start()
    {
        //CommandsAnswer = practiceCommand.current_ComandCollection;
        // 임시 정답 커맨드 지정
    }

    public void Update()
    {
        commandCompare.GetComponent<CommandCompare>().CommandAnswer_division();
    }

    public void Comparison()
    {
        

        for (int i=0; i<calculationCommand.Commands.Count;i++)
        {
            if(calculationCommand.Commands.Count>=3)
            {
                break;
            }

            if(calculationCommand.Commands[i]!=commandCollection.CuttingCommand[i])
            {
                break;
            }
            if (calculationCommand.Commands.Count== commandCollection.CuttingCommand.Count)
            {
                if (i == calculationCommand.Commands.Count - 1 && calculationCommand.Commands[i] == commandCollection.CuttingCommand[i])
                {
                    commandName = "Cutting_Command";
                }
            }
          
        }

        for (int i = 0; i < calculationCommand.Commands.Count; i++)
        {
            if (calculationCommand.Commands.Count >= 9)
            {
                break;
            }

            if (calculationCommand.Commands[i] != commandCollection.Boiling_DownCommand[i])
            {
                break;
            }

            if (calculationCommand.Commands.Count == commandCollection.Boiling_DownCommand.Count)
            {
                if (i == calculationCommand.Commands.Count - 1 && calculationCommand.Commands[i] == commandCollection.Boiling_DownCommand[i])
                {
                    commandName = "Boiling_Down_Command";
                }
            }
       
        }
        for (int i = 0; i < calculationCommand.Commands.Count; i++)
        {
            if (calculationCommand.Commands.Count >= 5)
            {
                break;
            }

            if (calculationCommand.Commands[i] != commandCollection.BoilingCommand[i])
            {
                break;
            }

            if (calculationCommand.Commands.Count == commandCollection.BoilingCommand.Count)
            {
                if (i == calculationCommand.Commands.Count - 1 && calculationCommand.Commands[i] == commandCollection.BoilingCommand[i])
                {
                    commandName = "Boiling_Command";
                }
            }

        }

        for (int i = 0; i < calculationCommand.Commands.Count; i++)
        {
            if (calculationCommand.Commands.Count >= 10)
            {
                break;
            }

            if (calculationCommand.Commands[i] != commandCollection.ChoppingCommand[i])
            {
                break;
            }

            if (calculationCommand.Commands.Count == commandCollection.ChoppingCommand.Count)
            {
                if (i == calculationCommand.Commands.Count - 1 && calculationCommand.Commands[i] == commandCollection.ChoppingCommand[i])
                {
                    commandName = "Chopping_Command";
                }
            }

        }
        for (int i = 0; i < calculationCommand.Commands.Count; i++)
        {

            if (calculationCommand.Commands.Count >= 4)
            {
                break;
            }

            if (calculationCommand.Commands[i] != commandCollection.MashCommand[i])
            {
                break;
            }
            if (calculationCommand.Commands.Count == commandCollection.MashCommand.Count)
            {
                if (i == calculationCommand.Commands.Count - 1 && calculationCommand.Commands[i] == commandCollection.MashCommand[i])
                {
                    commandName = "Mash_Command";
                }
            }
           
        }
        for (int i = 0; i < calculationCommand.Commands.Count; i++)
        {
            if (calculationCommand.Commands.Count >= 4)
            {
                break;
            }

            if (calculationCommand.Commands[i] != commandCollection.SprayCommand[i])
            {
                break;
            }
            if (calculationCommand.Commands.Count== commandCollection.SprayCommand.Count)
            {
                if (i == calculationCommand.Commands.Count - 1 && calculationCommand.Commands[i] == commandCollection.SprayCommand[i])
                {
                    commandName = "Spray_Command";
                }
            }
            
        }

        for (int i = 0; i < calculationCommand.Commands.Count; i++)
        {
            if (calculationCommand.Commands.Count >= 9)
            {
                break;
            }

            if (calculationCommand.Commands[i] != commandCollection.WrapUpCommand[i])
            {
                break;
            }
            if(calculationCommand.Commands.Count== commandCollection.WrapUpCommand.Count)
            {
                if (i == calculationCommand.Commands.Count - 1 && calculationCommand.Commands[i] == commandCollection.WrapUpCommand[i])
                {
                    commandName = "WrapUp_Command";
                }
            }
         
        }

        for (int i = 0; i < calculationCommand.Commands.Count; i++)
        {
            if (calculationCommand.Commands.Count >= 4)
            {
                break;
            }

            if (calculationCommand.Commands[i] != commandCollection.Cut_inInsertCommand[i])
            {
                break;
            }

            if(calculationCommand.Commands.Count== commandCollection.Cut_inInsertCommand.Count)
            {
                if (i == calculationCommand.Commands.Count - 1 && calculationCommand.Commands[i] == commandCollection.Cut_inInsertCommand[i])
                {
                    commandName = "Cut_inInsert_Command";
                }
            }
        
        }

        for (int i = 0; i < calculationCommand.Commands.Count; i++)
        {
            if (calculationCommand.Commands[i] != commandCollection.Stir_fryCommand[i])
            {
                break;
            }

            if(calculationCommand.Commands.Count== commandCollection.Stir_fryCommand.Count) 
            {
                if (i == calculationCommand.Commands.Count - 1 && calculationCommand.Commands[i] == commandCollection.Stir_fryCommand[i])
                {
                    commandName = "Stir_Fry_Command";
                }
            }
           
        }

        for (int i = 0; i < calculationCommand.Commands.Count; i++)
        {

            if (calculationCommand.Commands.Count >= 9)
            {
                break;
            }

            if (calculationCommand.Commands[i] != commandCollection.IroningCommand[i])
            {
                break;
            }
            if(calculationCommand.Commands.Count== commandCollection.IroningCommand.Count)
            {
                if (i == calculationCommand.Commands.Count - 1 && calculationCommand.Commands[i] == commandCollection.IroningCommand[i])
                {
                    commandName = "Ironing_Command";
                }
            }
         
        }

        for (int i = 0; i < calculationCommand.Commands.Count; i++)
        {

            if (calculationCommand.Commands.Count >= 7)
            {
                break;
            }

            if (calculationCommand.Commands[i] != commandCollection.PushCommand[i])
            {
                break;
            }
            if(calculationCommand.Commands.Count== commandCollection.PushCommand.Count)
            {
                if (i == calculationCommand.Commands.Count - 1 && calculationCommand.Commands[i] == commandCollection.PushCommand[i])
                {
                    commandName = "Push_Command";
                }
            }
            
        }



        for (int i=0;i<calculationCommand.Commands.Count;i++)
        {
            if (calculationCommand.Commands.Count > CommandsAnswer.Count)
            {
                CommandComparisonCount += 1;
                break;
            }

            if (calculationCommand.Commands[i]!=CommandsAnswer[i])
            {
                CommandComparisonCount += 1;
                break;
            }

      

            if(i==calculationCommand.Commands.Count-1 && calculationCommand.Commands[i] == CommandsAnswer[i])
            {
                
                CommandComparisonCount += 1;
            }

            

           

            
                
        }
        


            
        
        
        




    }


    
}

using UnityEngine;

public class InputCommand : MonoBehaviour
{
    public Command command;

    public CalculationCommand calculationCommand;

    public ComandComparison comandComparison;

    public GameObject CommandCompare;

    public GameObject commandCount;


    int count = 1;



    private void Update()
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

        else if(Input.GetKeyDown(KeyCode.Space))
        {
           
            
            comandComparison.Comparison();
            if (commandCount.GetComponent<CommandCount>().isSoup == true)
            {
                CommandCompare.GetComponent<CommandCompare>().CommandCompare_Soup();
            }

            if( commandCount.GetComponent<CommandCount>().isSlime == true)
            {
                CommandCompare.GetComponent<CommandCompare>().CommandCompare_Slime();
            }

            if(commandCount.GetComponent<CommandCount>().isDragon == true)
            {
                CommandCompare.GetComponent<CommandCompare>().CommandCompare_Dragon();
            }





            if (comandComparison.commandName!=null)
            {
                Debug.Log(comandComparison.commandName);
                comandComparison.commandName = null;
            }
            


            calculationCommand.Commands.Clear();
            for(int i=0; i<command.commandList.Count;i++)
            {
                Destroy(command.commandList[i]);
            }
            command.commandList.Clear();

            count = 1;

            
        }

    }

}

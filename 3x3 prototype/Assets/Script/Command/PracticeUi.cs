using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PracticeUi : MonoBehaviour
{

    public Text command_Name;

    public Text command_Count;

    public PracticeCommand practiceCommand;

    public int real_Count;

    public ComandComparison comandComparison;
    
    

    // Update is called once per frame
    void Update()
    {
        real_Count = practiceCommand.random_count - comandComparison.CommandComparisonCount;

        command_Name.text = practiceCommand.current_Collection;

        command_Count.text = real_Count.ToString();

        if(real_Count==0)
        {
            command_Count.text = "Success";
        }
    }
}

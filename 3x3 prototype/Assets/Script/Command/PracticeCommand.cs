using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PracticeCommand : MonoBehaviour
{
    public List<string> random_Collection;

    public CommandCollection commandCollection;

    public int random_count;

    public string current_Collection;

    public List<KeyCode> current_ComandCollection;

    public int index;

   

    

    void Start()
    {
        random_Collection.Add("썰기");
        random_Collection.Add("끓이기");
        random_Collection.Add("으깨기");
        random_Collection.Add("뿌리기");
        random_Collection.Add("감싸기");
        random_Collection.Add("볶기");
        random_Collection.Add("칼집 넣기");
        random_Collection.Add("밀기");
        random_Collection.Add("누르기");

        random_count = Random.Range(1, 10);

        index = Random.Range(0, random_Collection.Count);

        current_Collection = random_Collection[index];


        

    }

    // Update is called once per frame
    void Update()
    {
        if(current_Collection=="썰기")
        {
            current_ComandCollection = commandCollection.CuttingCommand;
        }
        if(current_Collection== "끓이기")
        {
            current_ComandCollection = commandCollection.BoilingCommand;
        }
        if (current_Collection == "으깨기")
        {
            current_ComandCollection = commandCollection.MashCommand;
        }
        if (current_Collection == "뿌리기")
        {
            current_ComandCollection = commandCollection.SprayCommand;
        }
        if (current_Collection == "감싸기")
        {
            current_ComandCollection = commandCollection.WrapUpCommand;
        }
        if (current_Collection == "볶기")
        {
            current_ComandCollection = commandCollection.Stir_fryCommand;
        }
        if (current_Collection == "칼집 넣기")
        {
            current_ComandCollection = commandCollection.Cut_inInsertCommand;
        }
        if (current_Collection == "밀기")
        {
            current_ComandCollection = commandCollection.IroningCommand;
        }
        if (current_Collection == "누르기")
        {
            current_ComandCollection = commandCollection.PushCommand;
        }


    }

    
}

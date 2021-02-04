using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandCollection : MonoBehaviour
{
    // Start is called before the first frame update

    public List<KeyCode> CuttingCommand = new List<KeyCode>();
    public List<KeyCode> Boiling_DownCommand = new List<KeyCode>();
    public List<KeyCode> BoilingCommand = new List<KeyCode>();
    public List<KeyCode> ChoppingCommand = new List<KeyCode>();
    public List<KeyCode> MashCommand = new List<KeyCode>();
    public List<KeyCode> SprayCommand = new List<KeyCode>();
    public List<KeyCode> WrapUpCommand = new List<KeyCode>();
    public List<KeyCode> Stir_fryCommand = new List<KeyCode>();
    public List<KeyCode> Cut_inInsertCommand = new List<KeyCode>();
    public List<KeyCode> IroningCommand = new List<KeyCode>();
    public List<KeyCode> PushCommand = new List<KeyCode>();








    void Start()
    {
        CuttingCommand.Add(KeyCode.DownArrow);
        CuttingCommand.Add(KeyCode.DownArrow);

        Boiling_DownCommand.Add(KeyCode.UpArrow);
        Boiling_DownCommand.Add(KeyCode.RightArrow);
        Boiling_DownCommand.Add(KeyCode.DownArrow);
        Boiling_DownCommand.Add(KeyCode.LeftArrow);
        Boiling_DownCommand.Add(KeyCode.LeftArrow);
        Boiling_DownCommand.Add(KeyCode.DownArrow);
        Boiling_DownCommand.Add(KeyCode.RightArrow);
        Boiling_DownCommand.Add(KeyCode.UpArrow);

        BoilingCommand.Add(KeyCode.UpArrow);
        BoilingCommand.Add(KeyCode.RightArrow);
        BoilingCommand.Add(KeyCode.DownArrow);
        BoilingCommand.Add(KeyCode.LeftArrow);

        MashCommand.Add(KeyCode.LeftArrow);
        MashCommand.Add(KeyCode.DownArrow);
        MashCommand.Add(KeyCode.RightArrow);

        ChoppingCommand.Add(KeyCode.DownArrow);
        ChoppingCommand.Add(KeyCode.DownArrow);
        ChoppingCommand.Add(KeyCode.UpArrow);
        ChoppingCommand.Add(KeyCode.DownArrow);
        ChoppingCommand.Add(KeyCode.DownArrow);
        ChoppingCommand.Add(KeyCode.UpArrow);
        ChoppingCommand.Add(KeyCode.DownArrow);
        ChoppingCommand.Add(KeyCode.DownArrow);
        ChoppingCommand.Add(KeyCode.UpArrow);

        SprayCommand.Add(KeyCode.UpArrow);
        SprayCommand.Add(KeyCode.DownArrow);
        SprayCommand.Add(KeyCode.DownArrow);

        WrapUpCommand.Add(KeyCode.UpArrow);
        WrapUpCommand.Add(KeyCode.LeftArrow);
        WrapUpCommand.Add(KeyCode.UpArrow);
        WrapUpCommand.Add(KeyCode.DownArrow);
        WrapUpCommand.Add(KeyCode.UpArrow);
        WrapUpCommand.Add(KeyCode.RightArrow);
        WrapUpCommand.Add(KeyCode.UpArrow);
        WrapUpCommand.Add(KeyCode.DownArrow);

        Stir_fryCommand.Add(KeyCode.DownArrow);
        Stir_fryCommand.Add(KeyCode.DownArrow);
        Stir_fryCommand.Add(KeyCode.UpArrow);
        Stir_fryCommand.Add(KeyCode.UpArrow);
        Stir_fryCommand.Add(KeyCode.LeftArrow);
        Stir_fryCommand.Add(KeyCode.RightArrow);
        Stir_fryCommand.Add(KeyCode.DownArrow);
        Stir_fryCommand.Add(KeyCode.UpArrow);
        Stir_fryCommand.Add(KeyCode.UpArrow);
        Stir_fryCommand.Add(KeyCode.DownArrow);

        Cut_inInsertCommand.Add(KeyCode.DownArrow);
        Cut_inInsertCommand.Add(KeyCode.UpArrow);
        Cut_inInsertCommand.Add(KeyCode.DownArrow);

        IroningCommand.Add(KeyCode.DownArrow);
        IroningCommand.Add(KeyCode.DownArrow);
        IroningCommand.Add(KeyCode.DownArrow);
        IroningCommand.Add(KeyCode.LeftArrow);
        IroningCommand.Add(KeyCode.UpArrow);
        IroningCommand.Add(KeyCode.DownArrow);
        IroningCommand.Add(KeyCode.DownArrow);
        IroningCommand.Add(KeyCode.DownArrow);

        PushCommand.Add(KeyCode.LeftArrow);
        PushCommand.Add(KeyCode.DownArrow);
        PushCommand.Add(KeyCode.RightArrow);
        PushCommand.Add(KeyCode.RightArrow);
        PushCommand.Add(KeyCode.DownArrow);
        PushCommand.Add(KeyCode.LeftArrow);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

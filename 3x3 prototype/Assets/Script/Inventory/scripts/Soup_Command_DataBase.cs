﻿using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

[System.Serializable]
public class Item_list_Soup_Command
{
    public Item_list_Soup_Command(string _Type, string _Name, int _Count)
    {
        Type = _Type; Name = _Name; Count = _Count;
    }

    public string Type, Name;
    public int Count;
}

public class Soup_Command_DataBase : MonoBehaviour
{
    public TextAsset ItemDatabase;
    public List<Item_list_Soup_Command> aiItemList, SoupAnswer_Command_ItemList;
    public int moveCount = 0;
    public int HisCount;
    public int Count_command;
    public double score = 0;

    void Start()
    {

        //현재 아이템 리스트 불러오기
        string[] line = ItemDatabase.text.Substring(0, ItemDatabase.text.Length - 1).Split('\n');
        //Debug.Log(line.Length);
        for (int i = 0; i < line.Length; i++)
        {
            string[] row = line[i].Split('\t');
            aiItemList.Add(new Item_list_Soup_Command(row[0], row[1], Count_command= int.Parse(row[2])));
        }



        Save();

        Load();
    }

    void Save()
    {
        string jdata = JsonConvert.SerializeObject(aiItemList);
        File.WriteAllText(Application.dataPath + "/etc/Soup_Command_Answer_DataBase_Another.txt", jdata);
    }

    void Load()
    {
        string jdata = File.ReadAllText(Application.dataPath + "/etc/Soup_Command_Answer_DataBase_Another.txt");
        SoupAnswer_Command_ItemList = JsonConvert.DeserializeObject<List<Item_list_Soup_Command>>(jdata);
    }

    public string GetItemName_SoupCommand(int number)
    {
        return aiItemList[number].Name;
    }

    public void GetItemName_SoupCommand_Count(string Name)
    {
        for(int I=0; I<aiItemList.Count;I++)
        {
            if(aiItemList[I].Name == Name)// 지금 쳐야하는 커맨드임을 알려주는 및 카운트 명시
            {
               HisCount =aiItemList[I].Count;
               
            }
        }
    }

}
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

[System.Serializable]
public class Item_list_Dragon
{
    public Item_list_Dragon(string _Type, string _Name, string _Explanation)
    {
        Type = _Type; Name = _Name; Explanation = _Explanation;
    }

    public string Type, Name, Explanation;
}

public class Dragon_Database : MonoBehaviour
{
    public TextAsset ItemDatabase;
    public List<Item_list_Dragon> aiItemList, DragonAnswer_ItemList;
    public int moveCount = 0;

    public double score = 0;

    void Start()
    {

        //현재 아이템 리스트 불러오기
        string[] line = ItemDatabase.text.Substring(0, ItemDatabase.text.Length - 1).Split('\n');
        for (int i = 0; i < line.Length; i++)
        {
            string[] row = line[i].Split('\t');
            aiItemList.Add(new Item_list_Dragon(row[0], row[1], row[2]));
        }



        Save();

        Load();
    }

    void Save()
    {
        string jdata = JsonConvert.SerializeObject(aiItemList);
        File.WriteAllText(Application.dataPath + "/etc/Soup_Answer_DataBase_Another.txt", jdata);
    }

    void Load()
    {
        string jdata = File.ReadAllText(Application.dataPath + "/etc/Soup_Answer_DataBase_Another.txt");
        DragonAnswer_ItemList = JsonConvert.DeserializeObject<List<Item_list_Dragon>>(jdata);
    }

    public string GetItemName(int number)
    {
        return DragonAnswer_ItemList[number].Name;
    }

}
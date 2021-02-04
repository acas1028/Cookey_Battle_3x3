using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

[System.Serializable]
public class Item_list_SoupMakingIngredient
{
    public Item_list_SoupMakingIngredient(string _Type, string _Name, string _Explanation, int _score)
    {
        Type = _Type; Name = _Name; Explanation = _Explanation; score = _score;
    }

    public string Type, Name, Score, Explanation;
    public int score;
}

public class MakingDatabaseManager : MonoBehaviour
{
    public TextAsset ItemDatabase;
    public List<Item_list_SoupMakingIngredient> aiItemList, SoupAnswer_Making_ItemList;
    public int moveCount = 0;
    public int score = 0;
    

    void Start()
    {

        //현재 아이템 리스트 불러오기
        string[] line = ItemDatabase.text.Substring(0, ItemDatabase.text.Length - 1).Split('\n');
        for (int i = 0; i < line.Length; i++)
        {
            string[] row = line[i].Split('\t');
            aiItemList.Add(new Item_list_SoupMakingIngredient(row[0], row[1], row[2], score= int.Parse(row[3])));
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
        SoupAnswer_Making_ItemList = JsonConvert.DeserializeObject<List< Item_list_SoupMakingIngredient>> (jdata);
    }

    public string GetItemName(int number)
    {
        return SoupAnswer_Making_ItemList[number].Name;
    }

}
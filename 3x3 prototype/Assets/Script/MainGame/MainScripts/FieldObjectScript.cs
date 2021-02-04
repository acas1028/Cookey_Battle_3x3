using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldObjectScript : MonoBehaviour
{
    int     itemNumber;
    public int     fieldScore;

    public Item_list field_item_list;

    // Start is called before the first frame update
    void Start()
    {
        itemNumber = 0;
        fieldScore = 100;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(fieldScore);
    }

    public int GetFielditemNumber()
    {
        return itemNumber;
    }

    public int GetFieldScore()
    {
        return fieldScore;
    }

    public Item_list GetItem_List()
    {
        return field_item_list;
    }

    public void SetFielditemNumber(int itemNum)
    {
        itemNumber = itemNum;
    }

    public void SetFieldScore(int score)
    {
        fieldScore = score;
    }

    public void SetitemList(Item_list item_List)
    {
        field_item_list = item_List;
    }

}

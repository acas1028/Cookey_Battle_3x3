using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSpace : MonoBehaviour
{
    public Data_GameManager data_GameManager;

    public GameObject dataMoving;

    public GameObject soup_MakingIngredients;

    public int count;

    public Item_list item_List;

    public Item_list_SoupMakingIngredient SoupMakingIngredient;

    public bool dataMovingCount = false;

    public bool isMakingIngredinet;

    public WareHouseInventoryScript wareHouseInventoryScript;

    

    private void Update()
    {
        for (int i = 0; i < data_GameManager.warehouseItemList.Count; i++)
        {
            if (count == i)
            {
                item_List = data_GameManager.warehouseItemList[i];
            }
        }

        if(isMakingIngredinet==true)
        {
            for(int i=0; i< soup_MakingIngredients.GetComponent<MakingDatabaseManager>().SoupAnswer_Making_ItemList.Count;i++)
            {
                if(count == i)
                {
                    SoupMakingIngredient = soup_MakingIngredients.GetComponent<MakingDatabaseManager>().SoupAnswer_Making_ItemList[i];
                    item_List.Type = SoupMakingIngredient.Type;
                    item_List.Name = SoupMakingIngredient.Name;
                    item_List.Explanation = SoupMakingIngredient.Explanation;
                    item_List.score = SoupMakingIngredient.score;
                }
            }
        }
        

        if(dataMovingCount==true)
        {
            dataMoving.SetActive(true);
        }
        if(dataMovingCount==false)
        {
            dataMoving.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Cursor" )
        {
            dataMovingCount = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Cursor" )
        {
            dataMovingCount = false;
        }   
    }


}

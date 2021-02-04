using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sort : MonoBehaviour
{
    public GameObject[] InventorySlot;

    public Data_GameManager data_GameManager;

    public bool isemptySlots = false;

    private void Start()
    {
        
    }


    private void Update()
    {
        if (InventorySlot.Length == 0)
        {
            InventorySlot = GameObject.FindGameObjectsWithTag("Slot");
        }

        for (int i = 0; i < data_GameManager.moveCount; i++)
        {
            if (InventorySlot[i].transform.childCount == 0)
            {
               
                isemptySlots = true;
            }


        }



        if (isemptySlots == true)
        {
            for (int i = 0; i < data_GameManager.moveCount; i++)
            {
                if (InventorySlot[i].transform.childCount == 0)
                {

                    if (data_GameManager.moveCount != 40)
                    {

                        for (int k = i + 1; k <= data_GameManager.moveCount; k++)
                        {

                            List<Transform> Children = new List<Transform>();
                            if (InventorySlot[k].transform.childCount == 2)
                            {
                                Children.Add(InventorySlot[k].transform.GetChild(0));
                                Children.Add(InventorySlot[k].transform.GetChild(1));
                                for (int t = 0; t < 2; t++)
                                {
                                    Children[t].gameObject.transform.SetParent(InventorySlot[k - 1].transform);
                                    Children[t].gameObject.transform.position = InventorySlot[k - 1].transform.position;
                                }
                            }






                        }

                    }
                    if (data_GameManager.moveCount == 40)
                    {

                        for (int k = i + 1; k <= data_GameManager.moveCount-1; k++)
                        {

                            List<Transform> Children = new List<Transform>();
                            if (InventorySlot[k].transform.childCount == 2)
                            {
                                Children.Add(InventorySlot[k].transform.GetChild(0));
                                Children.Add(InventorySlot[k].transform.GetChild(1));
                                for (int t = 0; t < 2; t++)
                                {
                                    Children[t].gameObject.transform.SetParent(InventorySlot[k - 1].transform);
                                    Children[t].gameObject.transform.position = InventorySlot[k - 1].transform.position;
                                }
                            }






                        }

                    }


                }


            }



            isemptySlots = false;
        }




    }
}


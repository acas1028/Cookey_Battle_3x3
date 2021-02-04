using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WareHouseDataMove : MonoBehaviour
{
    public GameObject[] InventorySlot;

    public Data_GameManager data_GameManager;

    public GameObject myObject;

    public GameObject movingObject;

    public DataSpace dataSpace;


    public bool isemptySlots = false;

    public int emptyslotCount = 0;

    public bool isInventoryMove = false;






    void Start()
    {

        InventorySlot = GameObject.FindGameObjectsWithTag("Slot");

    }

    // Update is called once per frame
    void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DataMoving();
            dataDestroy();
          

            
        }


        //for (int i = 0; i < data_GameManager.moveCount; i++)
        //{
        //    if (InventorySlot[i].transform.childCount == 0)
        //    {
        //        Debug.Log("as");
        //        isemptySlots = true;
        //    }

            
        //}



        //if (isemptySlots==true)
        //{
        //    for (int i = 0; i < data_GameManager.moveCount; i++)
        //    {
        //        if (InventorySlot[i].transform.childCount == 0)
        //        {

        //            for (int k = i + 1; k <= data_GameManager.moveCount; k++)
        //            {
        //                Debug.Log("ww");
        //                List<Transform> Children = new List<Transform>();

        //                Children.Add(InventorySlot[k].transform.GetChild(0));
        //                Children.Add(InventorySlot[k].transform.GetChild(1));
        //                for (int t=0; t<2; t++)
        //                {
        //                    Children[t].gameObject.transform.SetParent(InventorySlot[k - 1].transform);
        //                    Children[t].gameObject.transform.position = InventorySlot[k - 1].transform.position;
        //                }




        //            }
        //        }

                
        //    }

            

        //    isemptySlots = false;
        //}

        


    }

    

    public void DataMoving()
    {
            if (isInventoryMove == false && InventorySlot[39].transform.childCount==0)
            {

                GameObject Instance = Instantiate(myObject, transform.position, Quaternion.identity);
                GameObject instance1 = Instantiate(movingObject, transform.position, Quaternion.identity);

                Instance.transform.SetParent(InventorySlot[data_GameManager.moveCount].transform);
                Instance.transform.position = InventorySlot[data_GameManager.moveCount].transform.position;
                instance1.transform.SetParent(InventorySlot[data_GameManager.moveCount].transform);
                instance1.transform.position = InventorySlot[data_GameManager.moveCount].transform.position;

                Instance.GetComponent<DataSpace>().dataMoving = instance1;
                Instance.GetComponent<DataSpace>().dataMovingCount = false;
                Instance.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                instance1.GetComponent<DataMove>().myObject = Instance;
                instance1.GetComponent<WareHouseDataMove>().myObject = Instance;
                instance1.GetComponent<WareHouseDataMove>().isInventoryMove = true;


                /*myObject.SetActive(false);
                myObject.SetActive(true);*/








                data_GameManager.moveCount++;
            }

            

    }

    void dataDestroy()
    {
        if (isInventoryMove == true)
        {
            Destroy(myObject);
            Destroy(movingObject);

            data_GameManager.moveCount--;
        }
    }

    



}

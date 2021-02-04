using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCursor : MonoBehaviour
{
    public GameObject wareHouseCursor;

    public GameObject inventoryCursor;

    public GameObject[] databaseObject;

    public bool isUsingCursor = false;

    public GameObject[] slots;

    public GameObject[] wareHouseSlots;

    public MoveCursor moveCursor;

    float time;

    private void Start()
    {
        databaseObject = GameObject.FindGameObjectsWithTag("Database");

        slots = GameObject.FindGameObjectsWithTag("Slot");

        wareHouseSlots = GameObject.FindGameObjectsWithTag("WareHouseSlot");

        wareHouseCursor.SetActive(true);

        inventoryCursor.SetActive(false);

        time = 0f;
    }


    private void Update()
    {
       

        time += Time.deltaTime;

        if (time > 0.1f)
        {
            Swicth();
        }
    }

    void Swicth()
    {
        if (Input.GetKeyDown(KeyCode.E) && isUsingCursor == false)
        {
            wareHouseCursor.SetActive(false);
            inventoryCursor.SetActive(true);
            isUsingCursor = true;            
            time = 0f;

            for(int i=0;i<databaseObject.Length; i++)
            {
                databaseObject[i].GetComponent<DataSpace>().dataMovingCount = false;
            }
            
        }

        else if (Input.GetKeyDown(KeyCode.E) && isUsingCursor == true)
        {
            wareHouseCursor.SetActive(true);
            inventoryCursor.SetActive(false); 
            isUsingCursor = false; 
            time = 0f;
            for (int i = 0; i < databaseObject.Length; i++)
            {
                databaseObject[i].GetComponent<DataSpace>().dataMovingCount = false;
            }


        }

        /*for (int i = 0; i < slots.Length; i++)
        {
            if (Input.mousePosition.x >= slots[i].transform.position.x - moveCursor.X_blockSize / 2 && Input.mousePosition.x <= slots[i].transform.position.x + moveCursor.X_blockSize / 2 && Input.mousePosition.y >= slots[i].transform.position.y - moveCursor.Y_blockSize / 2 && Input.mousePosition.y <= slots[i].transform.position.y + moveCursor.Y_blockSize / 2)
            {
                wareHouseCursor.SetActive(false);
                inventoryCursor.SetActive(true);
                isUsingCursor = true;
            }
        }

        for (int i = 0; i < slots.Length; i++)
        {
            if (Input.mousePosition.x >= wareHouseSlots[i].transform.position.x - moveCursor.X_blockSize / 2 && Input.mousePosition.x <= wareHouseSlots[i].transform.position.x + moveCursor.X_blockSize / 2 && Input.mousePosition.y >= wareHouseSlots[i].transform.position.y - moveCursor.Y_blockSize / 2 && Input.mousePosition.y <= wareHouseSlots[i].transform.position.y + moveCursor.Y_blockSize / 2)
            {
                wareHouseCursor.SetActive(true);
                inventoryCursor.SetActive(false);
                isUsingCursor = false;
            }
        }*/
        


        databaseObject = GameObject.FindGameObjectsWithTag("Database");
    }


}

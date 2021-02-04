using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMoveChecking : MonoBehaviour
{
    public GameObject[] dataBase;

    public GameObject[] wareHouseSlots;

    public MoveCursor moveCursor;

    public GameObject cursor;

    GameObject enablescript;

    private void Start()
    {
        dataBase= GameObject.FindGameObjectsWithTag("Database");

        wareHouseSlots = GameObject.FindGameObjectsWithTag("WareHouseSlot");
    }

    void Update()
    {
        
            
        
    }

    
}

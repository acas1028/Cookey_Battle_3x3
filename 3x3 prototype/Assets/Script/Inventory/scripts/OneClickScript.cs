using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneClickScript : MonoBehaviour
{
    public bool OneClick = false;

    public double Timer = 0;

    public double First_Time = 0;

    public bool isItemClick = false;

    public WareHouseDataMove wareHouseDataMove;

    public MoveMouseCursor moveMouse;

    public GameObject[] dataBase;


    private void Start()
    {
        dataBase = GameObject.FindGameObjectsWithTag("Database");
    }

    private void Update()
    {
        Timer = Time.time;
        for (int i = 0; i < dataBase.Length; i++)
        {
            if (moveMouse.MousePosition.x == dataBase[i].transform.position.x && moveMouse.MousePosition.y == dataBase[i].transform.position.y)
            {
                if (dataBase[i].GetComponent<OneClickScript>().isItemClick == false)
                {
                    dataBase[i].GetComponent<OneClickScript>().isItemClick = true;
                }
            }
            if (moveMouse.MousePosition.x != dataBase[i].transform.position.x || moveMouse.MousePosition.y != dataBase[i].transform.position.y)
            {
                if (dataBase[i].GetComponent<OneClickScript>().isItemClick == true)
                {
                    dataBase[i].GetComponent<OneClickScript>().isItemClick = false;

                }

                if(dataBase[i].GetComponent<OneClickScript>().OneClick ==true)
                {
                    dataBase[i].GetComponent<OneClickScript>().OneClick = false;
                }
            }
           
            
        }

       

            if (Input.GetMouseButtonDown(0))
            {

                if (!OneClick && isItemClick == true)
                {
                    First_Time = Timer;
                    OneClick = true;
                }
                else if (Timer >= (First_Time + 0.5) && isItemClick == true)
                {
                    OneClick = false;
                }
                else if (OneClick && (Timer) <= (First_Time + 0.5) && isItemClick == true)
                {
                    OneClick = false;
                    wareHouseDataMove.DataMoving();
                }
            }
        

    }
}

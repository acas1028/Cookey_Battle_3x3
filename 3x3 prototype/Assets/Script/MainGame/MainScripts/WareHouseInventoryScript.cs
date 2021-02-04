using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WareHouseInventoryScript : MonoBehaviour
{
    public GameObject ingameStepObject;
    public GameObject MainKeyBoardInput;

    public GameObject inventory;

    public GameObject[] dataMove;

    public GameObject[] inventoryslots;

    public GameObject Cursor;

    public GameObject canvas;

    public GameObject scrollbar;

    public MoveCursor moveCursor;

    public GameObject active;

    public GameObject inventory_move;

    public int WareHouseDestroy = 0;

    public bool isscript = false;
    
    // Start is called before the first frame update
    void Start()
    {
        dataMove = GameObject.FindGameObjectsWithTag("MovingDatabase");
        inventoryslots = GameObject.FindGameObjectsWithTag("Slot");
    }

    // Update is called once per frame
    void Update()
    {
        dataMove = GameObject.FindGameObjectsWithTag("MovingDatabase");

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            ingameStepObject.GetComponent<CompareActiveAnswer>().SetIngameStep(1);
            MainKeyBoardInput.SetActive(true);
            this.gameObject.SetActive(false);
            inventory.transform.SetParent(canvas.transform);//임시
            active.transform.SetParent(canvas.transform);
            inventory.transform.Translate(0, 450, 0);
            WareHouseDestroy = 1;

            Cursor.SetActive(true);

            for(int i=0; i<inventoryslots.Length;i++)
            {
                if(inventoryslots[i].transform.childCount!=0)
                {
                    inventoryslots[i].transform.GetChild(0).gameObject.SetActive(true);
                    inventoryslots[i].transform.GetChild(1).gameObject.SetActive(true);
                }
            }

            dataMove = GameObject.FindGameObjectsWithTag("MovingDatabase");
            active.GetComponent<Inventory_clone_on>().inventory_clone = dataMove;
            

            for (int i=0; i<dataMove.Length;i++)
            {
                dataMove[i].GetComponent<WareHouseDataMove>().enabled = false;
            }
            for (int i = 0; i < dataMove.Length; i++)
            {
                dataMove[i].GetComponent<DataMove>().enabled = true;
            }
            for (int i = 0; i < dataMove.Length; i++)
            {
                dataMove[i].SetActive(false);
            }
            inventory.SetActive(false);

        }


        if (WareHouseDestroy == 1)
        {

            for(int i=1; i<=3;i++)
            {
                if (moveCursor.GetComponent<MoveCursor>().blockLine == i)
                {
                    scrollbar.transform.Translate(0, -i * moveCursor.scroll_line_size, 0);

                    moveCursor.blockLine = 0;
                }
            }
            
        }
       
    }


}

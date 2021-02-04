using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCursor : MonoBehaviour
{
    
    float time;
    public float scroll_line_size;
    public float blockLine;
    public float bottom_count = 0;
    public int isThisFirst = 0;
    public bool itemnotEmpty = false;
    public bool firstitemnotEmpty = false;


    public float X_blockSize;
    public float Y_blockSize;
    public int blockX;
    public int blockY;
    // Start is called before the first frame update

    public GameObject cursor;

    public GameObject scrollbar;

    public GameObject inventoryScrollbar;

    public Vector3 cursor_Position;

    public Vector3 scrollbar_Position;

    public GameObject[] inventorySlots;

    public WareHouseInventoryScript inventoryScript;

    public GameObject inventory;

    public GameObject Main_Keyboard_Input;

    public GameObject inventory_Cursor;

    public bool isinventoryCursor;

    void Start()
    {

        X_blockSize = 180f;
        Y_blockSize = 150f;
        blockLine = 0;
        scroll_line_size = 150f;
        time = 0f;
        blockX = 0;
        blockY = 0;
        inventorySlots = GameObject.FindGameObjectsWithTag("Slot");

    }

    // Update is called once per frame
    void Update()
    {

        scrollbar_Position = scrollbar.transform.position;
        cursor_Position = cursor.transform.position;
        time += Time.deltaTime;
        if (time >= 0.1f)
        {
            move();

            if (blockLine >= 0 && blockLine <= 3)
            {
                moveScrollbar();
                slotmoveScrollbar();
            }
            if (blockLine < 0 || blockLine > 3)
            {
                TeleportScrollbar();
            }

            time = 0f;
        }



        if (blockY == 1)
        {
            bottom_count = 1;
        }
        if (blockY == 0)
        {
            bottom_count = 0;
        }

        
        if(inventoryScript.WareHouseDestroy==1)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                inventory.SetActive(false);
                Main_Keyboard_Input.SetActive(true);
            }
        }


    }

    void move()
    {
        Vector3 movePos = Vector3.zero;
        if (Input.GetAxisRaw("Vertical") > 0 && blockY > 0)
        {   // 화살표위쪽키 입력 
            transform.Translate(new Vector3(0f, 1f * Y_blockSize, 0f));
            blockY--;
        }

        if (Input.GetAxisRaw("Vertical") < 0 && blockY < 1)
        {   // 화살표밑쪽키 입력
            transform.Translate(new Vector3(0f, -1f * Y_blockSize, 0f));
            blockY++;
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {   // 화살표오른쪽키 입력
            if (blockX >= 0 && blockX < 8)
            {
                transform.Translate(new Vector3(1f * X_blockSize, 0f, 0f));
                blockX++;
            }
            if (blockX > 7)
            {
                transform.Translate(new Vector3(-8f * X_blockSize, 0f, 0f));
                blockX = 0;
            }
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            // 화살표왼쪽키 입력
            if (blockX >= -1 && blockX < 8)
            {
                transform.Translate(new Vector3(-1f * X_blockSize, 0f, 0f));
                blockX--;
            }

            if (blockX < 0)
            {
                transform.Translate(new Vector3(8f * X_blockSize, 0f, 0f));
                blockX = 7;
            }
        }
    }

    void moveScrollbar()
    {
        if (Input.GetAxisRaw("Vertical") < 0 && bottom_count == 1 && blockLine >= -1)
        {
            scrollbar.transform.Translate(0, scroll_line_size, 0);
            blockLine++;
        }

        if (Input.GetAxisRaw("Vertical") > 0 && bottom_count == 0 && blockLine <= 3)
        {
            scrollbar.transform.Translate(0, -scroll_line_size, 0);
            blockLine--;
        }
    }

    void slotmoveScrollbar()
    {
        if (isinventoryCursor == false)
        {

            for (int i = 0; i < 2; i++)
            {

                if (inventorySlots[16 + 8 * i].transform.childCount != 0 && itemnotEmpty == true && firstitemnotEmpty == true && inventory_Cursor.GetComponent<MoveCursor>().blockLine != 3)
                {
                    inventoryScrollbar.transform.Translate(0, scroll_line_size, 0);
                    inventory_Cursor.GetComponent<MoveCursor>().blockLine++;
                    itemnotEmpty = false;
                    firstitemnotEmpty = false;
                    if (isThisFirst < 2)// 최대 blockline-1로 설정되어있다.
                    {
                        isThisFirst++;
                    }
                }
                if (inventorySlots[(16 + 8 * i) - 1].transform.childCount != 0)
                {
                    firstitemnotEmpty = true;
                }

                if (inventorySlots[16 + 8 * isThisFirst].transform.childCount != 0)
                {
                    itemnotEmpty = true;
                }

            }
        }
    }

        

        

        
    

    void TeleportScrollbar()
    {
        if (Input.GetAxisRaw("Vertical") < 0 && bottom_count == 1)
        {
            scrollbar.transform.Translate(0, -4f * scroll_line_size, 0);
            cursor.transform.Translate(0, 1f * Y_blockSize, 0);
            blockY = 0;
            blockLine = 0;
        }

        if (Input.GetAxisRaw("Vertical") > 0 && bottom_count == 0)
        {
            scrollbar.transform.Translate(0, 4f * scroll_line_size, 0);
            cursor.transform.Translate(0, -1f * Y_blockSize, 0);
            blockY = 1;
            blockLine = 3;
        }

    }

   


}
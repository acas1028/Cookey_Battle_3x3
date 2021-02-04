using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySpawner : MonoBehaviour
{
  
    public enum ItemNumber
    {
        frying_pan, butter, mint_candy, Pot, starch_syrup, milk, kohakuto, chopping_board, ruby //조린 뒤 나오는 내용물 어떻게 할지 생각.
    }

    int bag_Count = 0;

    public Vector3[] inventory_space;

    //일단은 이렇게 하되, 나중에 prefabs에서 자동으로 꺼내오도록 코드 수정
    public GameObject Frying_pan;
    public GameObject Butter;
    public GameObject Mint_candy;
    public GameObject Pot;
    public GameObject Starch_syrup;
    public GameObject Milk;
    public GameObject Kohakuto;
    public GameObject Chopping_board;
    public GameObject Ruby;
    public GameObject Bag;

    public GameObject[] arrayObject;

    int arraySize = 9;



    //인벤토리 소환 위치(수정할 예정). 즉, 임시로 설정
    Vector3 bagPosition = new Vector3(0, 20, 0);


    public void Start()
    {
        arrayObject = new GameObject[arraySize];

        arrayObject[0] = Instantiate(Frying_pan, inventory_space[0], Quaternion.identity);
        arrayObject[1] = Instantiate(Butter,inventory_space[0],Quaternion.identity);
        arrayObject[2] = Instantiate(Mint_candy,inventory_space[0],Quaternion.identity);
        arrayObject[3] = Instantiate(Pot, inventory_space[0], Quaternion.identity);
        arrayObject[4] = Instantiate(Starch_syrup, inventory_space[0],Quaternion.identity);
        arrayObject[5] = Instantiate(Milk,inventory_space[0],Quaternion.identity);
        arrayObject[6] = Instantiate(Kohakuto,inventory_space[0],Quaternion.identity);
        arrayObject[7] = Instantiate(Chopping_board,inventory_space[0],Quaternion.identity);
        arrayObject[8] = Instantiate(Ruby,inventory_space[0],Quaternion.identity);

        foreach(GameObject destoryObject in arrayObject)
        {
            Destroy(destoryObject);
        }



        int total = 21;

        inventory_space = new Vector3[total];


        //자리 배정
        inventory_space[0] = new Vector3(-20, 25, 0);
        inventory_space[1] = new Vector3(-15, 25, 0);
        inventory_space[2] = new Vector3(-10, 25, 0);
        inventory_space[3] = new Vector3(-5, 25, 0);
        inventory_space[4] = new Vector3(0, 25, 0);
        inventory_space[5] = new Vector3(5, 25, 0);
        inventory_space[6] = new Vector3(10, 25, 0);
        inventory_space[7] = new Vector3(-20, 20, 0);
        inventory_space[8] = new Vector3(-15, 20, 0);
        inventory_space[9] = new Vector3(-10, 20, 0);
        inventory_space[10] = new Vector3(-5, 20, 0);
        inventory_space[11] = new Vector3(0, 20, 0);
        inventory_space[12] = new Vector3(5, 20, 0);
        inventory_space[13] = new Vector3(10, 20, 0);
        inventory_space[14] = new Vector3(-20, 15, 0);
        inventory_space[15] = new Vector3(-15, 15, 0);
        inventory_space[16] = new Vector3(-10, 15, 0);
        inventory_space[17] = new Vector3(-5, 15, 0);
        inventory_space[18] = new Vector3(0, 15, 0);
        inventory_space[19] = new Vector3(5, 15, 0);
        inventory_space[20] = new Vector3(10, 15, 0);






        



    }

   


    void Update()
    {


        if (bag_Count == 0)
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                Bag.SetActive(true);
                for(int i=0; i<arrayObject.Length;i++)
                {
                    Instantiate(arrayObject[i], inventory_space[i], Quaternion.identity);
                }
                bag_Count += 1;
            }
        }

        else if (bag_Count == 1)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Bag.SetActive(false);
                for(int i=0;i<arrayObject.Length;i++)
                {
                    Destroy(arrayObject[i].gameObject);
                }
                bag_Count -= 1;
            }
        }
    }
}

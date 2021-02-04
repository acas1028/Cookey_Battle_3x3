using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    public enum ItemNumber
    {
        frying_pan, butter, mint_candy, Pot, starch_syrup,milk, kohakuto, chopping_board, ruby //조린 뒤 나오는 내용물 어떻게 할지 생각.
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
   
    

    //인벤토리 소환 위치(수정할 예정). 즉, 임시로 설정
    Vector3 bagPosition = new Vector3(0, 20, 0);


    public void Start()
    {
        

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

        //임시로 자리 배정

        GameObject instance = Instantiate(Frying_pan, inventory_space[0], Quaternion.identity);
        GameObject instance1 = Instantiate(Butter, inventory_space[1], Quaternion.identity);
        GameObject instance2 = Instantiate(Mint_candy, inventory_space[2], Quaternion.identity);
        GameObject instance3 = Instantiate(Pot, inventory_space[3], Quaternion.identity);
        GameObject instance4 = Instantiate(Starch_syrup, inventory_space[4], Quaternion.identity);
        GameObject instance5 = Instantiate(Milk, inventory_space[5], Quaternion.identity);
        GameObject instance6 = Instantiate(Kohakuto, inventory_space[6], Quaternion.identity);
        GameObject instance7 = Instantiate(Chopping_board, inventory_space[7], Quaternion.identity);
        GameObject instance8 = Instantiate(Ruby, inventory_space[8], Quaternion.identity);

    }


   







    //e키를 눌렀을 때 인벤토리 화면 출력!
    //이건 이미지 파일이 필요하기 때문에 뒤로...

   




    private void Update()
    {

        //이것을 소환으로 하지말고 setActive를 이용해 활설화 비활설화를 변화시킨다.
        if (bag_Count == 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Bag.SetActive(true);
                bag_Count += 1;
            }
        }

        else if (bag_Count==1)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Bag.SetActive(false);
                bag_Count -= 1;
            }
        }
    }









}

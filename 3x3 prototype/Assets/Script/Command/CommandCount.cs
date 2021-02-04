using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandCount : MonoBehaviour
{
    public GameObject soupCommandDatabase;

    public GameObject commandComparison;

    public int count;

    public Text text;

    public bool isSoup;

    public bool isSlime;

    public bool isDragon;

    private void Update()
    {
        if (isSoup == true)
        {
            count = soupCommandDatabase.GetComponent<Soup_Command_DataBase>().HisCount - commandComparison.GetComponent<ComandComparison>().CommandComparisonCount;
        }

        if(isSlime==true)
        {
            count = soupCommandDatabase.GetComponent<SlimeCommandDatabase>().HisCount - commandComparison.GetComponent<ComandComparison>().CommandComparisonCount;
        }

        if(isDragon==true)
        {
            count = soupCommandDatabase.GetComponent<Dragon_Command_Database>().HisCount - commandComparison.GetComponent<ComandComparison>().CommandComparisonCount;
        }


        text.text = count.ToString();
    }
}

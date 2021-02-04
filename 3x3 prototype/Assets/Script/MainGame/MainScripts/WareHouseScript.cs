using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WareHouseScript : MonoBehaviour
{
    public GameObject panel;
    public GameObject WareHouseInventory;

    int time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time++;

        if (time > 300)
        {
            this.gameObject.SetActive(false);
            panel.SetActive(false);
            WareHouseInventory.SetActive(true);
        }

    }
}

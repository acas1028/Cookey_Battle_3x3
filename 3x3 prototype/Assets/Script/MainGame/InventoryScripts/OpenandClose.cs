using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenandClose : MonoBehaviour
{
    public GameObject inventoryPanel;
    public bool activeInventory = true;

    private void Start()
    {
        
    }

    private void Update()
    {
        
        if (activeInventory == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                activeInventory = !activeInventory;
                inventoryPanel.SetActive(activeInventory);
            }
        }

    }
}

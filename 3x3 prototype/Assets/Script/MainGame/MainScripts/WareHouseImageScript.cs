using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WareHouseImageScript : MonoBehaviour
{
    public GameObject wareHouse;
    public GameObject SoundBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            wareHouse.SetActive(true);
            SoundBox.GetComponent<SoundBoxController>().PlaySound(7);
            this.gameObject.SetActive(false);
        }

       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Command_KeyBoardInputScript : MonoBehaviour
{
    private int numberOfPage;
    public Sprite[] pages;
    public GameObject mainGameKeyBoardInput;
    public GameObject SoundBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Escape))
        {
            numberOfPage = 0;
            SoundBox.GetComponent<SoundBoxController>().PlaySound(0);
            mainGameKeyBoardInput.SetActive(true);
            this.gameObject.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (numberOfPage > 0)
            {
                SoundBox.GetComponent<SoundBoxController>().PlaySound(0);
                numberOfPage--;
            }
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(numberOfPage < 8)
            {
                SoundBox.GetComponent<SoundBoxController>().PlaySound(0);
                numberOfPage++;
            }
        }

        if (numberOfPage > 7)
            numberOfPage = 7;
        if (numberOfPage < 0)
            numberOfPage = 0;

        settingImage(numberOfPage);
    }

    void settingImage(int num)
    {
        this.gameObject.GetComponent<Image>().sprite = pages[num];
    }
}

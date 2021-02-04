using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Command_KeyBoardInputScript : MonoBehaviour
{
    private int numberOfPage;
    public Sprite page_0;
    public Sprite page_1;
    public GameObject mainGameKeyBoardInput;
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
            mainGameKeyBoardInput.SetActive(true);
            this.gameObject.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (numberOfPage > 0)
            {
                numberOfPage--;
            }
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(numberOfPage < 1)
            {
                numberOfPage++;
            }
        }

        if (numberOfPage > 1)
            numberOfPage = 1;
        if (numberOfPage < 0)
            numberOfPage = 0;

        settingImage(numberOfPage);
    }

    void settingImage(int num)
    {
        switch(num)
        {
            case 0:
                this.gameObject.GetComponent<Image>().sprite = page_0;
                break;
            case 1:
                this.gameObject.GetComponent<Image>().sprite = page_1;
                break;
            default:
                break;
        }
    }
}

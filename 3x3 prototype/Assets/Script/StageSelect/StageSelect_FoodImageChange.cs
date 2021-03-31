using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelect_FoodImageChange : MonoBehaviour
{
    public int stageNumber;

    public Sprite NoneClearImage;
    public Sprite FirstClearImage;
    public Sprite BadClearImage;
    // Start is called before the first frame update
    void Start()
    {
        switch(stageNumber)
        {
            case 1:
                if (GameManager.instance.GetStage1Try() == false)
                {
                    this.gameObject.GetComponent<Image>().sprite = NoneClearImage;
                }
                else
                {
                    if (GameManager.instance.GetStage1State() == 0)
                        this.gameObject.GetComponent<Image>().sprite = BadClearImage;
                    else
                        this.gameObject.GetComponent<Image>().sprite = FirstClearImage;
                }
                break;
            case 2:
                if (GameManager.instance.GetStage2Try() == false)
                {
                    this.gameObject.GetComponent<Image>().sprite = NoneClearImage;
                }
                else
                {
                    if (GameManager.instance.GetStage2State() == 0)
                        this.gameObject.GetComponent<Image>().sprite = BadClearImage;
                    else
                        this.gameObject.GetComponent<Image>().sprite = FirstClearImage;
                }
                break;
            case 3:
                if (GameManager.instance.GetStage3Try() == false)
                {
                    this.gameObject.GetComponent<Image>().sprite = NoneClearImage;
                }
                else
                {
                    if (GameManager.instance.GetStage3State() == 0)
                        this.gameObject.GetComponent<Image>().sprite = BadClearImage;
                    else
                        this.gameObject.GetComponent<Image>().sprite = FirstClearImage;
                }
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

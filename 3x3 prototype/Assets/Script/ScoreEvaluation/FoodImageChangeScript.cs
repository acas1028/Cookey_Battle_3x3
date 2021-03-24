using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodImageChangeScript : MonoBehaviour
{
    public Sprite goodFoodImage;
    public Sprite badFoodImage;

    // Start is called before the first frame update
    void Start()
    {
        SetFoodImage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetFoodImage()
    {
        switch (GameManager.instance.GetStageLevel())
        {
            case 1:
                this.GetComponent<Image>().sprite = badFoodImage;
                if (GameManager.instance.GetStage1Clear())
                    this.GetComponent<Image>().sprite = goodFoodImage;
                if (GameManager.instance.GetStage1HiddenClear())
                    this.GetComponent<Image>().sprite = goodFoodImage;
                break;
            case 2:
                this.GetComponent<Image>().sprite = badFoodImage;
                if (GameManager.instance.GetStage2Clear())
                    this.GetComponent<Image>().sprite = goodFoodImage;
                if (GameManager.instance.GetStage2HiddenClear())
                    this.GetComponent<Image>().sprite = goodFoodImage;
                break;
            case 3:
                this.GetComponent<Image>().sprite = badFoodImage;
                if (GameManager.instance.GetStage3Clear())
                    this.GetComponent<Image>().sprite = goodFoodImage;
                if (GameManager.instance.GetStage3HiddenClear())
                    this.GetComponent<Image>().sprite = goodFoodImage;
                break;
        }
    }
}

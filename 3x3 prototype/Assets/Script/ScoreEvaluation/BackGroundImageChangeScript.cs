using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundImageChangeScript : MonoBehaviour
{
    public Sprite goodBackGround;
    public Sprite badBackGround;
    public Sprite hiddenBackGround;

    // Start is called before the first frame update
    void Start()
    {
        SetBackGround();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetBackGround()
    {
        switch (GameManager.instance.GetStageLevel())
        {
            case 1:
                this.GetComponent<Image>().sprite = badBackGround;
                if (GameManager.instance.GetStage1Clear())
                    this.GetComponent<Image>().sprite = goodBackGround;
                if (GameManager.instance.GetStage1HiddenClear())
                    this.GetComponent<Image>().sprite = hiddenBackGround;
                break;
            case 2:
                this.GetComponent<Image>().sprite = badBackGround;
                if (GameManager.instance.GetStage2Clear())
                    this.GetComponent<Image>().sprite = goodBackGround;
                if (GameManager.instance.GetStage2HiddenClear())
                    this.GetComponent<Image>().sprite = hiddenBackGround;
                break;
            case 3:
                this.GetComponent<Image>().sprite = badBackGround;
                if (GameManager.instance.GetStage3Clear())
                    this.GetComponent<Image>().sprite = goodBackGround;
                if (GameManager.instance.GetStage3HiddenClear())
                    this.GetComponent<Image>().sprite = hiddenBackGround;
                break;
        }
    }
}

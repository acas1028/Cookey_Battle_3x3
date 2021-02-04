using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ImageChangeScript : MonoBehaviour
{
    public int stageNumber;
    public GameObject translucentLockPanel;
    public GameObject hiddenEffectPanel;
    public Sprite noneClearImage;
    public Sprite firstClearImage;
    public Sprite badClearImage;
    public Sprite hiddenClearImage;
    public Sprite hiddenPerfectClearImage;

    public Sprite hiddenClearEffect;
    public Sprite hiddenPerfectClearEffect;
    // Start is called before the first frame update
    void Start()
    {
        SettingImage();
    }

    // Update is called once per frame
    void Update()
    {
        SettingImage();

    }

    void SettingImage()
    {
        switch (stageNumber)
        {
            case 1:
                if (GameManager.instance.GetStage1Try() == false)
                {
                    this.gameObject.GetComponent<Image>().sprite = noneClearImage;
                }
                else
                {
                    this.gameObject.GetComponent<Image>().sprite = badClearImage;
                    if (GameManager.instance.GetStage1State() == 1)
                    {
                        this.gameObject.GetComponent<Image>().sprite = firstClearImage;
                    }
                    if (GameManager.instance.GetStage1State() == 2)
                    {
                        hiddenEffectPanel.SetActive(true);
                        if (GameManager.instance.GetStage1HighScore() == 100)
                        {
                            this.gameObject.GetComponent<Image>().sprite = hiddenPerfectClearImage;
                            hiddenEffectPanel.GetComponent<Image>().sprite = hiddenPerfectClearEffect;
                        }
                        else
                        {
                            this.gameObject.GetComponent<Image>().sprite = hiddenClearImage;
                            hiddenEffectPanel.GetComponent<Image>().sprite = hiddenClearEffect;
                        }
                    }
                }
                break;
            case 2:
                if (GameManager.instance.GetStage2Try() == false)
                {
                    this.gameObject.GetComponent<Image>().sprite = noneClearImage;
                }
                else
                {
                    this.gameObject.GetComponent<Image>().sprite = badClearImage;
                    if (GameManager.instance.GetStage2State() == 1)
                    {
                        this.gameObject.GetComponent<Image>().sprite = firstClearImage;
                    }
                    if (GameManager.instance.GetStage2State() == 2)
                    {
                        hiddenEffectPanel.SetActive(true);
                        if (GameManager.instance.GetStage2HighScore() == 100)
                        {
                            this.gameObject.GetComponent<Image>().sprite = hiddenPerfectClearImage;
                            hiddenEffectPanel.GetComponent<Image>().sprite = hiddenPerfectClearEffect;
                        }
                        else
                        {
                            this.gameObject.GetComponent<Image>().sprite = hiddenClearImage;
                            hiddenEffectPanel.GetComponent<Image>().sprite = hiddenClearEffect;
                        }
                    }
                }
                break;
            case 3:
                if (GameManager.instance.GetStage3Try() == false)
                {
                    this.gameObject.GetComponent<Image>().sprite = noneClearImage;
                }
                else
                {
                    this.gameObject.GetComponent<Image>().sprite = badClearImage;
                    if (GameManager.instance.GetStage3State() == 1)
                    {
                        this.gameObject.GetComponent<Image>().sprite = firstClearImage;
                    }
                    if (GameManager.instance.GetStage3State() == 2)
                    {
                        hiddenEffectPanel.SetActive(true);
                        if (GameManager.instance.GetStage3HighScore() == 100)
                        {
                            this.gameObject.GetComponent<Image>().sprite = hiddenPerfectClearImage;
                            hiddenEffectPanel.GetComponent<Image>().sprite = hiddenPerfectClearEffect;
                        }
                        else
                        {
                            this.gameObject.GetComponent<Image>().sprite = hiddenClearImage;
                            hiddenEffectPanel.GetComponent<Image>().sprite = hiddenClearEffect;
                        }
                    }
                }
                break;
            default:
                break;
        }
    }
    
}

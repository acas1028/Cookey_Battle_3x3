using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingTipManager : MonoBehaviour
{
    private int randomNum;
    public Image tipImage;
    public Text tipText;

    public Sprite[] images;
    // Start is called before the first frame update
    void Start()
    {
        randomNum = Random.Range(0, 10);

        RandomToolTip();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RandomToolTip()
    {
        switch(randomNum)
        {
            case 0:
                tipImage.sprite = images[randomNum];
                tipText.text = "test0입니다. 감사합니다";
                break;
            case 1:
                tipImage.sprite = images[randomNum];
                tipText.text = "test1입니다. 감사합니다";
                break;
            case 2:
                tipImage.sprite = images[randomNum];
                tipText.text = "test2입니다. 감사합니다";
                break;
            case 3:
                tipImage.sprite = images[randomNum];
                tipText.text = "test3입니다. 감사합니다";
                break;
            case 4:
                tipImage.sprite = images[randomNum];
                tipText.text = "test4입니다. 감사합니다";
                break;
            case 5:
                tipImage.sprite = images[randomNum];
                tipText.text = "test5입니다. 감사합니다";
                break;
            case 6:
                tipImage.sprite = images[randomNum];
                tipText.text = "test6입니다. 감사합니다";
                break;
            case 7:
                tipImage.sprite = images[randomNum];
                tipText.text = "test7입니다. 감사합니다";
                break;
            case 8:
                tipImage.sprite = images[randomNum];
                tipText.text = "test8입니다. 감사합니다";
                break;
            case 9:
                tipImage.sprite = images[randomNum];
                tipText.text = "test9입니다. 감사합니다";
                break;
            default:
                break;
        }
    }

    public void NextRandomNumber()
    {
        int newRandNum = Random.Range(0, 10);

        while(randomNum == newRandNum)
        {
            newRandNum = Random.Range(0, 10);
        }

        randomNum = newRandNum;
        Debug.Log(randomNum);

        RandomToolTip();
    }
}

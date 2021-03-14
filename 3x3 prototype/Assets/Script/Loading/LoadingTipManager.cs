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
        randomNum = Random.Range(0, 11);

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
                tipText.text = "왕궁에서 대대로 내려오는 레시피에서는 \n 슬라임 대신 골드 슬라임을 쓰도록 권장한대요!";
                break;
            case 1:
                tipImage.sprite = images[randomNum];
                tipText.text = "엘프족은 부드러운 식감을 중요시해서 \n 생크림보다 구름크림을 사용한대요.";
                break;
            case 2:
                tipImage.sprite = images[randomNum];
                tipText.text = "꿀사슴이 많은 남쪽 지역에서는 \n 꿀곰 발바닥 대신 꿀사슴의 뿔을 요리에 사용한답니다.";
                break;
            case 3:
                tipImage.sprite = images[randomNum];
                tipText.text = "그거 아셨나요? \n 세계수의 월잎대신 난쟁이나무의 잎을 쓰면 맛과 건강 두마리 토끼를 잡을수 있다는 사실을!";
                break;
            case 4:
                tipImage.sprite = images[randomNum];
                tipText.text = "그거 아셨나요? \n 우유대신 두유를 쓰면 맛과 건강 두 마리 토끼를 잡을 수 있다는 사실을!";
                break;
            case 5:
                tipImage.sprite = images[randomNum];
                tipText.text = "고블린족은 아삭한 식감을 중요시해서 \n 토마토보다 딸기를 사용한대요.";
                break;
            case 6:
                tipImage.sprite = images[randomNum];
                tipText.text = "왕궁에서 대대로 내려오는 레시피에서는 \n 우유대신 마요네즈를 쓰도록 권장한대요!";
                break;
            case 7:
                tipImage.sprite = images[randomNum];
                tipText.text = "만드라고라가 풍성한 남쪽 지역에서는 \n 버섯 대신 만드라고라를 요리에 사용한답니다.";
                break;
            case 8:
                tipImage.sprite = images[randomNum];
                tipText.text = "그거 아셨나요? \n 벌꿀 버섯대신 말벌 꿀나무 껍질을 쓰면 맛과 건강 두 마리 토끼를 잡을 수 있다는 사실을!";
                break;
            case 9:
                tipImage.sprite = images[randomNum];
                tipText.text = "왕궁에서 대대로 내려오는 레시피에서는 \n 루비대신 벌꿀 버섯을 쓰도록 권장한대요!";
                break;
            case 10:
                tipImage.sprite = images[randomNum];
                tipText.text = "왕궁에서 대대로 내려오는 레시피에서는 \n 버터대신 요거트를 쓰도록 권장한대요!";
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

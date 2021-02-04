using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeforeChangeScript : MonoBehaviour
{
    public GameObject afterSpaceObject_1st;
    public GameObject afterSpaceObject_2nd;
    public GameObject afterSpaceObject_3rd;
    public GameObject foodCover;
    public GameObject backGroundEffect;

    public GameObject goMainMenuButton;
    public GameObject goStageSelectButton;


    public Sprite goodEffect;
    public Sprite badEffect;
    public Sprite hiddenEffect;

    int enemy1Score;
    int enemy2Score;
    int playerScore;

    bool isClear;
    // Start is called before the first frame update

    private void Awake()
    {
        SetEnemyScore();
        Check_StageClear();

        Debug.Log("player" + playerScore);
        Debug.Log("enemy1" + enemy1Score);
        Debug.Log("enemy2" + enemy2Score);

    }
    void Start()
    {
        SetEffect();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (playerScore >= enemy1Score && playerScore >= enemy2Score)
            {
                afterSpaceObject_1st.SetActive(true);
            }
            else if (playerScore >= enemy1Score && playerScore < enemy2Score)
                afterSpaceObject_2nd.SetActive(true);
            else if (playerScore >= enemy2Score && playerScore < enemy1Score)
                afterSpaceObject_2nd.SetActive(true);
            else if (playerScore < enemy1Score && playerScore < enemy2Score)
                afterSpaceObject_3rd.SetActive(true);

            foodCover.SetActive(false);
            backGroundEffect.SetActive(true);
            goMainMenuButton.SetActive(true);
            goStageSelectButton.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    void SetEnemyScore()
    {
        int rand = 0;
        rand = Random.Range(0, 9);
        switch (GameManager.instance.GetStageLevel())
        {
            case 1:
                if (rand == 3)
                {
                    enemy1Score = Random.Range(45, 59);
                    enemy2Score = Random.Range(10, 20);
                }
                else
                {
                    enemy1Score = Random.Range(45, 59);
                    enemy2Score = Random.Range(45, 59);
                }
                playerScore = GameManager.instance.GetStage1Score();
                break;
            case 2:
                if(rand == 3)
                {
                    enemy1Score = Random.Range(70, 79);
                    enemy2Score = Random.Range(10, 30);
                }
                else    
                { 
                    enemy1Score = Random.Range(70, 79);
                    enemy2Score = Random.Range(70, 79); 
                }
                playerScore = GameManager.instance.GetStage2Score();
                break;
            case 3:
                enemy1Score = Random.Range(85, 89);
                enemy2Score = Random.Range(85, 89);
                playerScore = GameManager.instance.GetStage3Score();
                break;
        }

        if (playerScore >= enemy1Score && playerScore >= enemy2Score)
        {
            isClear = true;
        }

    }

    void SetEffect()
    {
        switch(GameManager.instance.GetStageLevel())
        {
            case 1:
                backGroundEffect.GetComponent<Image>().sprite = badEffect;
                if (GameManager.instance.GetStage1Clear())
                    backGroundEffect.GetComponent<Image>().sprite = goodEffect;
                if (GameManager.instance.GetStage1HiddenClear())
                    backGroundEffect.GetComponent<Image>().sprite = hiddenEffect;
                break;
            case 2:
                backGroundEffect.GetComponent<Image>().sprite = badEffect;
                if (GameManager.instance.GetStage2Clear())
                    backGroundEffect.GetComponent<Image>().sprite = goodEffect;
                if (GameManager.instance.GetStage2HiddenClear())
                    backGroundEffect.GetComponent<Image>().sprite = hiddenEffect;
                break;
            case 3:
                backGroundEffect.GetComponent<Image>().sprite = badEffect;
                if (GameManager.instance.GetStage3Clear())
                    backGroundEffect.GetComponent<Image>().sprite = goodEffect;
                if (GameManager.instance.GetStage3HiddenClear())
                    backGroundEffect.GetComponent<Image>().sprite = hiddenEffect;
                break;
        }
    }
    public int GetEnemy1Score()
    {
        return enemy1Score;
    }

    public int GetEnemy2Score()
    {
        return enemy2Score;
    }
    public int GetPlayerScore()
    {
        return playerScore;
    }

    void Stage1_ClearCheck()
    {
        GameManager.instance.SetStage1State(0);
        if (isClear)
        {
            GameManager.instance.SetStage1Clear(true);
            GameManager.instance.SetStage1HiddenClear(false);
            GameManager.instance.SetStage1State(1);
            if (GameManager.instance.GetStageHiddenCondition())
            {
                GameManager.instance.SetStage1HiddenClear(true);
                GameManager.instance.SetStage1State(2);
            }

            GameManager.instance.SetStageProgress(1);
        }
        else
            GameManager.instance.SetStageProgress(0);



        GameManager.instance.SetStage1Score(playerScore);

        if (playerScore > GameManager.instance.GetStage1HighScore())
        {
            GameManager.instance.SetStage1HighScore(playerScore);
        }
    }

    void Stage2_ClearCheck()
    {
        GameManager.instance.SetStage2State(0);
        if (isClear)
        {
            GameManager.instance.SetStage2Clear(true);
            GameManager.instance.SetStage2HiddenClear(false);
            GameManager.instance.SetStage2State(1);
            if (GameManager.instance.GetStageHiddenCondition())
            {
                GameManager.instance.SetStage2HiddenClear(true);
                GameManager.instance.SetStage2State(2);
            }
            GameManager.instance.SetStageProgress(2);
        }
        else
            GameManager.instance.SetStageProgress(0);
        GameManager.instance.SetStage2Score(playerScore);

        if (playerScore > GameManager.instance.GetStage2HighScore())
        {
            GameManager.instance.SetStage2HighScore(playerScore);
        }
    }

    void Stage3_ClearCheck()
    {
        GameManager.instance.SetStage3State(0);
        if (isClear)
        {
            GameManager.instance.SetStage3Clear(true);
            GameManager.instance.SetStage3State(1);
            if (GameManager.instance.GetStageHiddenCondition())
            {
                GameManager.instance.SetStage1HiddenClear(true);
                GameManager.instance.SetStage3State(2);
            }
            GameManager.instance.SetStageProgress(3);
        }
        else
            GameManager.instance.SetStageProgress(0);
        GameManager.instance.SetStage3Score(playerScore);

        if (playerScore > GameManager.instance.GetStage3HighScore())
        {
            GameManager.instance.SetStage3HighScore(playerScore);
        }
    }


    void Check_StageClear()
    {
        switch(GameManager.instance.GetStageLevel())
        {
            case 1:
                Stage1_ClearCheck();
                break;
            case 2:
                Stage2_ClearCheck();
                break;
            case 3:
                Stage3_ClearCheck();
                break;
        }
    }

}

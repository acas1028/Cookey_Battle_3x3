using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfterChangeScript : MonoBehaviour
{
    public GameObject beforeObject;


    public Text enemy1Name;
    public Text enemy1Score;
    public Text enemy2Name;
    public Text enemy2Score;
    public Text UserName;
    public Text UserScore;

    public string enemy1Name_string;
    public string enemy2Name_string;

    int enemy1Score_int;
    int enemy2Score_int;
    // Start is called before the first frame update
    void Start()
    {
        SettingPlayersName();
        SettingPlayersScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SettingPlayersScore()
    {
        enemy1Score_int = beforeObject.GetComponent<BeforeChangeScript>().GetEnemy1Score();
        enemy2Score_int = beforeObject.GetComponent<BeforeChangeScript>().GetEnemy2Score();

        if(enemy2Score_int > enemy1Score_int)
        {
            int dummy;
            dummy = enemy1Score_int;
            enemy1Score_int = enemy2Score_int;
            enemy2Score_int = dummy;
        }

        switch (GameManager.instance.GetStageLevel())
        {
            case 1:
                UserScore.text = GameManager.instance.GetStage1Score().ToString();
                enemy1Score.text = enemy1Score_int.ToString();
                enemy2Score.text = enemy2Score_int.ToString();
                break;
            case 2:
                UserScore.text = GameManager.instance.GetStage2Score().ToString();
                enemy1Score.text = enemy1Score_int.ToString();
                enemy2Score.text = enemy2Score_int.ToString();
                break;
            case 3:
                UserScore.text = GameManager.instance.GetStage3Score().ToString();
                enemy1Score.text = enemy1Score_int.ToString();
                enemy2Score.text = enemy2Score_int.ToString();
                break;
        }
    }


    void SettingPlayersName()
    {

        int rand = Random.Range(0, 1);

        if(rand == 0)
        {
            enemy1Name.text = enemy1Name_string;
            enemy2Name.text = enemy2Name_string;
        }
        else
        {
            enemy2Name.text = enemy1Name_string;
            enemy1Name.text = enemy2Name_string;
        }
        UserName.text = GameManager.instance.GetUserName();
        enemy1Name.text = enemy1Name_string;
        enemy2Name.text = enemy2Name_string;
    }
}

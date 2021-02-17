using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreEvaluationSceneChange : MonoBehaviour
{
    public int stageSelectScene;
    public int badEndingScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoNextScene()
    {
        switch(GameManager.instance.GetStageLevel())
        {
            case 1:
                if (GameManager.instance.GetStage1State() == 0)
                {
                    SceneManager.LoadScene(badEndingScene);
                }
                else
                    LoadingSceneManager.LoadScene(stageSelectScene);
                break;
            case 2:
                if (GameManager.instance.GetStage2State() == 0)
                {
                    SceneManager.LoadScene(badEndingScene);
                }
                else
                    LoadingSceneManager.LoadScene(stageSelectScene);
                break;
            case 3:
                if (GameManager.instance.GetStage3State() == 0)
                {
                    SceneManager.LoadScene(badEndingScene);
                }
                else
                    LoadingSceneManager.LoadScene(stageSelectScene);
                break;
            default:
                break;
        }
    }

}

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
        Debug.Log(GameManager.instance.GetStage1State());
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
                if (GameManager.instance.GetStage1Clear() != true)
                {
                    SceneManager.LoadScene(badEndingScene);
                }
                else
                    LoadingSceneManager.LoadScene(stageSelectScene);
                break;
            case 2:
                if (GameManager.instance.GetStage2Clear() != true)
                {
                    SceneManager.LoadScene(badEndingScene);
                }
                else
                    LoadingSceneManager.LoadScene(stageSelectScene);
                break;
            case 3:
                if (GameManager.instance.GetStage3Clear() != true)
                {
                    SceneManager.LoadScene(badEndingScene);
                }
                else
                    SceneManager.LoadScene(15);
                break;
            default:
                break;
        }
    }

}

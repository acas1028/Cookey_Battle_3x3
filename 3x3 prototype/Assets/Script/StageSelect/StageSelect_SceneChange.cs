using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect_SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    public int buildSceneNumber;
    public int stageNumber;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneChange()
    {
        GameManager.instance.SetStageLevel(stageNumber);
        LoadingSceneManager.LoadScene(buildSceneNumber);
    }
}

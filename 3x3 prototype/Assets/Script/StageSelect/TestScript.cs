using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameManager.instance.SetStage1Clear(true);
            Debug.Log("스테이지 1 클리어");
            PlayerPrefs.SetInt("Stage1",1);
            PlayerPrefs.SetInt("Stage1Score", 80);
            GameManager.instance.SetStage1Score(80);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            GameManager.instance.SetStage2Clear(true);
            Debug.Log("스테이지 2 클리어");
            PlayerPrefs.SetInt("Stage2", 1);
            PlayerPrefs.SetInt("Stage2Score", 70);
            GameManager.instance.SetStage1Score(80);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameManager.instance.SetStage3Clear(true);
            Debug.Log("스테이지 3 클리어");
            PlayerPrefs.SetInt("Stage3", 1);
            PlayerPrefs.SetInt("Stage3Score", 70);
            GameManager.instance.SetStage1Score(80);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameManager.instance.SetStage1HiddenClear(true);
            Debug.Log("스테이지 1 히든클리어");
            PlayerPrefs.SetInt("Stage1", 2);
            PlayerPrefs.SetInt("Stage1Score", 70);
            GameManager.instance.SetStage1Score(80);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameManager.instance.SetStage2HiddenClear(true);
            Debug.Log("스테이지 2 히든클리어");
            PlayerPrefs.SetInt("Stage2", 2);
            PlayerPrefs.SetInt("Stage2Score", 70);
            GameManager.instance.SetStage2Score(80);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GameManager.instance.SetStage3HiddenClear(true);
            Debug.Log("스테이지 3 히든클리어");
            PlayerPrefs.SetInt("Stage3", 2);
            PlayerPrefs.SetInt("Stage3Score", 70);
            GameManager.instance.SetStage3Score(80);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameManager.instance.SetStage1HiddenClear(true);
            GameManager.instance.SetStage1Score(100);
            Debug.Log("스테이지 1 히든퍼펙트클리어");
            PlayerPrefs.SetInt("Stage1", 2);
            PlayerPrefs.SetInt("Stage1Score", 100);
            GameManager.instance.SetStage1Score(100);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            GameManager.instance.SetStage2HiddenClear(true);
            GameManager.instance.SetStage2Score(100);
            Debug.Log("스테이지 2 히든퍼펙트클리어");
            PlayerPrefs.SetInt("Stage2", 2);
            PlayerPrefs.SetInt("Stage2Score", 100);
            GameManager.instance.SetStage2Score(100);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            GameManager.instance.SetStage3HiddenClear(true);
            GameManager.instance.SetStage3Score(100);
            Debug.Log("스테이지 3 히든퍼펙트클리어");
            PlayerPrefs.SetInt("Stage3", 2);
            PlayerPrefs.SetInt("Stage3Score", 100);
            GameManager.instance.SetStage3Score(100);
        }

        if(Input.GetKeyDown(KeyCode.G))
        {
            GameManager.instance.ResetGameManager();
        }
    }
}

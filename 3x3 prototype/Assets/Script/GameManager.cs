using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    // 세팅
    private static GameManager Instance;
    private string userName;      // 이름 저장
    public float musicVol = 0.5f; // 음악 소리
    public float soundVol = 0.5f; // 효과음 소리

    // 세팅
    // ======================================================================
    // 진행상황(스테이지)
    private bool stage1Clear;  // 스테이지1 클리어 판별변수
    private bool stage1HiddenClear; // 스테이지1 히든클리어 판별변수   이하 동문
    private bool stage2Clear;
    private bool stage2HiddenClear;
    private bool stage3Clear;
    private bool stage3HiddenClear;

    private int stage1State; // 스테이지 클리어판별 저장변수
    private int stage2State; // 0 none클리어 1 노말클리어 2 히든클리어 3 히든 퍼펙트클리어
    private int stage3State;
    // 진행상황(스테이지)
    // ========================================================================
    private int ingameStage; //스테이지 입장 시 어떤 스테이지인지 판별하게해주는 변수
    private int stage1Score; //스테이지1 최종 점수
    private int stage2Score; //스테이지2 최종 점수
    private int stage3Score; //스테이지3 최종 점수
    // =======================================================================
    private int stage1HighScore; //최고점
    private int stage2HighScore;
    private int stage3HighScore;

    // ========================================================================
    private bool stage1Try;  // 시도했는가 판별하는 변수
    private bool stage2Try;
    private bool stage3Try;

    // ========================================================================
    private int stageProgress;
    private bool stageHiddenCondition; // 그 스테이지의 히든 조건을 만족하였는가? (모든 스테이지에서 공통으로 사용하는 변수임)
    

    public static GameManager instance
    {
        get
        {
            if(Instance == null)
            {
                var obj = FindObjectOfType<GameManager>();
                if(obj != null)
                {
                    Instance = obj;
                }
                else
                {
                    var newSingleton = new GameObject("GameManager").AddComponent<GameManager>();
                    Instance = newSingleton;
                }
            }
            return Instance;
        }
        private set
        {
            Instance = value;
        }
    }

    void Awake()
    {
        var objs = FindObjectsOfType<GameManager>();
        if(objs.Length!= 1)
        {
            Destroy(gameObject);
            return;
        }
        userName = "";

        stage1State = 0;
        stage2State = 0;
        stage3State = 0;
        stage1Clear = false;
        stage2Clear = false;
        stage3Clear = false;
        stage1HiddenClear = false;
        stage2HiddenClear = false;
        stage3HiddenClear = false;
        stage1Try = false;
        stage2Try = false;
        stage3Try = false;
        stage1Score = 0;
        stage2Score = 0;
        stage3Score = 0;
        stage1HighScore = 0;
        stage2HighScore = 0;
        stage3HighScore = 0;
        stageProgress = 0;
        stageHiddenCondition = false;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        if(PlayerPrefs.HasKey("Name"))
        {
            userName = PlayerPrefs.GetString("Name");
        }

        if(PlayerPrefs.HasKey("Stage1"))
        {
            stage1State = PlayerPrefs.GetInt("Stage1");
        }

        if (PlayerPrefs.HasKey("Stage2"))
        {
            stage2State = PlayerPrefs.GetInt("Stage2");
        }

        if(PlayerPrefs.HasKey("Stage3"))
        {
            stage3State = PlayerPrefs.GetInt("Stage3");
        }

        if(PlayerPrefs.HasKey("Stage1HighScore"))
        {
            stage1HighScore = PlayerPrefs.GetInt("Stage1HighScore");
            stage1Try = true;
        }
        if (PlayerPrefs.HasKey("Stage2HighScore"))
        {
            stage2HighScore = PlayerPrefs.GetInt("Stage2HighScore");
            stage2Try = true;
        }
        if (PlayerPrefs.HasKey("Stage3HighScore"))
        {
            stage3HighScore = PlayerPrefs.GetInt("Stage3HighScore");
            stage3Try = true;
        }

        if(PlayerPrefs.HasKey("StageProgress"))
        {
            stageProgress = PlayerPrefs.GetInt("StageProgress");
        }


    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SetUserName(string pUserName)
    {
        userName = pUserName;
    }

    public string GetUserName()
    {
        return userName;
    }

    public int GetStageLevel()
    {
        return ingameStage;
    }

    public void SetStageLevel(int stageLevel)
    {
        ingameStage = stageLevel;
    }

    public bool GetStage1Clear()
    {
        return stage1Clear;
    }

    public bool GetStage2Clear()
    {
        return stage2Clear;
    }

    public bool GetStage3Clear()
    {
        return stage3Clear;
    }

    public bool GetStage1HiddenClear()
    {
        return stage1HiddenClear;
    }

    public bool GetStage2HiddenClear()
    {
        return stage2HiddenClear;
    }

    public bool GetStage3HiddenClear()
    {
        return stage3HiddenClear;
    }

    public void SetStage1Clear(bool isClear)
    {
        stage1Clear = isClear;
    }
    public void SetStage2Clear(bool isClear)
    {
        stage2Clear = isClear;
    }
    public void SetStage3Clear(bool isClear)
    {
        stage3Clear = isClear;
    }

    public void SetStage1HiddenClear(bool isClear)
    {
        stage1HiddenClear = isClear;
    }
    public void SetStage2HiddenClear(bool isClear)
    {
        stage2HiddenClear = isClear;
    }
    public void SetStage3HiddenClear(bool isClear)
    {
        stage3HiddenClear = isClear;
    }

    public void SetStage1Score(int Score)
    {
        
        stage1Score = Score;
    }

    public void SetStage2Score(int Score)
    {
        stage2Score = Score;
    }

    public void SetStage3Score(int Score)
    {
        stage3Score = Score;
    }

    public int GetStage1Score()
    {
        return stage1Score;
    }

    public int GetStage2Score()
    {
        return stage2Score;
    }

    public int GetStage3Score()
    {
        return stage3Score;
    }

    public bool GetStage1Try()
    {
        return stage1Try;
    }

    public bool GetStage2Try()
    {
        return stage2Try;
    }

    public bool GetStage3Try()
    {
        return stage3Try;
    }

    public void SetStage1Try(bool isTry)
    {
        stage1Try = isTry;
    }

    public void SetStage2Try(bool isTry)
    {
        stage2Try = isTry;
    }
    public void SetStage3Try(bool isTry)
    {
        stage3Try = isTry;
    }

    public int GetStage1HighScore()
    {
        return stage1HighScore;
    }

    public int GetStage2HighScore()
    {
        return stage2HighScore;
    }

    public int GetStage3HighScore()
    {
        return stage3HighScore;
    }

    public void SetStage1HighScore(int highScore)
    {
        stage1HighScore = highScore;
        PlayerPrefs.SetInt("Stage1HighScore", highScore);
    }

    public void SetStage2HighScore(int highScore)
    {
        stage2HighScore = highScore;
        PlayerPrefs.SetInt("Stage2HighScore", highScore);
    }

    public void SetStage3HighScore(int highScore)
    {
        stage3HighScore = highScore;
        PlayerPrefs.SetInt("Stage3HighScore", highScore);
    }

    public int GetStageProgress()
    {
        return stageProgress;
    }

    public void SetStageProgress(int progress)
    {
        stageProgress = progress;
        PlayerPrefs.SetInt("StageProgress", stageProgress);
    }

    public int GetStage1State()
    {
        return stage1State;
    }

    public int GetStage2State()
    {
        return stage2State;
    }

    public int GetStage3State()
    {
        return stage3State;
    }

    public void SetStage1State(int state)
    {
        if (stage1State > state)
            return;
        stage1State = state;

        PlayerPrefs.SetInt("Stage1", state);
    }

    public void SetStage2State(int state)
    {
        if (stage2State > state)
            return;
        stage2State = state;

        PlayerPrefs.SetInt("Stage2", state);
    }

    public void SetStage3State(int state)
    {
        if (stage3State > state)
            return;
        stage3State = state;

        PlayerPrefs.SetInt("Stage3", state);

    }

    public bool GetStageHiddenCondition()
    {
        return stageHiddenCondition;
    }

    public void SetStageHiddenCondition(bool istrue)
    {
        stageHiddenCondition = istrue;
    }


    public void ResetGameManager()
    {
        userName = "";

        stage1State = 0;
        stage2State = 0;
        stage3State = 0;
        stage1Clear = false;
        stage2Clear = false;
        stage3Clear = false;
        stage1HiddenClear = false;
        stage2HiddenClear = false;
        stage3HiddenClear = false;
        stage1Try = false;
        stage2Try = false;
        stage3Try = false;
        stage1Score = 0;
        stage2Score = 0;
        stage3Score = 0;
        stage1HighScore = 0;
        stage2HighScore = 0;
        stage3HighScore = 0;

    }
}

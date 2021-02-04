using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect_PanelChange : MonoBehaviour
{
    public GameObject Stage1Panel;
    public GameObject Stage2Panel;
    public GameObject Stage3Panel;
    // Start is called before the first frame update
    void Start()
    {
        SettingPanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SettingPanel()
    {
        switch(GameManager.instance.GetStageProgress())
        {
            case 0:
                Stage1Panel.SetActive(false);
                Stage2Panel.SetActive(true);
                Stage3Panel.SetActive(true);
                break;
            case 1:
                Stage1Panel.SetActive(false);
                Stage2Panel.SetActive(false);
                Stage3Panel.SetActive(true);
                break;
            case 2:
                Stage1Panel.SetActive(false);
                Stage2Panel.SetActive(false);
                Stage3Panel.SetActive(false);
                break;
            default:
                Stage1Panel.SetActive(false);
                Stage2Panel.SetActive(false);
                Stage3Panel.SetActive(false);
                break;
        }
    }
}

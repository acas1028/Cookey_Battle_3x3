using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExampleStep : MonoBehaviour
{
    public GameObject ingameStepObject;
    public Text text;
    int step;
    int stage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        step = ingameStepObject.GetComponent<CompareActiveAnswer>().GetIngameStep();
        stage = ingameStepObject.GetComponent<CompareActiveAnswer>().GetIngameStage();
        text.text = "스테이지: " + stage + " 단계:" + step;
    }
}

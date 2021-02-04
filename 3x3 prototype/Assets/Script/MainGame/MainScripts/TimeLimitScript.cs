using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLimitScript : MonoBehaviour
{
    Slider slTimer;
    float fSliderBarTime;

    public GameObject TimeOverObject;
    public GameObject MainKeyBoardInput;
    // Start is called before the first frame update
    void Start()
    {
        slTimer = GetComponent<Slider>();
       
       
    }

    // Update is called once per frame
    void Update()
    {
        if (slTimer.value > 0.0f)
        {
            slTimer.value -= Time.deltaTime;
        }
        else
        {
            TimeOverObject.SetActive(true);
            MainKeyBoardInput.SetActive(false);
            Debug.Log("Timeover");
        }
    }
}

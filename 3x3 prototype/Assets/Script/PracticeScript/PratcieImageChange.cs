using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PratcieImageChange : MonoBehaviour
{
    public GameObject SlimeButton;

    public GameObject DragonButton;

    public Sprite slimeBackGround;

    public Sprite DragonBackGround;

    public Sprite noneBackGround;


    private void Update()
    {
        
        if(GameManager.instance.GetStage1State() >=1)
        {
            SlimeButton.GetComponent<Image>().sprite = slimeBackGround;
            SlimeButton.GetComponent<Button>().enabled = true;
        }
        else if(GameManager.instance.GetStage1State() < 1)
        {
            SlimeButton.GetComponent<Image>().sprite = noneBackGround;
            SlimeButton.GetComponent<Button>().enabled = false;
        }
        if (GameManager.instance.GetStage2State()>=1)
        {
            DragonButton.GetComponent<Image>().sprite = DragonBackGround;
            DragonButton.GetComponent<Button>().enabled = true;
        }
        else if (GameManager.instance.GetStage2State()<1)
        {
            DragonButton.GetComponent<Image>().sprite = noneBackGround;
            DragonButton.GetComponent<Button>().enabled = false;
        }
    }
}

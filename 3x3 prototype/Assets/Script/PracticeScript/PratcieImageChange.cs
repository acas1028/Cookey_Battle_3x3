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
        Debug.Log(GameManager.instance.GetStage1Clear());
        if(GameManager.instance.GetStage1Clear()== true)
        {
            SlimeButton.GetComponent<Image>().sprite = slimeBackGround;
            SlimeButton.GetComponent<Button>().enabled = true;
        }
        else if(GameManager.instance.GetStage1Clear() == false)
        {
            SlimeButton.GetComponent<Image>().sprite = noneBackGround;
            SlimeButton.GetComponent<Button>().enabled = false;
        }
        if (GameManager.instance.GetStage2Clear() == true)
        {
            DragonButton.GetComponent<Image>().sprite = DragonBackGround;
            DragonButton.GetComponent<Button>().enabled = false;
        }
        else if (GameManager.instance.GetStage2Clear() == false)
        {
            DragonButton.GetComponent<Image>().sprite = noneBackGround;
            DragonButton.GetComponent<Button>().enabled = false;
        }
    }
}

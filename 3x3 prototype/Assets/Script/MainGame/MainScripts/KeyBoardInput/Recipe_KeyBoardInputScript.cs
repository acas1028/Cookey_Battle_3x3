using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Recipe_KeyBoardInputScript : MonoBehaviour
{
    private int numberOfPage;
    private int numberOfRecipe;

    private int recipe1Number;
    private int recipe2Number;
    private int recipe3Number;

    public Sprite[] SpaceSoup_Clear;
    public Sprite[] SpaceSoup;
    public Sprite[] Slime_Clear;
    public Sprite[] Slime;
    public Sprite[] Dragon_Clear;
    public Sprite[] Dragon;
    public GameObject mainGameKeyBoardInput;

    public GameObject SoundBox;
    // Start is called before the first frame update
    void Start()
    {
        numberOfPage = 0;
        numberOfRecipe = 0;

        recipe1Number = 4;
        recipe2Number = 10;
        recipe3Number = 22;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Escape))
        {
            numberOfPage = 0;
            numberOfRecipe = 0;
            SoundBox.GetComponent<SoundBoxController>().PlaySound(0);
            mainGameKeyBoardInput.SetActive(true);
            this.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            switch(numberOfRecipe)
            {
                case 0:
                    if (numberOfPage > 0)
                    {
                        SoundBox.GetComponent<SoundBoxController>().PlaySound(0);
                        numberOfPage--;
                    }
                    break;
                case 1:
                    if (numberOfPage > 0)
                    {
                        SoundBox.GetComponent<SoundBoxController>().PlaySound(0);
                        numberOfPage--;
                    }
                    break;
                case 2:
                    if (numberOfPage > 0)
                    {
                        SoundBox.GetComponent<SoundBoxController>().PlaySound(0);
                        numberOfPage--;
                    }
                    break;
            }
           
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            switch (numberOfRecipe)
            {
                case 0:
                    if (numberOfPage < recipe1Number - 1)
                    {
                        SoundBox.GetComponent<SoundBoxController>().PlaySound(0);
                        numberOfPage++;
                    }
                    break;
                case 1:
                    if (numberOfPage < recipe2Number - 1)
                    {
                        SoundBox.GetComponent<SoundBoxController>().PlaySound(0);
                        numberOfPage++;
                    }
                    break;
                case 2:
                    if (numberOfPage < recipe3Number - 1)
                    {
                        SoundBox.GetComponent<SoundBoxController>().PlaySound(0);
                        numberOfPage++;
                    }
                    break;
            }
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(numberOfRecipe > 0)
            {
                SoundBox.GetComponent<SoundBoxController>().PlaySound(0);
                numberOfRecipe--;
                numberOfPage = 0;
            }

        
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (numberOfRecipe < 3)
            {
                SoundBox.GetComponent<SoundBoxController>().PlaySound(0);
                numberOfRecipe++;
                numberOfPage = 0;
            }
        }


        if (numberOfRecipe > 3)
            numberOfRecipe = 3;
        if (numberOfRecipe < 0)
            numberOfRecipe = 0;

        SettingImage(numberOfRecipe,numberOfPage);
    }

    void SettingImage(int recipe,int page)
    {
        switch(recipe)
        {
            case 0:
                SettingImage_Recipe1(page);
                break;
            case 1:
                SettingImage_Recipe2(page);
                break;
            case 2:
                SettingImage_Recipe3(page);
                break;
        }
    }

    void SettingImage_Recipe1(int page)
    {
        if (GameManager.instance.GetStage1Try())
            GetComponent<Image>().sprite = SpaceSoup_Clear[page];
        else
            GetComponent<Image>().sprite = SpaceSoup[page];
    }

    void SettingImage_Recipe2(int page)
    {
        if (GameManager.instance.GetStage2Try())
            GetComponent<Image>().sprite = Slime_Clear[page];
        else
            GetComponent<Image>().sprite = Slime[page];
    }

    void SettingImage_Recipe3(int page)
    {
        if (GameManager.instance.GetStage3Try())
            GetComponent<Image>().sprite = Dragon_Clear[page];
        else
            GetComponent<Image>().sprite = Dragon[page];
    }
}

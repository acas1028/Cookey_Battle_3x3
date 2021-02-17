using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public int step=0;

    //튜토리얼 skip 만들기

    public float time = 0;

    public GameObject[] Tutorial_Image;

    public GameObject practiceSelectButton;

    public GameObject TutorialSkip;

    public bool notskip = false;

    public Animator animator;

    public void Start()
    {
        Tutorial_Image = GameObject.FindGameObjectsWithTag("Tutorial");

        for(int i=0; i<Tutorial_Image.Length; i++)
        {
            Tutorial_Image[i].SetActive(false);

        }
        
        
    }

    public void Update()
    {

        switch(step)
        {
            case 0:
                {
                    Tutorial_Image[0].SetActive(true);

                    if(GameManager.instance.GetTutorialClear()==true)
                    {
                        TutorialSkip.SetActive(true);
                    }

                    if (notskip == true || GameManager.instance.GetTutorialClear() == false)
                    {
                        if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                        {
                            Tutorial_Image[0].SetActive(false);
                            Tutorial_Image[1].SetActive(true);
                            notskip = false;
                            step++;
                        }
                    }
                }
                break;
            case 1:
                {
                    Tutorial_Image[1].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[1].SetActive(false);
                        Tutorial_Image[2].SetActive(true);
                        step++;
                    }
                }
                break;
            case 2:
                {
                    Tutorial_Image[2].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[2].SetActive(false);
                        Tutorial_Image[3].SetActive(true);
                        step++;
                    }
                }
                break;
            case 3:
                {
                    Tutorial_Image[3].SetActive(true);
                    time += 1;
                    if (time>300)// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[3].SetActive(false);
                        Tutorial_Image[4].SetActive(true);
                        step++;
                    }
                }
                break;
            case 4:
                {
                    Tutorial_Image[4].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[4].SetActive(false);
                        Tutorial_Image[5].SetActive(true);
                        step++;
                    }
                }
                break;
            case 5:
                {
                    Tutorial_Image[5].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[5].SetActive(false);
                        Tutorial_Image[6].SetActive(true);
                        step++;
                    }
                }
                break;
            case 6:
                {
                    Tutorial_Image[6].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[6].SetActive(false);
                        Tutorial_Image[7].SetActive(true);
                        step++;
                    }
                }
                break;
            case 7:
                {
                    Tutorial_Image[7].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[7].SetActive(false);
                        Tutorial_Image[8].SetActive(true);
                        step++;
                    }
                }
                break;
            case 8:
                {
                    Tutorial_Image[8].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[8].SetActive(false);
                        Tutorial_Image[9].SetActive(true);
                        step++;
                    }
                }
                break;
            case 9:
                {
                    Tutorial_Image[9].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[9].SetActive(false);
                        Tutorial_Image[10].SetActive(true);
                        step++;
                    }
                }
                break;
            case 10:
                {
                    Tutorial_Image[10].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[10].SetActive(false);
                        Tutorial_Image[11].SetActive(true);
                        step++;
                    }
                }
                break;
            case 11:
                {
                    Tutorial_Image[11].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[11].SetActive(false);
                        Tutorial_Image[12].SetActive(true);
                        step++;
                    }
                }
                break;
            case 12:
                {
                    Tutorial_Image[12].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[12].SetActive(false);
                        Tutorial_Image[13].SetActive(true);
                        step++;
                    }
                }
                break;
            case 13:
                {
                    Tutorial_Image[13].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[13].SetActive(false);
                        Tutorial_Image[14].SetActive(true);
                        step++;
                    }
                }
                break;
            case 14:
                {
                    Tutorial_Image[14].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[14].SetActive(false);
                        Tutorial_Image[15].SetActive(true);
                        step++;
                    }
                }
                break;
            case 15:
                {
                    Tutorial_Image[15].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Escape))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[15].SetActive(false);
                        Tutorial_Image[16].SetActive(true);
                        step++;
                    }
                }
                break;
            case 16:
                {
                    Tutorial_Image[16].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[16].SetActive(false);
                        Tutorial_Image[17].SetActive(true);
                        step++;
                    }
                }
                break;
            case 17:
                {
                    Tutorial_Image[17].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[17].SetActive(false);
                        Tutorial_Image[18].SetActive(true);
                        step++;
                    }
                }
                break;
            case 18:
                {
                    Tutorial_Image[18].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[18].SetActive(false);
                        Tutorial_Image[19].SetActive(true);
                        step++;
                    }
                }
                break;
            case 19:
                {
                    Tutorial_Image[19].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[19].SetActive(false);
                        Tutorial_Image[20].SetActive(true);
                        step++;
                    }
                }
                break;
            case 20:
                {
                    Tutorial_Image[20].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.RightArrow))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[20].SetActive(false);
                        Tutorial_Image[21].SetActive(true);
                        step++;
                    }
                }
                break;
            case 21:
                {
                    Tutorial_Image[21].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[21].SetActive(false);
                        Tutorial_Image[22].SetActive(true);
                        step++;
                    }
                }
                break;
            case 22:
                {
                    Tutorial_Image[22].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[22].SetActive(false);
                        Tutorial_Image[23].SetActive(true);
                        step++;
                    }
                }
                break;
            case 23:
                {
                    Tutorial_Image[23].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[23].SetActive(false);
                        Tutorial_Image[24].SetActive(true);
                        step++;
                    }
                }
                break;
            case 24:
                {
                    Tutorial_Image[24].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[24].SetActive(false);
                        Tutorial_Image[25].SetActive(true);
                        step++;
                    }
                }
                break;
            case 25:
                {
                    Tutorial_Image[25].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[25].SetActive(false);
                        Tutorial_Image[26].SetActive(true);
                        step++;
                    }
                }
                break;
            case 26:
                {
                    Tutorial_Image[26].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[26].SetActive(false);
                        Tutorial_Image[27].SetActive(true);
                        step++;
                    }
                }
                break;
            case 27:
                {
                    Tutorial_Image[27].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[27].SetActive(false);
                        animator.SetBool("Tutorial", true);
                        step++;
                    }
                }
                break;
            case 28:
                {
                    //Tutorial_Image[28].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        animator.SetBool("Tutorial", false);
                        Tutorial_Image[28].SetActive(true);
                        step++;
                    }
                }
                break;
            case 29:
                {
                    Tutorial_Image[28].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[28].SetActive(false);
                        Tutorial_Image[29].SetActive(true);
                        step++;
                    }
                }
                break;
            case 30:
                {
                    Tutorial_Image[29].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.R))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[29].SetActive(false);
                        Tutorial_Image[30].SetActive(true);
                        step++;
                    }
                }
                break;
            case 31:
                {
                    Tutorial_Image[30].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[30].SetActive(false);
                        Tutorial_Image[31].SetActive(true);
                        step++;
                    }
                }
                break;
            case 32:
                {
                    Tutorial_Image[31].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[31].SetActive(false);
                        Tutorial_Image[32].SetActive(true);
                        step++;
                    }
                }
                break;
            case 33:
                {
                    Tutorial_Image[32].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[32].SetActive(false);
                        Tutorial_Image[33].SetActive(true);
                        step++;
                    }
                }
                break;
            case 34:
                {
                    Tutorial_Image[33].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[33].SetActive(false);
                        Tutorial_Image[34].SetActive(true);
                        step++;
                    }
                }
                break;
            case 35:
                {
                    Tutorial_Image[34].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[34].SetActive(false);
                        Tutorial_Image[35].SetActive(true);
                        step++;
                    }
                }
                break;
            case 36:
                {
                    Tutorial_Image[35].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.W))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[35].SetActive(false);
                        Tutorial_Image[36].SetActive(true);
                        step++;
                    }
                }
                break;
            case 37:
                {
                    Tutorial_Image[36].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[36].SetActive(false);
                        Tutorial_Image[37].SetActive(true);
                        step++;
                    }
                }
                break;
            case 38:
                {
                    Tutorial_Image[37].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[37].SetActive(false);
                        Tutorial_Image[38].SetActive(true);
                        step++;
                    }
                }
                break;
            case 39:
                {
                    Tutorial_Image[38].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[38].SetActive(false);
                        Tutorial_Image[39].SetActive(true);
                        step++;
                    }
                }
                break;
            case 40:
                {
                    Tutorial_Image[39].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[39].SetActive(false);
                        Tutorial_Image[40].SetActive(true);
                        step++;
                    }
                }
                break;
            case 41:
                {
                    Tutorial_Image[40].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[40].SetActive(false);
                        Tutorial_Image[41].SetActive(true);
                        step++;
                    }
                }
                break;
            case 42:
                {
                    Tutorial_Image[41].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Escape))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[41].SetActive(false);
                        Tutorial_Image[42].SetActive(true);
                        step++;
                    }
                }
                break;
            case 43:
                {
                    Tutorial_Image[42].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[42].SetActive(false);
                        Tutorial_Image[43].SetActive(true);
                        step++;
                    }
                }
                break;
            case 44:
                {
                    Tutorial_Image[43].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))// 상황에 따라 입력하는 키보드를 바꾼다.
                    {
                        Tutorial_Image[43].SetActive(false);
                        Tutorial_Image[44].SetActive(true);
                        step++;
                    }
                }
                break;
            case 45:
                {
                    GameManager.instance.SetTutorialClear(true);
                    practiceSelectButton.SetActive(true);
                }
                break;


        }
    }
}

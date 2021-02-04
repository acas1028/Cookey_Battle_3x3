using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniverseTasteSoup : MonoBehaviour
{
    public int soupNumberCount = 0; //조리 순서를 순서대로 하기위해 놓는 변수.
    private void Update()
    {
        if(soupNumberCount==0)
        {
            soupNumberCount += 1; //다음 단계로 진입하기위한 열쇠
        }
    }
}

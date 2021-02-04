using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class Command : MonoBehaviour
{

    public Vector3 space1 = new Vector3(-15, 0, 0);
    public Vector3 space2 = new Vector3(-10, 0, 0);
    public Vector3 space3 = new Vector3(-5, 0, 0);
    public Vector3 space4 = new Vector3(0, 0, 0);
    public Vector3 space5 = new Vector3(5, 0, 0);
    public Vector3 space6 = new Vector3(10, 0, 0);
    public Vector3 space7 = new Vector3(15, 0, 0);
    public Vector3 space8 = new Vector3(20, 0, 0);
    public Vector3 space9 = new Vector3(25, 0, 0);
    public Vector3 space10 = new Vector3(30, 0, 0);

    Vector3 space11 = new Vector3(1, 2, 3);



    



    public GameObject Right;
    public GameObject Left;
    public GameObject Up;
    public GameObject Down;
    public GameObject commandCollection;
    public List<GameObject> commandList = new List<GameObject>();

    public void Spawn(Vector3 Spawnposition, KeyCode keyCode)
    {
       




        if (keyCode == KeyCode.UpArrow)
        { 

            GameObject instance = Instantiate(Up, Spawnposition, Quaternion.identity);
            instance.transform.SetParent(commandCollection.transform);
            commandList.Add(instance);
        }
        else if (keyCode == KeyCode.RightArrow)
        {

            GameObject instance = Instantiate(Right, Spawnposition, Quaternion.identity);
            instance.transform.SetParent(commandCollection.transform);
            commandList.Add(instance);
        }
        else if (keyCode == KeyCode.LeftArrow)
        {

            GameObject instance = Instantiate(Left, Spawnposition, Quaternion.identity);
            instance.transform.SetParent(commandCollection.transform);
            commandList.Add(instance);
        }
        else if (keyCode == KeyCode.DownArrow)
        {

            GameObject instance = Instantiate(Down, Spawnposition, Quaternion.identity);
            instance.transform.SetParent(commandCollection.transform);
            commandList.Add(instance);
        }




        //instantiate는 소환 코드, 즉 (소환 물체, 위치, rotation)만 넣어주면 된다. 이를 고려해 코드를 작성.

    }
    public Vector3 Spawnposition(int i)
    {
        switch(i)
        {
            case 1:
                return space1;
            case 2:
                return space2;
            case 3:
                return space3;
            case 4:
                return space4;
            case 5:
                return space5;
            case 6:
                return space6;
            case 7:
                return space7;
            case 8:
                return space8;
            case 9:
                return space9;
            case 10:
                return space10;

            default:
                return space11;
        }


    }





}

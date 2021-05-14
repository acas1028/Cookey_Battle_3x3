using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prologueImageChange : MonoBehaviour
{
    private int imageNumber;

    public Image prologueImage;

    public GameObject nameSpace;

    public Sprite[] images;
    // Start is called before the first frame update
    void Start()
    {
        imageNumber = 0;
        Debug.Log(images.Length);
        GameManager.instance.SetStageProgress(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (imageNumber >= images.Length)
        {
            nameSpace.SetActive(true);
        }
        else
        {
            prologueImage.sprite = images[imageNumber];
            Debug.Log(imageNumber);
        }
    }

    public void SetImageNumber(int num)
    {
        imageNumber = num;
    }

    public int GetImageNumber()
    {
        return imageNumber;
    }

    public void PlusImageNumber()
    {
        imageNumber++;
    }
}

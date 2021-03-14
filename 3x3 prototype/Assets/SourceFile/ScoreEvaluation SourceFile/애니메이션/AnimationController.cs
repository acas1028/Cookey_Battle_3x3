using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public GameObject NextObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Change()
    {
        if(NextObject != null)
            NextObject.SetActive(true);
    }

    public void DestroyThis()
    {
        Destroy(gameObject);
    }
}

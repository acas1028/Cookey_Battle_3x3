using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadEndingImageController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fader;
    public GameObject blackBackGround;

    void Start()
    {
        StartCoroutine(Activate());
        blackBackGround.SetActive(true);
    }

    IEnumerator Activate()
    {
        fader.GetComponent<FadeController>().FadeIn(0.7f);
        yield return new WaitForSeconds(3f);
        fader.GetComponent<FadeController>().FadeOut(0.7f,() =>SceneManager.LoadScene(0));
    }
}
